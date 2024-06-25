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
    public class datServicio
    {
        #region sigleton

        private static readonly datServicio _instancia = new datServicio();

        public static datServicio Instancia
        {
            get
            {
                return datServicio._instancia;
            }
        }
        #endregion singleton

        public List<Ent_Servicio> ListarServicio()
        {
            SqlCommand cmd = null;
            List<Ent_Servicio> lista = new List<Ent_Servicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Servicio ent = new Ent_Servicio();
                    ent.IDSERVICIO = Convert.ToInt32(dr["ID_SERVICIO"]);
                    ent.NOMBRES = dr["NOMBRE"].ToString();
                    ent.Descripcion = dr["DESCRIPCION"].ToString();
                    ent.Costo = Convert.ToDouble(dr["COSTO"]);
                    
                    lista.Add(ent);

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

        public List<Ent_Servicio> ListarServicioComboBox()
        {
            SqlCommand cmd = null;
            List<Ent_Servicio> lista = new List<Ent_Servicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("TIPO_SERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Servicio ent = new Ent_Servicio();
                    ent.IDSERVICIO = Convert.ToInt32(dr["ID_SERVICIO"]);
                    ent.NOMBRES = dr["NOMBRE"].ToString();
                    /*cmd.Parameters.AddWithValue("ID_SERVICIO",ent.IDSERVICIO);
                    cmd.Parameters.AddWithValue("NOMBRE", ent.NOMBRES);
                    cmd.Parameters.AddWithValue("COSTO", ent.Costo);
                    */

                   // ent.Costo = Convert.ToDouble(dr["COSTO"]);

                    lista.Add(ent);

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
            public Boolean InsertarServicio(Ent_Servicio cli)
        {

            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("InsertarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", cli.NOMBRES);
                cmd.Parameters.AddWithValue("@Descripcion", cli.Descripcion);
                cmd.Parameters.AddWithValue("@costo", cli.Costo);
                
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { cmd.Connection.Close(); }

            return inserta;
        }

        public Boolean EditarServicio(Ent_Servicio cli)
        {
            SqlCommand cmd = null;
            Boolean editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EditarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDSERVICIO", cli.IDSERVICIO);
                cmd.Parameters.AddWithValue("@NOMBRE", cli.NOMBRES);
                cmd.Parameters.AddWithValue("@Descripcion", cli.Descripcion);
                cmd.Parameters.AddWithValue("@costo", cli.Costo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    editar = true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { cmd.Connection.Close(); }

            return editar;
        }

        public Boolean EliminarServicio(Ent_Servicio cli)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EliminarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDSERVICIO", cli.IDSERVICIO);
                

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminar = true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { cmd.Connection.Close(); }


            return eliminar;
        }
    }
}
