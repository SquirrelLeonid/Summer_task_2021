using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme.Links
{
    public class FalseLink : BaseLink 
    {
        public const string Text = "false";
        public FalseLink(BlockTemplate from, BlockTemplate to) : base(from, to)
        {
        }
    }
}
