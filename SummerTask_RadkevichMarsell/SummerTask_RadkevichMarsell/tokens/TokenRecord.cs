using SummerTask_RadkevichMarsell.tokens;

namespace SummerTask_RadkevichMarsell.tokens
{
    public class TokenRecord
    {
        public TokenType Type { get;}
        public string Value { get;}

        public int Level { get; }

        public TokenRecord(TokenType type, string value, int level)
        {
            Type = type;
            Value = value;
            Level = level;
        }

        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
