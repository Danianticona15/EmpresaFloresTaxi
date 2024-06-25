using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class datConductor
    {

        #region sigleton

        private static readonly datConductor _instancia = new datConductor();

        public static datConductor Instancia
        {
            get
            {
                return datConductor._instancia;
            }
        }
        #endregion singleton
        public List<Ent_Conductor> ListarConductor()
        {
            SqlCommand cmd = null;
            List<Ent_Conductor> lista = new List<Ent_Conductor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarConductores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Conductor conduc = new Ent_Conductor();
                    conduc.IDCONDUCTOR = Convert.ToInt32(dr["ID_CONDUCTOR"]);
                    conduc.Dni = dr["DNI"].ToString();
                    conduc.Nombres = dr["NOMBRES"].ToString();
                    conduc.Apellidos = dr["APELLIDOS"].ToString();
                    conduc.Telefono = dr["TELEFONO"].ToString();
                    conduc.Correo = dr["CORREO"].ToString();
                    conduc.Direccion = dr["DIRECCION"].ToString();
                    conduc.MARCAVEHICULO = dr["Marca_VEHICULO"].ToString();
                    conduc.AnioVehiculo = dr["ANIO_VEHICULO"].ToString();
                    conduc.ESTADO = dr["estado"].ToString();
                    conduc.ModeloVehiculo = dr["MODELO_VEHICULO"].ToString();
                    conduc.Placa = dr["PLACA"].ToString();
                    conduc.FECHA = Convert.ToDateTime(dr["FECHA_INGRESO"]);
                    
                    lista.Add(conduc);

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {

                cmd.Connection.Close();
            }
            return lista;
        }
    }

}
