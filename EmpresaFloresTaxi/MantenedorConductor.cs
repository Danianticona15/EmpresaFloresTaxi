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

namespace EmpresaFloresTaxi
{
    public partial class C_Conductor : Form
    {
        public C_Conductor()
        {
            InitializeComponent();
            ListarConductor();
        }

        private void REGISTRAR_Click(object sender, EventArgs e)
        {

        }
        public void ListarConductor()
        {

            dataGridView1.DataSource = LogConductor.Instancia.ListarConductor();
        }
        private void C_Conductor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow actual = dataGridView1.Rows[e.RowIndex];
            textBox5.Text = actual.Cells[1].Value.ToString();
            textBox2.Text = actual.Cells[2].Value.ToString();
            textBox4.Text = actual.Cells[3].Value.ToString();
            textBox3.Text = actual.Cells[6].Value.ToString();
            textBox10.Text = actual.Cells[4].Value.ToString();
            textBox6.Text = actual.Cells[12].Value.ToString();
            textBox7.Text = actual.Cells[11].Value.ToString();
            textBox8.Text = actual.Cells[5].Value.ToString();
            textBox9.Text = actual.Cells[10].Value.ToString();
            textBox11.Text = actual.Cells[8].Value.ToString();
            textBox12.Text = actual.Cells[0].Value.ToString();

            dateTimePicker1.Text = actual.Cells[9].Value.ToString();


            textBox12.Enabled = false;
            textBox12.Visible = false;
        }
    }
}
