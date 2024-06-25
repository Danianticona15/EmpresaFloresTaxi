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
    public class datPago
    {
        #region sigleton

        private static readonly datPago _instancia = new datPago();

        public static datPago Instancia
        {
            get
            {
                return datPago._instancia;
            }
        }
        #endregion singleton
        public List<Ent_Pago> ListarPago()
        {
            SqlCommand cmd = null;
            List<Ent_Pago> lista = new List<Ent_Pago>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarMetodosPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ent_Pago ent = new Ent_Pago();
                    ent.ID_PAGO = Convert.ToInt32(dr["ID_PAGO"]);
                    ent.METODO_PAGO = dr["METODO_PAGO"].ToString();
                    
                    
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

        public Boolean InsertarPago(Ent_Pago pgo)
        {

            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("InsertarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@METODOPAGO",pgo.METODO_PAGO);
                
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

        public Boolean EditarPago(Ent_Pago pgo)
        {
            SqlCommand cmd = null;
            Boolean editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EditarMetodoPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPAGO", pgo.ID_PAGO);
                cmd.Parameters.AddWithValue("@METODOPAGO", pgo.METODO_PAGO);
                
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
        public Boolean EliminarPago(Ent_Pago pgo)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();

                cmd = new SqlCommand("EliminarMetodoPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPAGO", pgo.ID_PAGO);

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
