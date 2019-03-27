using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public class VariableExpression : AbstractExpression
    {
        private char varName;
        public override bool Interpret(Dictionary<char, bool> context)
        {
            return context[varName];
        }

        public override void ParseFormel(List<char> formel)
        {
            if (formel.First() < 'a' || formel.First() > 'z'){
                throw new Exception("Variable must be between a and z");
            }
            else
            {
                varName = formel.First();
                if (!AbstractExpression.variables.Contains(varName))
                {
                    AbstractExpression.variables.Add(varName);
                }
                formel.RemoveAt(0);
            }
            
        }
    }
}
