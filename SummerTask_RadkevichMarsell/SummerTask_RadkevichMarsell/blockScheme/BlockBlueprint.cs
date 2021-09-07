using System.Windows.Forms;
using System;
using SummerTask_RadkevichMarsell.blockScheme.blocks;
using System.Drawing;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class BlockBlueprint : PictureBox
    {
        protected static readonly Font defaultFont = new Font(FontFamily.GenericSerif, 14);
        protected static readonly Color defaultBackColor = Color.Transparent;
        protected static readonly Pen defaultPen = new Pen(Color.Black, 2);

        public BlockTemplate Block { get; set; }
        public Point TopInput { get; set; } 
        public Point LeftInput { get; set; }
        public Point DownOutput { get; set; }
        public Point RightOutput { get; set; }

        protected BlockBlueprint(BlockTemplate block) : base()
        {
            Block = block;
        }

        public virtual void ConfigureTextArea(Label area, string text)
        {
            Controls.Add(area);
            area.AutoSize = true;
            area.Text = text;
            area.Font = defaultFont;

            int x = (Size.Width - area.Width) / 2;
            int y = (Size.Height - area.Height) / 2;
            area.Location = new Point(x, y);

            area.Visible = true;
        }

        public virtual void SetLocation(int x, int y)
        {
            throw new NotImplementedException();
        }

        public virtual void SetLocation(Point newLocation)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw()
        {
            throw new NotImplementedException();
        }       
    }
}
