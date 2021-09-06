using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SummerTask_RadkevichMarsell.tokenization.tokens;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class SchemeArea
    {
        public PictureBox Canvas { get; private set; }
        private List<BlockBlueprint> Content;

        public SchemeArea(PictureBox canvas)
        {
            Canvas = canvas;
            Content = new List<BlockBlueprint>();
        }

        public void DrawBlocks(BlockTemplate[] blocks)
        {                
            Canvas.Refresh();
        }

        private Label CreateTextRectangle(string text)
        {
            var textRectangle = new Label();

            Canvas.Controls.Add(textRectangle);
            Content.Add(null);

            textRectangle.AutoSize = true;
            textRectangle.Text = text;
            textRectangle.Font = new Font(FontFamily.GenericSansSerif, 12);
            textRectangle.Location = new Point(100, 10 + (textRectangle.Height + 20) * Content.Count);
            textRectangle.BorderStyle = BorderStyle.FixedSingle;
            textRectangle.Visible = true;

            return textRectangle;
        }
    }
}
