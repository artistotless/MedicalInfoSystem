using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    public delegate void Loading(string msg);

    public static class BackGroundEvents
    {
        public static event Loading OnShowLoading;
        public static event Loading OnHideLoading;
        private static int count = 0;

        public static void ShowLoading(string msg)
        {
            if (OnShowLoading != null)
            {
                count++;
                if (count > 0)
                {
                    OnShowLoading(msg);
                }
            }
        }

        public static void HideLoading()
        {
            if (OnHideLoading != null)
            {
                count--;
                if (count <= 0)
                {
                    OnHideLoading(string.Empty);
                }
            }
        }

    }
}
