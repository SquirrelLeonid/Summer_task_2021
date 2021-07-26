using SummerTask_RadkevichMarsell.fileReading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell
{
    class LineParser
    {
        public List<MethodRecord> ParseListings(List<Listing> listings)
        {
            var methods = new List<MethodRecord>();

            foreach (var listing in listings)
            {
                foreach (var line in listing.Content)
                {
                    //TODO: определить имя пространства имен
                    //TODO: определить имя класса
                    //TODO: определить имя метода (сейчас будет достаточно только имени метода, без сигнатуры и без возвращаемого типа
                    
                }
            }



            return methods;
        }
    }
}
