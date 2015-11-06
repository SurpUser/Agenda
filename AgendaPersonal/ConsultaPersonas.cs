using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace AgendaPersonal
{
    public partial class ConsultaPersonas : Form
    {
        Personas persona = new Personas();
        public ConsultaPersonas()
        {
            InitializeComponent();
        }

        private void ConsultaPersonas_Load(object sender, EventArgs e)
        {
            BuscarcomboBox.SelectedIndex = 0;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int Id = 0;
            bool resultado = Int32.TryParse(BuscartextBox.Text,out Id);

            if (BuscarcomboBox.Text == "Todos")
            {
                BuscardataGridView.DataSource = persona.Listado(" * ", " 1=1 ", "");
            }
            if (BuscarcomboBox.Text == "Por PeronaId")
            {
                BuscardataGridView.DataSource = persona.Listado(" * ", " PersonaId = " + Id, "");
            }

            else if (BuscardataGridView.RowCount == 0)
            {
                MessageBox.Show("Persona no Existe", "Error");
            }
            //BuscardataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Green;
        }
    }
}
