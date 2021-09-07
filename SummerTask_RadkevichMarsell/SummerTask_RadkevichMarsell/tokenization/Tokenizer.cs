using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SummerTask_RadkevichMarsell.fileProcessing;
using SummerTask_RadkevichMarsell.tokenization.tokens;

namespace SummerTask_RadkevichMarsell.tokenization
{
    public class Tokenizer
    {
        private Dictionary<string, List<TokenRecord>> TokenizedMethods;

        public Tokenizer()
        {
            TokenizedMethods = new Dictionary<string, List<TokenRecord>>();
        }

        public Dictionary<string, List<TokenRecord>> Tokenize(List<MethodRecord> methods)
        {
            foreach (var method in methods)
                TokenizeMethod(method);               

            return TokenizedMethods;
        }

        private void TokenizeMethod(MethodRecord method)
        {
            var result = new List<TokenRecord>();
            var tokenStack = new Stack<TokenRecord>();

            var currentToken = (TokenRecord)(new StartEndToken(method.Name));

            result.Add(currentToken);

            for (int i = 1; i < method.Body.Count - 1; i++)
            {
                var line = method.Body[i];

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                else if (Regex.IsMatch(line, @"^\s*\{\s*$"))
                {
                    tokenStack.Push(currentToken);
                    continue;
                }

                else if (Regex.IsMatch(line, @"^\s*\}\s*$"))
                {
                    tokenStack.Pop();
                    continue;
                }

                //Проверка на цикл фор               
                else if (Regex.IsMatch(line, @"^\s+for\s*\(.*;.*;.*\)$"))
                {
                    var forStatement = Regex.Match(line, @"\s*\(.*;.*;.*\)$").Value.Trim();
                    forStatement = forStatement.Substring(1, forStatement.Length - 2);
                    var forParts = forStatement.Split(new char[] { ';' });

                    var initialization = forParts[0];
                    var condition = forParts[1] +"?";
                    var iteration = forParts[2];

                    currentToken = new ForToken(initialization, condition, iteration);                   
                }

                //Проверка на while
                else if (Regex.IsMatch(line, @"^\s+while\s*\(.*\)$"))
                {
                    var condition = GetConditionInBrackets(line);
                    currentToken = new WhileToken(condition);
                }

                //Проверка на if
                else if (Regex.IsMatch(line, @"^\s+if\s*\(.*\)$"))
                {
                    var condition = GetConditionInBrackets(line);
                    currentToken = new IfToken(condition + "?");
                }

                //Проверка на else
                else if (Regex.IsMatch(line, @"^\s+else\s*$"))
                    currentToken = new ElseToken();

                //Все остальное - операция
                else
                {
                    var text = line.Trim();
                    currentToken = new OperationToken(text.Substring(0,text.Length - 1));
                }

                if (!tokenStack.Any())
                    result.Add(currentToken);
                else
                    tokenStack.Peek().InnerTokens.Add(currentToken);
            }

            var endToken = new StartEndToken(method.Name);
            result.Add(endToken);

            TokenizedMethods.Add(method.Name, result);
        }

        private string GetConditionInBrackets(string line)
        {           
            var pattern = @"\s*\(.*\)$";
            var text = Regex.Match(line, pattern).Value.Trim();

            text = text.Substring(1, text.Length - 2);

            return text;
        }
    }
}
