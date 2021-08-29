using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SummerTask_RadkevichMarsell
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
            this.Name = defaultNamePrefix + methodName;
            this.Text = methodName;
            this.Font = new Font(FontFamily.GenericMonospace, defaultFontSize);
            this.BackColor = Color.White;
            this.Size = new Size(defaultWidth, defaultHeight);
            this.Location = new Point(defaultOffsetX, defaultOffsetY + this.Height * TabCounter);

            TabCounter++;
        }

        protected override void Dispose(bool disposing)
        {
            TabCounter--;
            base.Dispose(disposing);
        }
    }
}
