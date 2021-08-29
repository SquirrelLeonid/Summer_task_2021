using System.Collections.Generic;

namespace SummerTask_RadkevichMarsell.fileProcessing
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
