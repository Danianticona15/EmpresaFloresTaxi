using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogConductor
    {
        #region singleton 

        private static readonly LogConductor _instancia = new LogConductor();

        public static LogConductor Instancia
        {
            get
            {
                return LogConductor._instancia;
            }

        }
        #endregion singleton

        #region metodos

        public List<Ent_Conductor> ListarConductor()
        {

            return datConductor.Instancia.ListarConductor();
        }

        #endregion metodos
    }
}
