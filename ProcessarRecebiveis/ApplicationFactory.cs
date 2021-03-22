using ProcessarRecebiveis.Log;
using ProcessarRecebiveis.Mensageria;
using ProcessarRecebiveis.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis
{
    public static class ApplicationFactory
    {
        public static ILog CreateLog()
        {
            //Buscar aqui qual a lib a ser usada.
            ILogBuilder logBuilder = new LogBuilderSerilog();
            var output = logBuilder.BuildLogger();
            return output;
        }
        public static IRepositorioBuilder CreateRepo()
        {
            //Buscar aqui qual a lib a ser usada.
            IRepositorioBuilder output = new RepositorioBuilderDynamo();
            return output;
        }

        //public static IMensagem CreateMensageria()
        //{
        //    IMensagem output = new 
        //}

    }
}
