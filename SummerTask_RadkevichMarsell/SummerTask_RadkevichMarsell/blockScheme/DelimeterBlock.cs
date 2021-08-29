using System.Drawing;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class DelimeterBlock : BlockTemplate
    {
        public DelimeterBlock(BlockType type, Size rectangleSize, string content)
        {
            Type = type;
            RectangleSize = rectangleSize;
            Content = content;
        }

    }
}
