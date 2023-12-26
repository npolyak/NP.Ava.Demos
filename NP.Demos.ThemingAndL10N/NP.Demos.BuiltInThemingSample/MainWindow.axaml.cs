using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace NP.Demos.BuiltInThemingSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // set the handler for lightButton's click event
            Button lightButton = this.FindControl<Button>("LightButton");
            lightButton.Click += LightButton_Click;

            // set the handler for darkButton's click event
            Button darkButton = this.FindControl<Button>("DarkButton");
            darkButton.Click += DarkButton_Click;

            Button pinkButton = this.FindControl<Button>("PinkButton");
            pinkButton.Click += PinkButton_Click;
        }

        private void LightButton_Click(object? sender, RoutedEventArgs e)
        {
            // set the theme to Light
            this.RequestedThemeVariant = ThemeVariant.Light;
        }

        private void DarkButton_Click(object? sender, RoutedEventArgs e)
        {
            // set the theme to Dark
            this.RequestedThemeVariant = ThemeVariant.Dark;
        }
        private void PinkButton_Click(object? sender, RoutedEventArgs e)
        {
            // set the theme to Ping
            this.RequestedThemeVariant = CustomThemes.Pink;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
