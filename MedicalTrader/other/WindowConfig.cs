
using System.Windows;

namespace MedicalTrader.other
{
    public class WindowConfig
    {
        public string title { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public System.Windows.ResizeMode resizeMode { get; set; }

        public WindowConfig(string title, int width = 450, int height = 500, ResizeMode resizeMode = ResizeMode.CanResize)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.resizeMode = resizeMode;
        }

        public WindowConfig()
        {
        }
    }
}
