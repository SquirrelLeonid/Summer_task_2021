using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SummerTask_RadkevichMarsell
{
    public class TagPlacementor
    {
        public List<MethodRecord> PlacementTags(List<MethodRecord> methods)
        {

            foreach (var method in methods)
            {
                for (int i = 0; i < method.Body.Count; i++)
                {
                    var line = method.Body[i];

                    //Проверка на цикл фор
                    if (Regex.IsMatch(line, @"\s+for\s*\("))
                    {

                    }

                    //Проверка на условие if
                    else if (Regex.IsMatch(line, @"\s+if\s*\("))
                    {

                    }

                    //Проверка на else
                    //Не обсудил как обрабатывать конструкцию if else-if
                    else if (Regex.IsMatch(line, @"\s+else\s*"))
                    {

                    }

                    //Проверка на while
                    else if (Regex.IsMatch(line, @"\s+while\s*\("))
                    {

                    }

                    //Проверка на do
                    else if (Regex.IsMatch(line, @"\s+do\s*"))
                    {

                    }

                    //Проверка на {
                    else if (Regex.IsMatch(line, @"\s+\{\s*$"))
                    {
                        method.Body.Insert(i+1, "<body>");
                        i++;
                    }

                    //Проверка на }
                    else if (Regex.IsMatch(line, @"\s+\}\s*$"))
                    {
                        method.Body.Insert(i, "</body>");
                        i++;
                    }

                    else
                        continue;
                }
            }


            return methods;
        }
    }
}
