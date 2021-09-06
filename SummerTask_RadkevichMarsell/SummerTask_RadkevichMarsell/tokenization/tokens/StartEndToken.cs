
namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class StartEndToken : TokenRecord
    {
        public Expression Value { get; set; }
        public StartEndToken(string text)
        {
            Value = new Expression(text);
        }

        public override Expression GetFirstTokenExpression()
        {
            return Value;
        }

        public override Expression GetLastTokenExpression()
        {
            return Value;
        }
    }
}
