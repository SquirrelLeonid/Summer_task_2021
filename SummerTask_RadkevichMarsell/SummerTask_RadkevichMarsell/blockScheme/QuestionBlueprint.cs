using System.Drawing;
using System.Windows.Forms;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class QuestionBlueprint : BlockBlueprint
    {
        private const int WIDTH_OFFSET = 20;
        private const int HEIGHT_OFFSET = 15;

        public QuestionBlueprint(BlockTemplate block) : base(block)
        {
            ConfigureBlueprint(block);
        }

        private void ConfigureBlueprint(BlockTemplate block)
        {
            BackColor = defaultBackColor;
            var textSizePixels = TextRenderer.MeasureText(block.Content, defaultFont);
            Size = new Size(textSizePixels.Width * 2 + WIDTH_OFFSET, textSizePixels.Height * 2 + HEIGHT_OFFSET);
            TopInput = new Point(Location.X + Width / 2, Location.Y);
            DownOutput = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height);
            LeftInput = new Point(Location.X, Location.Y + Size.Height / 2);
            RightOutput = new Point(Location.X + Size.Width, Location.Y + Size.Height / 2);
        }

        public override void Draw()
        {
            var bmp = new Bitmap(Size.Width, Size.Height);
            var graphics = Graphics.FromImage(bmp);
            Image = bmp;

            var textArea = new Label();
            ConfigureTextArea(textArea, Block.Content);

            int sideOffset = 2;

            var LeftPoint = new Point(sideOffset, Height / 2);
            var bottomPoint = new Point(Width / 2, Height - sideOffset);
            var rightPoint = new Point(Width - sideOffset, Height / 2);
            var topPoint = new Point(Width / 2, sideOffset);

            DrawRhomb(graphics, LeftPoint, bottomPoint, rightPoint, topPoint);
        }

        public override void SetLocation(int x, int y)
        {
            var oldLocation = Location;
            Location = new Point(x, y);

            DownOutput = new Point(
                Location.X + Width / 2,
                Location.Y + Height);

            TopInput = new Point(
                Location.X + Width / 2,
                Location.Y);

            LeftInput = new Point(
                Location.X,
                Location.Y + Height / 2);

            RightOutput = new Point(
                Location.X + Width,
                Location.Y + Height / 2);
        }

        public override void SetLocation(Point newLocation)
        {

            var oldLocation = Location;
            Location = newLocation;

            DownOutput = new Point(
                Location.X + Width / 2,
                Location.Y + Height);

            TopInput = new Point(
                Location.X + Width / 2,
                Location.Y);

            LeftInput = new Point(
                Location.X,
                Location.Y + Height / 2);

            RightOutput = new Point(
                Location.X + Width,
                Location.Y + Height / 2);
        }

        private void DrawRhomb(Graphics graphics, Point leftPoint, Point downPoint, Point rightPoint, Point topPoint)
        {
            graphics.DrawLine(defaultPen, leftPoint, downPoint);
            graphics.DrawLine(defaultPen, downPoint, rightPoint);
            graphics.DrawLine(defaultPen, rightPoint, topPoint);
            graphics.DrawLine(defaultPen, topPoint, leftPoint);
        }
    }
}
