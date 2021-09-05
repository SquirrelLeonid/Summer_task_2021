using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell.blockScheme.blocks
{
    public class ConditionBlock : BlockTemplate
    {
        public List<BlockTemplate> TopInput { get; }
        public BlockTemplate LeftInput { get; }
        public BlockTemplate DownOutput { get; }
        public BlockTemplate RightOutput { get; }
        
        public ConditionBlock(string content)
        {
            Content = content;
            Type = BlockType.Question;
        }
    }
}
