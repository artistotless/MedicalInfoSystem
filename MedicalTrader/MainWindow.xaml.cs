

using MedicalTrader.helpers;
using MedicalTrader.other;
using System;
using System.Windows;

using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MedicalTrader
{

    public partial class MainWindow : Window
    {

        private ColorAnimation animation;
        public MainWindow(Window lastWindow = null, User authUser = null)
        {
            init(lastWindow, authUser);
        }

        public MainWindow()
        {
            init();
        }

        void init(Window lastWindow = null, User authUser = null)
        {
            InitializeComponent();
            NavigateFrame.Init(MainFrame);
            if (lastWindow != null) { lastWindow.Close(); }

            accountBtn.Header = authUser == null ? "Без входа" : authUser.login;
            role.Header = "Группа: " + (authUser == null ? Role.Manager : (Role)authUser.role);
            NavigateFrame.NavigateToFrame(Pages.Drugs);

            Color fromColor = new Color() { R = 85, G = 85, B = 238, A = 255 };
            Color toColor = new Color() { R = 85, G = 238, B = 120, A = 255 };

            animation = new ColorAnimation();
            animation.From = fromColor;
            animation.To = toColor;
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));


            BackGroundEvents.OnShowLoading += BackGroundEvents_OnShowLoading;
            BackGroundEvents.OnHideLoading += BackGroundEvents_OnHideLoading;
        }


        private void BackGroundEvents_OnShowLoading(string msg)
        {
            Dispatcher.Invoke(() =>
            {
                indicatorStatus.Visibility = Visibility.Visible;
                indicatorStatus.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                statusLabel.Text = msg;
            }
            );


        }

        private void BackGroundEvents_OnHideLoading(string msg)
        {
            Dispatcher.Invoke(() => statusLabel.Text = msg);
            Dispatcher.Invoke(() => indicatorStatus.Visibility = Visibility.Collapsed);


        }


        private void ExitFromAccount(object sender, RoutedEventArgs e)
        {
            new Auth(this).Show();
        }


        private void NavigateToFrame(object sender, RoutedEventArgs e)
        {
            NavigateFrame.NavigateToFrame((Pages)(Convert.ToInt64((((FrameworkElement)sender).Tag.ToString()))));
        }

        private void PrintDoc(object sender, RoutedEventArgs e)
        {

        }
    }
}
