using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis.Log
{
    public interface ILogBuilder
    {
        public ILog BuildLogger();
    }
}
