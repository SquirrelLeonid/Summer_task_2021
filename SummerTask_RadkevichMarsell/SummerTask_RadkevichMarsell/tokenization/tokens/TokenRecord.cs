using System.Collections.Generic;
using System;

namespace SummerTask_RadkevichMarsell.tokenization.tokens
{
    public abstract class TokenRecord
    {
        public List<TokenRecord> InnerTokens { get; set; } = new List<TokenRecord>();
        
        public virtual Expression GetFirstTokenExpression()
        {
            throw new NotImplementedException();
        }

        public virtual Expression GetLastTokenExpression()
        {
            throw new NotImplementedException();
        }

    }
}
