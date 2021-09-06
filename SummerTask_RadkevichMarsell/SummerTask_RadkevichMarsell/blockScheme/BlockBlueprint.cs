using System.Windows.Forms;
using System.Drawing;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class BlockBlueprint
    {
        public Point BlueprintLocation { get; }
        public int BlueprintWidth { get; }
        public int BlueprintHeight { get; }

        public Label TextRectangle { get; }
        public BlockTemplate Block { get; }

        public BlockBlueprint (BlockTemplate block)
        {
            Block = block;
            TextRectangle = CreateRectangleFromText(Block.Content);
        }

        private Label CreateRectangleFromText(string content)
        {
            var rectangle = new Label();

            rectangle.AutoSize = true;
            rectangle.Enabled = true;
            rectangle.BackColor = Color.White;
            rectangle.Text = content;          

            return rectangle;
        }
    }
}
