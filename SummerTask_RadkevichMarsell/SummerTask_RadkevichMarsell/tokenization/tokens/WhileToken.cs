
namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class WhileToken : TokenRecord
    {
        public Expression Condition { get; set; }
        public WhileToken(string text)
        {
            Condition = new Expression(text);
        }

        public override Expression GetFirstTokenExpression()
        {
            return Condition;
        }

        public override Expression GetLastTokenExpression()
        {
            return InnerTokens[InnerTokens.Count - 1].GetLastTokenExpression();
        }
    }
}
