using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmpresaFloresTaxi
{
    public partial class Pago : Form
    {
        public Pago()
        {
            InitializeComponent();
            ListarPago();
            textBox1.Enabled = false;
            textBox1.Visible = false;
        }

        public void ListarPago() { 
        
          dataGridView1.DataSource=          logPago.Instancia.ListarPago();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Pago c = new Ent_Pago();
                //c.ID_PAGO = int.Parse(textBox2.Text.Trim());
                c.METODO_PAGO = textBox2.Text.Trim();


                logPago.Instancia.InsertarPago(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox2.Text = "";
            

            MessageBox.Show("Registrado correctamente");
            ListarPago();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Pago c = new Ent_Pago();
                c.ID_PAGO= int.Parse(textBox1.Text.Trim());
                c.METODO_PAGO = textBox2.Text.Trim();
                
                logPago.Instancia.EditarPago(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            

            MessageBox.Show("Modificado correctamente");
            ListarPago();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Pago c = new Ent_Pago();
                c.ID_PAGO = int.Parse(textBox1.Text.Trim());

                logPago.Instancia.EliminarPago(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            

            MessageBox.Show("Eliminado correctamente");
            ListarPago();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow actual = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = actual.Cells[0].Value.ToString();
            textBox2.Text = actual.Cells[1].Value.ToString();
            

            textBox1.Enabled = false;
        }
    }
}
