using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public class BracketsExpression : AbstractExpression
    {
        private AbstractExpression next;
        public override bool Interpret(Dictionary<char, bool> context)
        {
            return next.Interpret(context);
        }

        public override void ParseFormel(List<char> formel)
        {
            if (formel.First() == '(')
            {
                next = new TermExpression();
                formel.RemoveAt(0);
                next.ParseFormel(formel);
                if (formel.First() != ')')
                {
                    throw new Exception("Missing )");
                }
            }
            else
            {
                throw new ArgumentException("Unexpected Exception");
            }
            
        }
    }
}
