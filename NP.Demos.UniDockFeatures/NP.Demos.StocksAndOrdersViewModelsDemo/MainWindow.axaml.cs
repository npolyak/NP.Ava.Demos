using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NP.Ava.UniDockService;
using System.Collections.ObjectModel;
using System.Linq;

namespace NP.Demos.StocksAndOrdersViewModelsDemo
{
    public partial class MainWindow : Window
    {
        // non-visual interface to the DockManager
        public IUniDockService _uniDockService;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // set the uniDockService interface to contain the reference to the
            // dock manager defined as a resource.
            _uniDockService = (IUniDockService) this.FindResource("TheDockManager")!;

            // set the DockItemsViewModels collection to an observable
            // collection of DockItemViewModelBase items.
            _uniDockService.DockItemsViewModels = 
                new ObservableCollection<DockItemViewModelBase>();

            Button addOrderButton = this.FindControl<Button>("AddOrderButton");

            addOrderButton.Click += AddOrderButton_Click;

            // set the Click handlers on the AddTab, Save and Restore buttons

            Button addStockButton = this.FindControl<Button>("AddStockButton");
            addStockButton.Click += AddStockButton_Click;

            Button saveButton = this.FindControl<Button>("SaveButton");
            saveButton.Click += SaveButton_Click;

            Button restoreButton = this.FindControl<Button>("RestoreButton");
            restoreButton.Click += RestoreButton_Click;
        }


        int _orderNumber = 0;
        private void AddOrderButton_Click(object? sender, RoutedEventArgs e)
        {
            var stock = Stocks[_orderNumber % 2];
            OrderViewModel orderVM = new OrderViewModel
            {
                Symbol = stock.Symbol,
                MarketPrice = (stock.Ask + stock.Bid) / 2m,
                NumberShares = (_orderNumber + 1) * 1000
            };


            var newTabVm = new OrderDockItemViewModel
            {
                DockId = "Order" + _orderNumber + 1,
                DefaultDockGroupId = "Orders",
                DefaultDockOrderInGroup = _orderNumber,
                HeaderContentTemplateResourceKey = "OrderHeaderDataTemplate",
                ContentTemplateResourceKey = "OrderDataTemplate",
                IsPredefined = false,
                TheVM = orderVM
            };

            _uniDockService.DockItemsViewModels!.Add(newTabVm);

            _orderNumber++;
        }

        private static StockViewModel IBM =
            new StockViewModel
            {
                Symbol = "IBM",
                Description = "Internation Business Machines",
                Ask = 51,
                Bid = 49
            };

        private static StockViewModel MSFT =
            new StockViewModel
            {
                Symbol = "MSFT",
                Description = "Microsoft",
                Ask = 101,
                Bid = 99
            };

        private static StockViewModel[] Stocks =
        {
            IBM,
            MSFT
        };

        private int _stockNumber = 0;
        private void AddStockButton_Click(object? sender, RoutedEventArgs e)
        {
            var stock = Stocks[_stockNumber % 2];
            int tabNumber = _stockNumber + 1;
            _uniDockService.DockItemsViewModels.Add
            (
                new StockDockItemViewModel
                {
                    DockId = $"{stock.Symbol}_{tabNumber}",
                    TheVM = stock,
                    DefaultDockGroupId = "Stocks",
                    DefaultDockOrderInGroup = _stockNumber,
                    HeaderContentTemplateResourceKey = "StockHeaderDataTemplate",
                    ContentTemplateResourceKey = "StockDataTemplate",
                    IsSelected = true,
                    IsActive = true,
                    IsPredefined = false
                });

            _stockNumber++;
        }


        private const string DockSerializationFileName = "DockSerialization.xml";
        private const string VMSerializationFileName = "DockVMSerialization.xml";

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            // save the layout
            _uniDockService.SaveToFile(DockSerializationFileName);

            // save the view models
            _uniDockService.SaveViewModelsToFile(VMSerializationFileName);
        }

        private void RestoreButton_Click(object? sender, RoutedEventArgs e)
        {
            // clear the view models
            _uniDockService.DockItemsViewModels = null;

            // restore the layout
            _uniDockService.RestoreFromFile(DockSerializationFileName);

            // restore the view models
            _uniDockService.RestoreViewModelsFromFile
            (   
                VMSerializationFileName,
                typeof(StockDockItemViewModel),
                typeof(OrderDockItemViewModel));

            // select the first tab.
            _uniDockService.DockItemsViewModels?.FirstOrDefault()?.Select();

            _stockNumber = _uniDockService?.DockItemsViewModels?.OfType<StockDockItemViewModel>()?.Count() ?? 0;
            _orderNumber = _uniDockService?.DockItemsViewModels?.OfType<OrderDockItemViewModel>()?.Count() ?? 0;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
