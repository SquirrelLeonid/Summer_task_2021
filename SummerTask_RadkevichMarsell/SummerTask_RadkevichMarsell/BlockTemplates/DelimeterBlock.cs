using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SummerTask_RadkevichMarsell.BlockTemplates
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
