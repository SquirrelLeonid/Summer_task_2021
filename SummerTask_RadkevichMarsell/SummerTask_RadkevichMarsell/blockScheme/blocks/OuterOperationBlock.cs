using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell.blockScheme.blocks
{
    public class OuterOperationBlock : OperationBlock
    {
        public OuterOperationBlock(string content)
        {
            Content = content;
            Type = BlockType.OuterOperation;
        }
    }
}
