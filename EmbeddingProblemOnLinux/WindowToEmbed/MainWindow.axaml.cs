using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using System.IO;
using System.Reflection;

namespace WindowToEmbed
{
    public partial class MainWindow : Window
    {

        #region WindowHandle Styled Avalonia Property
        public long WindowHandle
        {
            get { return GetValue(WindowHandleProperty); }
            set { SetValue(WindowHandleProperty, value); }
        }

        public static readonly StyledProperty<long> WindowHandleProperty =
            AvaloniaProperty.Register<MainWindow, long>
            (
                nameof(WindowHandle)
            );
        #endregion WindowHandle Styled Avalonia Property


        public MainWindow()
        {
            InitializeComponent();

            PropertyInfo propertyInfo = typeof(IWindowBaseImpl).GetProperty("Handle");

            WindowHandle = 
                (long) ((IPlatformHandle) propertyInfo.GetValue(this.PlatformImpl as IWindowBaseImpl)).Handle;

            using StreamWriter writer = new StreamWriter("MyFile.txt");

            writer.WriteLine(WindowHandle);

            writer.Flush();
            writer.Close();
        }
    }
}
