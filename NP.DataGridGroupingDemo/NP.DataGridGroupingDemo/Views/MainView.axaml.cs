using Avalonia.Collections;
using Avalonia.Controls;
using System.Text.RegularExpressions;

namespace NP.DataGridGroupingDemo.Views;

public partial class MainView : UserControl
{
    public People ThePeople { get; } = new People();

    private bool _isGrouped = false;

    private const string GroupingButtonName = "Group by Last Name";
    private const string UnGroupingButtonName = "Ungroup";
    public MainView()
    {
        InitializeComponent();

        GroupByLastNameButton.Content = GroupingButtonName;
        GroupByLastNameButton.Click += GroupByLastNameButton_Click;
    }
    private void GroupByLastNameButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataGridCollectionView collectionView = (DataGridCollectionView)TheDataGrid.ItemsSource;

        if (_isGrouped)
        {
            collectionView.GroupDescriptions.Clear();
            GroupByLastNameButton.Content = GroupingButtonName;
        }
        else
        {
            collectionView.GroupDescriptions.Add(new DataGridPathGroupDescription("LastName"));
            GroupByLastNameButton.Content = UnGroupingButtonName;
        }

        _isGrouped = !_isGrouped;
    }
}