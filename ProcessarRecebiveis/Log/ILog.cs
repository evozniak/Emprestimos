using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis.Log
{
    public interface ILog
    {
        public void Debug(string mensagem);
        public void Error(string mensagem);
        public void Verbose(string mensagem);
        public void Information(string mensagem);
        public void Fatal(string mensagem);
    }
}
