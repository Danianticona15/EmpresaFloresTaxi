using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaFloresTaxi
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void rEGISTROCLIENTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MantenedorC cliente = new MantenedorC();
            cliente.Show();
        }

        private void rEGISTRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C_Conductor conductor = new C_Conductor();
            conductor.Show();   
        }

        private void rEGISTRARSERVICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R_TipoServicio cn=new R_TipoServicio();
            cn.Show();
        }

        private void rEGISTRARPAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pago PGO=new Pago();
            PGO.Show();
        }

        private void rEGISTRARRESERVACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservacion rs=new Reservacion();  
            rs.Show();
        }
    }
}
