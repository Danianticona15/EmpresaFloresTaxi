using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ent_Conductor
    {
        public int IDCONDUCTOR { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        
        public string ESTADO { get; set; }
        public string MARCAVEHICULO { get; set; }
        public DateTime FECHA { get; set; }
        public string AnioVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string Placa { get; set; }
    }
}
