using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace NP.Demos.BuiltInControls
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var openWindowButton = this.FindControl<Button>("OpenWindowButton");

            openWindowButton.Click += OpenWindowButton_Click;

            var openModalWindowButton = 
                this.FindControl<Button>("OpenModalWindowButton");

            openModalWindowButton.Click += OpenModalWindowButton_Click;
        }

        private void OpenWindowButton_Click(object? sender, RoutedEventArgs e)
        {
            // Create the window object
            Window sampleWindow = 
                new Window 
                { 
                    Title = "Sample Window",
                    Width = 200,
                    Height = 200
                };

            // open the window
            sampleWindow.Show();
        }

        private void OpenModalWindowButton_Click(object? sender, RoutedEventArgs e)
        {
            // Create the window object
            Window sampleWindow = 
                new Window 
                { 
                    Title = "Sample Modal (Dialog) Window",
                    Width = 200,
                    Height = 200
                };

            // open the window as modal dialog
            sampleWindow.ShowDialog(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
