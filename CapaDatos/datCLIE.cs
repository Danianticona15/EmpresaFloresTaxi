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
    public class datCLIE
    {
        #region sigleton
        
        private static readonly datCLIE _instancia = new datCLIE();
        
        public static datCLIE Instancia
        {
            get
            {
                return datCLIE._instancia;
            }
        }
        #endregion singleton
        public List<Ent_Cliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<Ent_Cliente> lista = new List<Ent_Cliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Cliente ent = new Ent_Cliente();
                    ent.Cliente = Convert.ToInt32(dr["ID_CLIENTE"]);
                    ent.Nombres = dr["NOMBRES_C"].ToString();
                    ent.Apellidos = dr["APELLIDOS"].ToString();
                    ent.Telefono = dr["TELEFONO"].ToString();
                    ent.Correo = dr["CORREO"].ToString();
                    ent.Direccion = dr["DIRECCION"].ToString();
                    ent.Dni = dr["DNI"].ToString();
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

        public Boolean InsertarCliente(Ent_Cliente cli) { 
        
        SqlCommand cmd = null;  
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("InsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Nombres", cli.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", cli.Apellidos);
                cmd.Parameters.AddWithValue("@Telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@Correo", cli.Correo);
                cmd.Parameters.AddWithValue("@Direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@DNI", cli.Dni);
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

        public Boolean EditarCliente(Ent_Cliente cli) {
            SqlCommand cmd = null;
            Boolean editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCLIENTE",cli.Cliente);
                cmd.Parameters.AddWithValue("@Nombres", cli.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", cli.Apellidos);
                cmd.Parameters.AddWithValue("@Telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@Correo", cli.Correo);
                cmd.Parameters.AddWithValue("@Direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@DNI", cli.Dni);
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
        public Boolean EliminarCliente(Ent_Cliente cli) {
            SqlCommand cmd= null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCLIENTE", cli.Cliente);
                
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
