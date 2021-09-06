
namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class ElseToken : TokenRecord
    {
        public ElseToken()
        {
        }

        public override Expression GetFirstTokenExpression()
        {
            return InnerTokens[0].GetFirstTokenExpression();
        }

        public override Expression GetLastTokenExpression()
        {
            return InnerTokens[InnerTokens.Count - 1].GetLastTokenExpression();
        }
    }
}
