using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell.blockScheme.blocks
{
    public class OperationBlock : BlockTemplate
    {
        public List<BlockTemplate> TopInput { get; }
        public BlockTemplate DownOutput { get; }

    }
}
