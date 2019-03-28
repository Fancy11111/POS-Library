using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public class TermExpression : AbstractExpression
    {
        private AbstractExpression left;
        private AbstractExpression right;
        private char operation;
        public override bool Interpret(Dictionary<char, bool> context)
        {
            switch (operation)
            {
                case '&':
                    return left.Interpret(context) && right.Interpret(context);
                case '|':
                    return left.Interpret(context) || right.Interpret(context);
                case '=':
                    return left.Interpret(context) == right.Interpret(context);
                case '>':
                    if (left.Interpret(context) == right.Interpret(context))
                    {
                        return true;
                    }
                    else if (!left.Interpret(context))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return left.Interpret(context);
            }
        }

        public override void ParseFormel(List<char> formel)
        {
            if (formel.First() == '!')
            {
                left = new NegationExpression();
                left.ParseFormel(formel);
            }
            else if (formel.First() == '(')
            {
                left = new BracketsExpression();
                left.ParseFormel(formel);
            }
            else if (char.IsLetter(formel.First()))
            {
                left = new VariableExpression();
                left.ParseFormel(formel);
            }
            else
            {
                throw new ArgumentException("Unexpected Exception");
            }
            
            if (formel.Count > 0)
            {
                if (formel.First() == ')')
                {
                    return;
                }
                if (formel.First() != '&' && formel.First() != '|' && formel.First() != '=' && formel.First() != '>')
                {
                    throw new ArgumentException("Missing &, |, =, >");
                }

                operation = formel.First();
                formel.RemoveAt(0);
                right = new TermExpression();
                right.ParseFormel(formel);
            }
        }
    }
}
