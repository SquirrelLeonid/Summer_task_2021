using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SummerTask_RadkevichMarsell.tokens;

namespace SummerTask_RadkevichMarsell
{
    public class Tokenizer
    {
        private int openBracketsCount = 0;
        public Dictionary<string, List<TokenRecord>> Tokenize(List<MethodRecord> methods)
        {
            var tokenizedMethods = new Dictionary<string, List<TokenRecord>>();

            foreach (var method in methods)
            {
                var methodTokens = new List<TokenRecord>();
                for (int i = 0; i < method.Body.Count; i++)
                {
                    var line = method.Body[i];

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    else if (Regex.IsMatch(line, @"^\s*\{\s*$"))
                    {
                        openBracketsCount++;
                        continue;
                    }

                    else if (Regex.IsMatch(line, @"^\s*\}\s*$"))
                    {
                        openBracketsCount--;
                        continue;
                    }

                    //Проверка на цикл фор               
                    else if (Regex.IsMatch(line, @"^\s+for\s*\(.*;.*;.*\)$"))
                    {
                        var match = Regex.Match(line, @"\s*\(.*;.*;.*\)$");
                        methodTokens.Add(
                            new TokenRecord(TokenType.ForStatement, match.Value.Trim(), openBracketsCount));
                        continue;
                    }

                    //Проверка на while
                    else if (Regex.IsMatch(line, @"^\s+while\s*\(.*\)$"))
                    {
                        var match = Regex.Match(line, @"\s*\(.*\)$");
                        methodTokens.Add(
                            new TokenRecord(TokenType.WhileStatement, match.Value.Trim(), openBracketsCount));
                        continue;
                    }

                    //Проверка на if
                    else if (Regex.IsMatch(line, @"^\s+if\s*\(.*\)$"))
                    {
                        var match = Regex.Match(line, @"\s*\(.*\)$");
                        methodTokens.Add(
                            new TokenRecord(TokenType.IfElseBranch, match.Value.Trim(), openBracketsCount));
                        continue;
                    }

                    //Проверка на else
                    //Не обсудил как обрабатывать конструкцию if else-if
                    else if (Regex.IsMatch(line, @"^\s+else\s*$"))
                    {
                        methodTokens.Add(
                            new TokenRecord(TokenType.IfElseBranch, string.Empty, openBracketsCount));
                        continue;
                    }

                    //Проверка на do
                    else if (Regex.IsMatch(line, @"^\s+do\s*"))
                    {
                        methodTokens.Add(
                            new TokenRecord(TokenType.DoWhileStatement, string.Empty, openBracketsCount));
                        continue;
                    }

                    else
                    {
                        methodTokens.Add(
                            new TokenRecord(TokenType.Operation, line.Trim(), openBracketsCount));
                        continue;
                    }
                }
                tokenizedMethods.Add(method.Name, methodTokens);
            }

            return tokenizedMethods;
        }
    }
}
