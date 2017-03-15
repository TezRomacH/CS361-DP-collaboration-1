using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter.ConverterBuilders
{
    public abstract class ConverterBuilder
    {
        protected StringBuilder result;

        public ConverterBuilder Parse(string str)
        {
            result.Append(str); 

            return this;
        }

        public string Solve() => result.ToString();
    }

}
