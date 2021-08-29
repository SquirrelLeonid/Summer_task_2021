using System.Drawing;
using System.Windows.Forms;

namespace SummerTask_RadkevichMarsell.UI
{
    public class MethodTab : Button
    {
        private const int defaultWidth = 187;
        private const int defaultHeight = 40;
        private const int defaultFontSize = 10;
        private const int defaultOffsetX = 3;
        private const int defaultOffsetY = 3;
        private readonly string defaultNamePrefix = "Button_Tab_";

        public static int TabCounter { get; private set; }

        public MethodTab(string methodName)
        {
            InitializeFields(methodName);
            TabCounter++;
        }

        private void InitializeFields(string methodName)
        {
            Name = defaultNamePrefix + methodName;
            Text = methodName;
            Font = new Font(FontFamily.GenericMonospace, defaultFontSize);
            BackColor = Color.White;
            Size = new Size(defaultWidth, defaultHeight);
            Location = new Point(defaultOffsetX, defaultOffsetY + Height * TabCounter);
        }

        protected override void Dispose(bool disposing)
        {
            TabCounter--;
            base.Dispose(disposing);
        }

    }
}
