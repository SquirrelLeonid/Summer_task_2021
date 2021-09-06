
namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public class ForToken : TokenRecord
    {
        public Expression Initialization { get; set; }
        public Expression Condition { get; set; }
        public Expression Iteration { get; set; }
        public ForToken(string initialization, string condition, string iteration)
        {
            Initialization = new Expression(initialization);
            Condition = new Expression(condition);
            Iteration = new Expression(iteration);
        }

        public override Expression GetFirstTokenExpression()
        {
            return Initialization;
        }

        public override Expression GetLastTokenExpression()
        {
            return Iteration;
        }
    }
}
