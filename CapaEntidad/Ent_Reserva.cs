using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ent_Reserva
    {
        public int ID_RESERVA { get; set; }
        public string ORIGEN {  get; set; }
        public string DESTINO { get; set; }
        
        public int ID_CLIENTE { get; set; }
        public string CLI_NOMBRES { get; set; }
        public string DNI_cliente { get; set; }

        public int ID_SERVICIO { get; set; }
        public string NOMBRE_SERVICIO { get; set; }
        public double COSTO { get; set; }
        public int ID_PAGO { get; set; }
        public string METODO_PAGO { get; set; }

        public int ID_CONDUCTOR { get; set; }
        public string CON_NOMBRES { get; set; }

        public DateTime FECHA { get; set; }
        public string HORA { get; set; }

        
        
        
         
        
        

        public double MONTO { get; set; }


    }
}
