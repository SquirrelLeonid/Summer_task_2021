using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme.Links
{
    public abstract class BaseLink
    {
        public BlockTemplate From { get; set; }
        public BlockTemplate To { get; set; }

        public BaseLink(BlockTemplate from, BlockTemplate to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return "From " + From.ToString() + " TO " + To.ToString();
        }
    }
}
