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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace EmpresaFloresTaxi
{
    public partial class R_TipoServicio : Form
    {
        public R_TipoServicio()
        {
            InitializeComponent();
            ListarServicio();
            txtservicio.Enabled = false;
            txtservicio.Visible = false;
        }

        public void ListarServicio() {

            dataGridView1.DataSource = logServicio.Instancia.ListarServicio();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Servicio c = new Ent_Servicio();
                c.NOMBRES = textBox1.Text.Trim();
                c.Descripcion = textBox2.Text.Trim();
                c.Costo = Convert.ToDouble(textBox3.Text.Trim());

                logServicio.Instancia.InsertarServicio(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtservicio.Text = "";

            MessageBox.Show("Registrado correctamente");
            ListarServicio();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Servicio c = new Ent_Servicio();
                c.IDSERVICIO=int.Parse(txtservicio.Text.Trim());
                c.NOMBRES=textBox1.Text.Trim();
                c.Descripcion=textBox2.Text.Trim();
                c.Costo= Convert.ToDouble(textBox3.Text.Trim());
                logServicio.Instancia.EditServicio(c);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtservicio.Text = "";

            MessageBox.Show("Modificado correctamente");
            ListarServicio();

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Ent_Servicio c = new Ent_Servicio();
                c.IDSERVICIO = int.Parse(txtservicio.Text.Trim());
                
                logServicio.Instancia.ElimiServicio(c);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtservicio.Text = "";

            MessageBox.Show("Eliminado correctamente");
            ListarServicio();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow actual = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = actual.Cells[1].Value.ToString();
            textBox2.Text = actual.Cells[2].Value.ToString();
            textBox3.Text = actual.Cells[3].Value.ToString();
            txtservicio.Text =actual.Cells[0].Value.ToString();
            

            
        }

        private void R_TipoServicio_Load(object sender, EventArgs e)
        {

        }
    }
}
