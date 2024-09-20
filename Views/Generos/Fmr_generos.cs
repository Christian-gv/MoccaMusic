using MoccaMusic.Controllers;
using MoccaMusic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoccaMusic.Views.Generos
{
    public partial class Fmr_generos : Form
    {
        GenerosController _generoControllers = new GenerosController();
        List<GenerosModel> _listaGeneros = new List<GenerosModel>();
        public Fmr_generos()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo.JPEG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fmr_generos_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }
        public void cargarDataGridView()
        {
            dataGridView1.DataSource = null;
            _listaGeneros = _generoControllers.Todos();
            dataGridView1.DataSource = _listaGeneros;
        }
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
            {
                var nuevoGenero = new GenerosModel
                {
                    Nombre = txt_Nombre.Text
                };

                var generoAgregado = _generoControllers.Insertar(nuevoGenero);
                if (generoAgregado != null)
                {
                    MessageBox.Show("Género agregado correctamente.");
                    txt_Nombre.Clear(); 
                    cargarDataGridView(); 
                }
                else
                {
                    MessageBox.Show("Error al agregar el género.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var idGenero = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Genero"].Value);
                bool eliminado = _generoControllers.Eliminar(idGenero);

                if (eliminado)
                {
                    MessageBox.Show("Género eliminado correctamente.");
                    cargarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el género.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un género para eliminar.");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var idGenero = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Genero"].Value);
                string nuevoNombre = txt_Nombre.Text;

                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    GenerosModel generoModificado = new GenerosModel
                    {
                        ID_Genero = idGenero,
                        Nombre = nuevoNombre
                    };

                    bool modificado = _generoControllers.Modificar(generoModificado);

                    if (modificado)
                    {
                        MessageBox.Show("Género modificado correctamente.");
                        cargarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el género.");
                    }

                    txt_Nombre.Clear(); 
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un nombre válido.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un género para modificar.");
            }
        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
