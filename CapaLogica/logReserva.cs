using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logReserva
    {
        #region singleton 

        private static readonly logReserva _instancia = new logReserva();

        public static logReserva Instancia
        {
            get
            {
                return logReserva._instancia;
            }

        }
        #endregion singleton

        #region metodos

        public List<Ent_Reserva> ListarReserva()
        {

            return datReserva.Instancia.ListarReserva();

        }
        public void InsertarReserva(Ent_Reserva cli)
        {

            datReserva.Instancia.InsertarReserva(cli);
        }

        public void EditarReserva(Ent_Reserva cli)
        {

            datReserva.Instancia.EditarReserva(cli);
        }
        public void EliminarReserva(Ent_Reserva cli)
        {

            datReserva.Instancia.EliminarReserva(cli);
        }
        #endregion metodos
    }
}

