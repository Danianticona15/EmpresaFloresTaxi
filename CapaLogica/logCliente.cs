using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logCliente
    {
        #region singleton 

        private static readonly logCliente _instancia = new logCliente();

        public static logCliente Instancia
        {
            get
            {
                return logCliente._instancia;
            }

        }
        #endregion singleton

        #region metodos

        public List<Ent_Cliente> ListarCliente() {

            return datCLIE.Instancia.ListarCliente();
        }

        public void InsertarCliente(Ent_Cliente cli) {
        
            datCLIE.Instancia.InsertarCliente(cli);
        }

        public void EditarCliente(Ent_Cliente cli) {

            datCLIE.Instancia.EditarCliente(cli);
        }
        public void EliminarCliente(Ent_Cliente cli)
        { 
        
            datCLIE.Instancia.EliminarCliente(cli);
        }
        #endregion metodos
    }

}
