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
    public partial class Reservacion : Form
    {
        public Reservacion()
        {
            InitializeComponent();
            ListarReserva();
        }
        public void ListarReserva()
        {
            dataGridView2.DataSource= logReserva.Instancia.ListarReserva();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                Ent_Reserva c = new Ent_Reserva();
                c.ORIGEN = textBox2.Text.Trim();
                c.DESTINO = textBox9.Text.Trim();
                c.FECHA = Convert.ToDateTime(dateTimePicker1.Text.Trim());
                c.MONTO = Convert.ToDouble(txtmonto.Text.Trim());
                c.ID_CLIENTE = int.Parse(TXTIDCLI.Text.Trim());
                c.ID_CONDUCTOR = int.Parse(TXTIDCONDUCTOR.Text.Trim());

                c.ID_SERVICIO = int.Parse(TXTIDSERVICIO.Text.Trim());

                c.ID_PAGO = int.Parse(txtidpago.Text.Trim());

                c.HORA = txthoras.Text.Trim()+":"+txtminutos.Text.Trim();
                logReserva.Instancia.InsertarReserva(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                throw ex;
            }
            txtminutos.Text = "";
            txthoras.Text = "";
            txtidpago.Text = "";
            txtidreserva.Text = "";
            TXTIDCLI.Text = "";
            TXTIDCONDUCTOR.Text = "";

            MessageBox.Show("Registrado correctamente");
            ListarReserva();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow actual = dataGridView2.Rows[e.RowIndex];
            txtidreserva.Text = actual.Cells[0].Value.ToString();
            textBox2.Text = actual.Cells[1].Value.ToString();
            textBox4.Text = actual.Cells[2].Value.ToString();
            TXTIDCLI.Text = actual.Cells[3].Value.ToString();
            textBox7.Text = actual.Cells[4].Value.ToString();
            textBox8.Text = actual.Cells[5].Value.ToString();
            TXTIDSERVICIO.Text = actual.Cells[6].Value.ToString();
            comboBox1.Text = actual.Cells[7].Value.ToString();
           txtcostoServicio.Text = actual.Cells[8].Value.ToString();
            txtidpago.Text = actual.Cells[9].Value.ToString();
            COMBOMEDIOPAGO.Text = actual.Cells[10].Value.ToString();
            TXTIDCONDUCTOR.Text=actual.Cells[11].Value.ToString();
            textBox11.Text = actual.Cells[12].Value.ToString();
            dateTimePicker1.Text = actual.Cells[13].Value.ToString();
            txthoras.Text = actual.Cells[14].Value.ToString();
            txtmonto.Text = actual.Cells[15].Value.ToString();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Reservacion_Load(object sender, EventArgs e)
        {
            ListarServicioComboBox();
        }
        private void ListarServicioComboBox()
        {
            comboBox1.DataSource = logServicio.Instancia.ListarServicioComboBox();
            //comboBox1.DisplayMember ="NOMBRE";
            //comboBox1.ValueMember = "ID_SERVICIO";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
