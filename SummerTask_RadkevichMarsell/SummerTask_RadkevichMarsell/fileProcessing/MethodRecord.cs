using System.Collections.Generic;

namespace SummerTask_RadkevichMarsell.fileProcessing
{
    public class MethodRecord
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
