using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPago
    {
        #region singleton 

        private static readonly logPago _instancia = new logPago();

        public static logPago Instancia
        {
            get
            {
                return logPago._instancia;
            }

        }
        #endregion singleton

        #region metodos

        public List<Ent_Pago> ListarPago()
        {

            return datPago.Instancia.ListarPago();
        }

        public void InsertarPago(Ent_Pago pgo)
        {

            datPago.Instancia.InsertarPago(pgo);
        }

        public void EditarPago(Ent_Pago pgo)
        {

            datPago.Instancia.EditarPago(pgo);
        }
        public void EliminarPago(Ent_Pago pgo)
        {

            datPago.Instancia.EliminarPago(pgo);
        }
        #endregion metodos
    }
}
