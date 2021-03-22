using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis.Log
{
    class LogSerilog : ILog
    {
        Serilog.Core.Logger _logger;
        public LogSerilog()
        {
            //violando OCP para simplicidade de logar em console.
            _logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateLogger();
        }

        public void Debug(string mensagem)
        {
            _logger.Debug(mensagem);
        }

        public void Error(string mensagem)
        {
            _logger.Error(mensagem);
        }

        public void Information(string mensagem)
        {
            _logger.Information(mensagem);
        }

        public void Verbose(string mensagem)
        {
            _logger.Verbose(mensagem);
        }

        public void Fatal(string mensagem)
        {
            _logger.Verbose(mensagem);
        }
    }
}
