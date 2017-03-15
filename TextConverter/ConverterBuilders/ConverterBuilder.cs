using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter.ConverterBuilders
{
    public abstract class ConverterBuilder
    {
        protected StringBuilder result;

        public virtual ConverterBuilder Parse(string str)
        {
            result.Append(str);

            return this;
        }

        public virtual string Solve() => result.ToString();

        public virtual string GetExtension() => ".txt";
    }

}
