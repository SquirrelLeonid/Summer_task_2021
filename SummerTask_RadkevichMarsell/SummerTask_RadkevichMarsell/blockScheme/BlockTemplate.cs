using System.Drawing;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public abstract class BlockTemplate
    {
        public BlockType Type { get; set; }
        public Size RectangleSize { get; set; }
        public string Content { get; set; }
    }
}
