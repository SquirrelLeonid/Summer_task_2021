using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SummerTask_RadkevichMarsell.BlockTemplates
{
    public abstract class BlockTemplate
    {
        public BlockType Type { get; set; }
        public Size RectangleSize { get; set; }
        public string Content { get; set; }
    }
}
