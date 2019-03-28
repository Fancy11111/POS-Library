using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public class NegationExpression : AbstractExpression
    {
        private AbstractExpression next;
        public NegationExpression()
        {
        }

        public override bool Interpret(Dictionary<char, bool> context)
        {
            return !next.Interpret(context);
        }

        public override void ParseFormel(List<char> formel)
        {
            if (formel.First() != '!')
            {
                throw new Exception("Missing !");
            }
            else
            {
                formel.RemoveAt(0);
                if (formel.First() == '!')
                {
                    next = new NegationExpression();
                    next.ParseFormel(formel);
                }
                else if (formel.First() == '(')
                {
                    next = new BracketsExpression();
                    next.ParseFormel(formel);
                }
                else if (formel.First() > 'a' && formel.First() < 'z')
                {
                    next = new VariableExpression();
                    next.ParseFormel(formel);
                }
            }
        }
    }
}
