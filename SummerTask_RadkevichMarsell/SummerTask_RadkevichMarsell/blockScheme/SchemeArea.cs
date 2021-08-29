using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SummerTask_RadkevichMarsell.tokenization;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class SchemeArea
    {
        public PictureBox Canvas { get; private set; }
        private readonly Font defaultFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
        private readonly Brush defaultBrush = new SolidBrush(Color.Black);
        private readonly StringFormat defaultStringFormat = new StringFormat();
        private readonly Pen defaultPen = new Pen(Color.Black, 1);

        public SchemeArea(PictureBox canvas)
        {
            Canvas = canvas;            
        }

        public void DrawBlocks(List<TokenRecord> methodTokens)
        {
            foreach (var token in methodTokens)
            {
                switch (token.Type)
                {
                    case TokenType.Operation:
                        DrawOperationBlock(token);
                        break;
                    default:
                        break;
                }
            }
            Canvas.Refresh();
        }

        private void DrawOperationBlock(TokenRecord token)
        {
            using (var graphics = Graphics.FromImage(Canvas.Image))
            {
                var content = token.Value;
                var contentSize = TextRenderer.MeasureText(content, defaultFont);
                float x = 100;
                float y = 100;
                graphics.DrawString(content, defaultFont, Brushes.Black, x, y, defaultStringFormat);
            }
        }

    }
}
