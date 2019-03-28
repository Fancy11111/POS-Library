using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public class TableEntry
    {
        Dictionary<char, bool> variables;
        AbstractExpression parser;

        public TableEntry(Dictionary<char, bool> variables, AbstractExpression parser)
        {
            this.variables = variables;
            this.parser = parser;
        }

        public String Variables
        {
            get
            {
                String text = "";
                foreach (char c in variables.Keys)
                {
                    text += c + ": " + variables[c] + "; ";
                }

                return text.Substring(0, text.Length - 2);
            }
        }

        public bool Result
        {
            get
            {
                return parser.Interpret(this.variables);
            }
        }
    }
}
