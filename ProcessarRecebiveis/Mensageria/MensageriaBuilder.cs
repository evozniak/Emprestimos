using ProcessarRecebiveis.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Mensageria
{
    public class MensageriaBuilder : IMensageriaBuilder
    {
        protected MensagemEventHub mensagemEventHub;
        private string _ConnectionString { get; set; }
        private string _NomeHub { get; set; }
        private ILog _Log { get; set; }
        

        private MensageriaBuilder() { mensagemEventHub = new MensagemEventHub(_ConnectionString, _NomeHub, _Log); }
        public static MensageriaBuilder Create() => new MensageriaBuilder();

        public IMensageriaBuilder SetConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
            return this;
        }

        public IMensageriaBuilder SetNomeHub(string nomeHub)
        {
            _NomeHub = nomeHub;
            return this;
        }

        public IMensageriaBuilder SetLog(ILog log)
        {
            _Log = log;
            return this;
        }

        public IMensagem Build()
        {
            return mensagemEventHub;
        }

        //Para cada provider (Kinesis ou Event hub usar um extension method diferente). 
        //Essa classe seria o extension method do event hub.
    }
}
