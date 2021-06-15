using MedicalTrader.other;

using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow(WindowConfig config, Page frame)
        {
            InitializeComponent();
            window.Title += " - " + config.title;
            window.Height = config.height;
            window.Width = config.width;
            window.ResizeMode = config.resizeMode;

            this.frame.Content = frame;

        }
    }
}
