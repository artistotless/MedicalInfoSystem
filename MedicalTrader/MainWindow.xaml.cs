
using ExcelDataReader;
using Ionic.Zip;
using MedicalTrader.helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MedicalTrader
{

    public partial class MainWindow : Window
    {
        // 1 DocumentsPage()
        // 2 MedicalItemsPage()
        // 3 PlanningPage()
        // 4 ProvidersPage()
        // 5 PurchasesPage()
        // 6 SalesPage()
        // 7 WarehousesPage()

        private Page[] pages = { null, new DocumentsPage(), new MedicalItemsPage(), new PlanningPage(), new ProvidersPage(), new PurchasesPage(), new SalesPage(), new WarehousesPage() };
        private ColorAnimation animation;
        //Window lastPage = null;
       // User authUser = null;
        public MainWindow()
        {
            InitializeComponent();
            //lastPage.Close();

            //accountBtn.Header = "admin";


            Color fromColor = new Color() { R = 85, G = 85, B = 238, A = 255 };
            Color toColor = new Color() { R = 85, G = 238, B = 120, A = 255 };

            animation = new ColorAnimation();
            animation.From = fromColor;
            animation.To = toColor;
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));



            BackGroundEvents.OnShowLoading += BackGroundEvents_OnShowLoading;
            BackGroundEvents.OnHideLoading += BackGroundEvents_OnHideLoading;

            


            Parse();

        }


        private void BackGroundEvents_OnShowLoading(string msg)
        {
            Dispatcher.Invoke(() => indicatorStatus.Visibility = Visibility.Visible);
            Dispatcher.Invoke(() => indicatorStatus.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, animation));
            Dispatcher.Invoke(() => statusLabel.Text = msg);

        }

        private void BackGroundEvents_OnHideLoading(string msg)
        {
            Dispatcher.Invoke(() => statusLabel.Text = msg);
            Dispatcher.Invoke(() => indicatorStatus.Visibility = Visibility.Collapsed);


        }



        public async void Parse()
        {
              await new CheckerLicense().CheckLicenceAsync("0721018808");
        }



        private void NavigateToFrame(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "Планирование":
                    MainFrame.Content = pages[3];
                    break;
                case "Закупки":
                    MainFrame.Content = pages[5];
                    break;
                case "Препараты":
                    MainFrame.Content = pages[2];
                    break;
                case "Продажи":
                    MainFrame.Content = pages[6];
                    break;
                case "Поставщики":
                    MainFrame.Content = pages[4];
                    break;
                case "Склады":
                    MainFrame.Content = pages[7];
                    break;
                case "Документы":
                    MainFrame.Content = pages[1];
                    break;
                case "Главная":
                    MainFrame.Content = pages[2];
                    break;
            }


        }
    }
}
