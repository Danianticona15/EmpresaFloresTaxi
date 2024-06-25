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
using CapaEntidad;
using System.Xml.Linq;

namespace EmpresaFloresTaxi
{
    public partial class MantenedorC : Form
    {
        public MantenedorC()
        {
            InitializeComponent();
            ListarClientes();
        }
        public void ListarClientes()
        {

            dataGridView1.DataSource = logCliente.Instancia.ListarCliente();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Cliente c=new Ent_Cliente();
                c.Dni=textBox1.Text.Trim();
                c.Nombres=text2.Text.Trim();
                c.Apellidos=text3.Text.Trim();
                c.Telefono=textBox4.Text.Trim();
                c.Direccion=text5.Text.Trim();
                c.Correo=textBox6.Text.Trim();
                logCliente.Instancia.InsertarCliente(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text ="";
            text2.Text = "";
            text3.Text = "";
            textBox4.Text = "";
                text5.Text = "";
             textBox6.Text = "";
            
            MessageBox.Show("Registrado correctamente");
            ListarClientes();
            textBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Cliente c = new Ent_Cliente();
                c.Dni = textBox1.Text.Trim();
                c.Nombres = text2.Text.Trim();
                c.Apellidos = text3.Text.Trim();
                c.Telefono = textBox4.Text.Trim();
                c.Direccion = text5.Text.Trim();
                c.Correo = textBox6.Text.Trim();
                c.Cliente=int.Parse(txt7.Text.Trim());
                logCliente.Instancia.EditarCliente(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            text2.Text = "";
            text3.Text = "";
            textBox4.Text = "";
            text5.Text = "";
            textBox6.Text = "";
            txt7.Text =   "";

            MessageBox.Show("Modificado correctamente");
            ListarClientes();
            textBox1.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow actual = dataGridView1.Rows[e.RowIndex];
            text2.Text = actual.Cells[1].Value.ToString();
            text3.Text=  actual.Cells[2].Value.ToString();
            textBox4.Text=actual.Cells[3].Value.ToString();
            text5.Text= actual.Cells[5].Value.ToString();
            textBox6.Text=actual.Cells[4].Value.ToString();
            textBox1.Text = actual.Cells[6].Value.ToString();
            txt7.Text=actual.Cells[0].Value.ToString();

            textBox1.Enabled = false;
        }

        private void MantenedorC_Load(object sender, EventArgs e)
        {
            txt7.Enabled=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Cliente c = new Ent_Cliente();
                c.Cliente = int.Parse(txt7.Text.Trim());
                
                logCliente.Instancia.EliminarCliente(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            text2.Text = "";
            text3.Text = "";
            textBox4.Text = "";
            text5.Text = "";
            textBox6.Text = "";
            txt7.Text = "";

            MessageBox.Show("Eliminado correctamente");
            ListarClientes();
            textBox1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
