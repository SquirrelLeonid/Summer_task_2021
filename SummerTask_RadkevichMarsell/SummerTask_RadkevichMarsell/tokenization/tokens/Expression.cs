using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class Expression
    {
        public string Text { get; set; }

        public Expression(string text)
        {
            Text = text;
        }
    }
}
