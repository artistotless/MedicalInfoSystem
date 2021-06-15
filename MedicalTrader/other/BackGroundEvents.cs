

namespace MedicalTrader
{
    public delegate void Loading(string msg);

    public static class BackGroundEvents
    {
        public static event Loading OnShowLoading;
        public static event Loading OnHideLoading;


        public static void ShowLoading(string msg)
        {
            if (OnShowLoading != null)
            {
                OnShowLoading(msg);
            }
        }

        public static void HideLoading()
        {
            if (OnHideLoading != null)
            {
                OnHideLoading(string.Empty);
            }
        }

    }
}
