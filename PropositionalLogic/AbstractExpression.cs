using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropositionalLogic
{
    public abstract class AbstractExpression
    {
        public abstract void ParseFormel(List<char> formel);

        //Variablenliste wird beim Parsen befüllt
        public static List<char> variables = new List<char>();

        public abstract bool Interpret(Dictionary<char, bool> context);
    }
}
