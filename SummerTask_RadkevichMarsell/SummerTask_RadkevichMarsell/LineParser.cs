using SummerTask_RadkevichMarsell.fileReading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                var methodFullName = new StringBuilder();
                foreach (var line in listing.Content)
                {
                    if (line.Contains("namespace"))
                    {
                        var namespaceSplit = line.Split();
                        var namespaceName = namespaceSplit[1];
                        methodFullName.Append(namespaceName).Append("\\");
                        continue;
                    }

                    if (line.Contains("class"))
                    {
                        var classNameSplit = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var className = classNameSplit[classNameSplit.Length - 1];
                        methodFullName.Append(className).Append("\\");
                        continue;
                    }

                    if (IsMethodDeclaration(line))
                    {
                        string[] methodNameSplit = line.Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                        methodNameSplit = methodNameSplit[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        string methodName = methodNameSplit[methodNameSplit.Length - 1];
                        methodFullName.Append(methodName);
                    }              
                }

                methods.Add(new MethodRecord(methodFullName.ToString(), null));
            }
            return methods;
        }

        private bool IsClassDeclaration(string line)
        {
            if (line.Contains('"'))
                return false;

            //Шаблон для поиска ключевого слова class
            string pattern = @"\s+class\s+";
            return Regex.IsMatch(line, pattern);
        }
        private bool IsMethodDeclaration(string line)
        {
            //Шаблон на проверку того, что строка начинается с кавычки
            //Например " public static void main()"
            string pattern = @"^\s+\""+\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            //Шаблон на проверку, что строка не содержит директивы using
            pattern = @"\s+using\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            //шаблон на проверку, что строка не содержит if
            pattern = @"\s+if\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            //шаблон на проверку что строка не содержит while
            pattern = @"\s+while\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            //шаблон на проверку что строка не содержит foreach
            pattern = @"\s+foreach\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            //шаблон на проверку что строка не содержит catch
            pattern = @"\s+catch\s+";
            if (Regex.IsMatch(line, pattern))
                return false;

            if (line.Contains(';'))
                return false;

            //Шаблон для поиска объявления переменной с помощью var
            pattern = @"^\s*var [_*|\w*]*\s*=\s*";
            if (Regex.Matches(line, pattern).Count != 0)
                return false;

            //Шаблон для поиска объявления метода (с аргументами или без)
            //Пример: public static <T> TestMethod([args])
            //Где на месте [args] может быть любое количество аргументов, в том числе 0
            pattern = @"\s*\(.*\)$";
            if (!Regex.IsMatch(line, pattern))
                return false;

            //Шаблон для поиска ключевого слова void
            pattern = @"\s+void\s+";
            if (Regex.IsMatch(line, pattern))
                return true;

            return true;
        }
    }
}
