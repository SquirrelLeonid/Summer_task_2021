
namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class IfToken : TokenRecord
    {
        public Expression Condition { get; set; }
        public IfToken (string text)
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
