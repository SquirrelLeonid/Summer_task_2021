using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell
{
    class MethodRecord
    {
        public string Name { get; }
        public List<string> Body { get; }
        public MethodRecord(string name, List<string> body)
        {
            Name = name;
            Body = body;
        }
    }
}
