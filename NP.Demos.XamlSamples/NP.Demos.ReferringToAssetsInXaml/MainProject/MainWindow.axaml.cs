using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace NP.Demos.ReferringToAssetsInXaml
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // get the Image control from XAML
            Image linuxIconImage2 = this.FindControl<Image>("LinuxIconImage2");

            // set the image Source using assetLoader
            linuxIconImage2.Source = 
                new Bitmap
                (
                    AssetLoader.Open(new Uri("avares://NP.Demos.ReferringToAssetsInXaml/Assets/LinuxIcon.jpg")));

            // get the Image control from XAML
            Image avaloniaIconImage2 = this.FindControl<Image>("AvaloniaIconImage2");

            // set the image Source using assetLoader
            avaloniaIconImage2.Source =
                new Bitmap
                (
                    AssetLoader.Open(
                        new Uri("avares://Dependency1Proj/Assets/avalonia-32.png")));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
