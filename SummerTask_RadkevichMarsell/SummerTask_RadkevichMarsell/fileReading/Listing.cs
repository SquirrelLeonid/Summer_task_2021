using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell.fileReading
{
    public class Listing
    {
        public string Name { get; }
        public List<string> Content { get; }

        public Listing(string name, List<string> content)
        {
            Name = name;
            Content = content;
        }
    }
}
