using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SummerTask_RadkevichMarsell.fileProcessing
{
    public class LineParser
    {
        private string currentNamespaceName;
        private string currentClassName;
        private string currentMethodName;

        public List<MethodRecord> ParseListings(List<Listing> listings)
        {
            var methods = new List<MethodRecord>();
            
            foreach (var listing in listings)
            {
                currentNamespaceName = "";
                currentClassName = "";
                var methodFullName = new StringBuilder();
                for (int i = 0; i < listing.Content.Count; i++)
                {
                    var line = listing.Content[i];

                    if (line.Contains("namespace "))
                    {
                        var namespaceSplit = line.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        currentNamespaceName = namespaceSplit[1] + "\\";
                        continue;
                    }

                    if (line.Contains(" class "))
                    {
                        var classNameSplit = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        currentClassName += classNameSplit[classNameSplit.Length - 1] + "\\";
                        continue;
                    }

                    if (IsMethodDeclaration(line))
                    {
                        string[] methodDeclarationSplit = line.Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                        string methodDeclarationLeftSide = methodDeclarationSplit[0];
                        string[] splitBeforeMethodArguments = methodDeclarationLeftSide.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        currentMethodName = splitBeforeMethodArguments[splitBeforeMethodArguments.Length - 1];

                        methodFullName.Append(currentNamespaceName).Append(currentClassName).Append(currentMethodName);

                        var methodBody = new List<string>();

                        var figureBracketsCount = 0;
                        i++;

                        while (true)
                        {
                            if (string.IsNullOrWhiteSpace(listing.Content[i]))
                            {
                                i++;
                                continue;
                            }

                            line = listing.Content[i];

                            if (line.Contains("{"))
                                figureBracketsCount++;
                            if (line.Contains("}"))
                                figureBracketsCount--;

                            methodBody.Add(line);
                            i++;
                            if (figureBracketsCount == 0)
                                break;
                        }

                        methods.Add(new MethodRecord(methodFullName.ToString(), methodBody));
                        methodFullName.Clear();
                    }              
                }
            }
            return methods;
        }

        private bool IsMethodDeclaration(string line)
        {
            //Шаблон для поиска ключевого слова void
            string pattern = @"\s+void\s+";
            if (Regex.IsMatch(line, pattern))
                return true;

            //Шаблон для поиска объявления метода (с аргументами или без)
            //Пример: public static <T> TestMethod([args])
            //Где на месте [args] может быть любое количество аргументов, в том числе 0
            pattern = @"\s*\(.*\)$";
            if (Regex.IsMatch(line, pattern))
                return true;

            //Шаблон на проверку того, что строка начинается с кавычки
            //Например " public static void main()"
            pattern = @"^\s+\""+\s+";
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
           
            return false;
        }
    }
}
