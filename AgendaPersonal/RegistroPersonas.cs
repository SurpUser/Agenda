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
    public partial class RegistroPersonas : Form
    {
        Personas persona = new Personas();

        public RegistroPersonas()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            PersonaIdtextBox.Clear();
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            TelefonoslistBox.Items.Clear();
            MasculinoradioButton.Checked = true;
            CasadoradioButton.Checked = true;
        }

        public bool Guardar()
        {
            try
            {
                if (NombretextBox.Text.Length > 0 && DirecciontextBox.Text.Length > 0)
                {
                    persona.Nombre = NombretextBox.Text;
                    persona.Direccion = DirecciontextBox.Text;
                    if (MasculinoradioButton.Checked)
                    {
                        persona.sexo = 1;
                    }
                    else
                    {
                        persona.sexo = 0;
                    }

                    if (CasadoradioButton.Checked)
                    {
                        persona.EstadoCivil = 1;
                    }
                    else
                    {
                        persona.EstadoCivil = 0;
                    }

                    persona.LimpiarList();
                    for (int i = 0; i < TelefonoslistBox.Items.Count; i++)
                    {
                        persona.AgregarTelefonos(1,TelefonoslistBox.Items[i].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos");
                }

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            try
            {

                Guardar();
                if (PersonaIdtextBox.Text.Length > 0)
                {
                    int Id = 0;
                    bool resultado = Int32.TryParse(PersonaIdtextBox.Text, out Id);
                    persona.PersonaId = Id;
                    if (persona.Editar())
                    {
                        MessageBox.Show("Editado Correctamente","Correcto");
                    }
                    else
                    {
                        MessageBox.Show("Error al Editar","Error");
                    }

                }
                else
                {
                    if (persona.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al Guardar", "Error");
                    }
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Error inesperado","Error"); ;
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = 0;
                bool resultado = Int32.TryParse(PersonaIdtextBox.Text,out Id);
                persona.PersonaId = Id;
                if (persona.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente");
                    Limpiar();
                }
                /*else
                {
                    MessageBox.Show("Error al Eliminar");
                }*/ 
            }
            catch (Exception)
            {

                MessageBox.Show("Error al Eliminar");
            }
        }


        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            TelefonoslistBox.Items.Add(TelefonotextBox.Text);
            TelefonotextBox.Clear();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
             try
            {
                int Id = 0;
                bool resultado = Int32.TryParse(PersonaIdtextBox.Text, out Id);
                if (persona.Buscar(Id))
                {
                    NombretextBox.Text = persona.Nombre;
                    DirecciontextBox.Text = persona.Direccion;
                    if (persona.sexo == 1)
                    {
                        MasculinoradioButton.Checked = true;
                    }
                    else
                    {
                        FemeninaradioButton.Checked = true;
                    }
                    if (persona.EstadoCivil==1)
                    {
                        CasadoradioButton.Checked = true;
                    }
                    else
                    {
                        SolteroradioButton.Checked = true;
                    }

                    TelefonoslistBox.Items.Clear();
                    foreach (var telefono in persona.Telefono)
                    {
                        TelefonoslistBox.Items.Add(telefono.Telefono);
                    }
                }
                else
                {
                    MessageBox.Show("Persona No Existe","Error");
                } 
            }
            catch (Exception)
            {

                MessageBox.Show("Persona No Existe","Error");
            }
        }

        private void Quitarbutton_Click(object sender, EventArgs e)
        {
            if (TelefonoslistBox.SelectedIndex > 0)
            {
                if (MessageBox.Show("Seguro que dese Eliminar el Telefono: " + TelefonoslistBox.SelectedItem + "?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    TelefonoslistBox.Items.RemoveAt(TelefonoslistBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un Telefono");
            }
        }
    }
}
