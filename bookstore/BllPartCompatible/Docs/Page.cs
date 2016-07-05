using BllPartCompatible.Docs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace BllPartCompatible.Docs
{
    public class Page : IEnumerable<IToken>
    {
        private ICollection<IToken> tokens;

        public Page(params IToken[] tokens)
        {
            this.tokens = tokens;
        }

        public void AddToken(IToken token)
        {
            tokens.Add(token);
        }

        public IEnumerator<IToken> GetEnumerator()
        {
            return tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tokens.GetEnumerator();
        }

        public override string ToString()
        {
            string summary = "";

            foreach(IToken token in tokens) 
            {
                summary += token.ToHtml();
            }

            return summary;
        }
    }
}
