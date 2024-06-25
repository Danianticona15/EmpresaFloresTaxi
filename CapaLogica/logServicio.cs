using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logServicio
    {
        #region singleton 

        private static readonly logServicio _instancia = new logServicio();

        public static logServicio Instancia
        {
            get
            {
                return logServicio._instancia;
            }

        }
        #endregion singleton

        #region metodos

        public List<Ent_Servicio> ListarServicio()
        {

            return datServicio.Instancia.ListarServicio();
        }

        public void InsertarServicio (Ent_Servicio ser)
        {
            datServicio.Instancia.InsertarServicio(ser);
        }

        public void EditServicio(Ent_Servicio ser)
        {
            datServicio.Instancia.EditarServicio(ser);
        }

        public void ElimiServicio(Ent_Servicio ser)
        {
            datServicio.Instancia.EliminarServicio(ser);
        }

        public List<Ent_Servicio> ListarServicioComboBox( )
        {

            return datServicio.Instancia.ListarServicioComboBox( );
        }
        #endregion metodos
    }

}
