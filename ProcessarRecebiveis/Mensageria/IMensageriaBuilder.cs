using ProcessarRecebiveis.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Mensageria
{
    public interface IMensageriaBuilder
    {
        //protected string _ConnectionString { get; set; }
        //protected string _NomeHub { get; set; }
        //protected ILog _Log { get; set; }

        public IMensageriaBuilder SetConnectionString(string connectionString);
        public IMensageriaBuilder SetNomeHub(string nomeHub);
        public IMensageriaBuilder SetLog(ILog log);
        public IMensagem Build();
    }
}
