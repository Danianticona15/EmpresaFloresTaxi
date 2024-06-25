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
    public class datReserva
    {
        #region sigleton

        private static readonly datReserva _instancia = new datReserva();

        public static datReserva Instancia
        {
            get
            {
                return datReserva._instancia;
            }
        }
        #endregion singleton
        public List<Ent_Reserva> ListarReserva()
        {
            SqlCommand cmd = null;
            List<Ent_Reserva> lista = new List<Ent_Reserva>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Reserva ent = new Ent_Reserva();
                    ent.ID_RESERVA = Convert.ToInt32(dr["ID_RESERVA"]);
                    ent.ORIGEN = dr["ORIGEN"].ToString();
                    ent.DESTINO = dr["DESTINO"].ToString();
                    ent.FECHA = Convert.ToDateTime(dr["FECHA_RESERVA"].ToString());
                    ent.HORA = dr["HORA"].ToString();
                    
                    ent.ID_CLIENTE = Convert.ToInt32(dr["ID_CLIENTE"].ToString());
                    ent.DNI_cliente = dr["DNI"].ToString();
                    ent.CLI_NOMBRES =  dr["NOMBRES_C"].ToString();
                    
                    ent.ID_CONDUCTOR = Convert.ToInt32(dr["ID_CONDUCTOR"].ToString());
                    ent.CON_NOMBRES = dr["NOMBRES"].ToString();

                    ent.ID_SERVICIO = Convert.ToInt32(dr["ID_SERVICIO"].ToString());
                    ent.NOMBRE_SERVICIO = dr["NOMBRE"].ToString();
                    ent.COSTO = Convert.ToDouble(dr["COSTO"].ToString());

                    ent.ID_PAGO = Convert.ToInt32(dr["ID_PAGO"].ToString());
                    ent.METODO_PAGO = dr["METODO_PAGO"].ToString();
                    

                    ent.MONTO = Convert.ToDouble(dr["MONTO"].ToString());


                    
                    
                    

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
        
        public Boolean InsertarReserva(Ent_Reserva cli)
        {

            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("InsertarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ORIGEN", cli.ORIGEN);
                cmd.Parameters.AddWithValue("@DESTINO", cli.DESTINO);
                cmd.Parameters.AddWithValue("@FECHA_RESERVA", cli.FECHA);
                cmd.Parameters.AddWithValue("@MONTO", cli.MONTO);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", cli.ID_CLIENTE);
                cmd.Parameters.AddWithValue("@ID_CONDUCTOR", cli.ID_CONDUCTOR);

                cmd.Parameters.AddWithValue("@ID_SERVICIO", cli.ID_SERVICIO);

                cmd.Parameters.AddWithValue("@ID_PAGO", cli.ID_PAGO);

                cmd.Parameters.AddWithValue("@HORA", cli.HORA);

                cmd.Parameters.AddWithValue("@ID_CONDUCTOR", cli.ID_CONDUCTOR);

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
        
        public Boolean EditarReserva(Ent_Reserva cli)
        {
            SqlCommand cmd = null;
            Boolean editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EditarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_RESERVA", cli.ID_RESERVA);
                cmd.Parameters.AddWithValue("@ORIGEN", cli.ORIGEN);
                cmd.Parameters.AddWithValue("@DESTINO", cli.DESTINO);
                cmd.Parameters.AddWithValue("@FECHA_RESERVA", cli.FECHA);
                cmd.Parameters.AddWithValue("@MONTO", cli.MONTO);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", cli.ID_CLIENTE);
                cmd.Parameters.AddWithValue("ID_CONDUCTOR", cli.ID_CONDUCTOR);
                cmd.Parameters.AddWithValue("@ID_SERVICIO", cli.ID_SERVICIO);
                cmd.Parameters.AddWithValue("ID_PAGO", cli.ID_PAGO);
                cmd.Parameters.AddWithValue("HORA", cli.HORA);

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
        public Boolean EliminarReserva(Ent_Reserva cli)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EliminarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_RESERVA", cli.ID_RESERVA);

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

