using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis.Log
{
    public class LogBuilderSerilog : ILogBuilder
    {
        public ILog BuildLogger()
        {
            //Para simplificar o exemplo esse builder é um factory, não será usada outras configurações.
            var output = new LogSerilog();
            return output;
        }
    }
}
