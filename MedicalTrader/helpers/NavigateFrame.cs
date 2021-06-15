
using System.Windows.Controls;

namespace MedicalTrader.helpers
{
    public enum Pages
    {
        Planning,
        Purchases,
        Drugs,
        Sales,
        Providers,
        Warehouses,
        Documents,
        Clients,
        Settings,
        Counterfeits
    }
    public static class NavigateFrame
    {
        private static Page[] pages = {
            new PlanningPage(),
            new PurchasesPage(),
            new DrugsPage(),
            new SalesPage(),
            new ProvidersPage(),
            new WarehousesPage(),
            new DocumentsPage(),
            new ClientsPage(),
            new SettingsPage(),
            new CounterfeitsPage()

            };
        internal static Frame mainFrame { get; private set; }

        public static void Init(Frame frame)
        {
            mainFrame = mainFrame == null ? frame : mainFrame;
        }
        public static void NavigateToFrame(Pages page)
        {
            if (mainFrame == null) { return; }
            mainFrame.Content = pages[(int)page];

        }
    }
}
