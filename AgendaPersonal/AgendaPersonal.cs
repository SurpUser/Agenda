using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgendaPersonal
{
    public partial class AgendaPersonal : Form
    {
        public AgendaPersonal()
        {
            InitializeComponent();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPersonas registro = new RegistroPersonas();
            registro.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaPersonas consulta = new ConsultaPersonas();
            consulta.ShowDialog();
        }
    }
}
