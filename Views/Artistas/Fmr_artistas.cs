using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoccaMusic.Config;
using MoccaMusic.Controllers;
using MoccaMusic.Models;


namespace MoccaMusic.Views.Artisitas
{
    public partial class Fmr_artistas : Form
    {
        ArtistasControllers _artistasControllers = new ArtistasControllers();
        List <ArtistasModels> _listaArtistas = new List <ArtistasModels>();
        public Fmr_artistas()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo.JPEG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fmr_artistas_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }
        public void cargarDataGridView()
        {
            dataGridView1.DataSource = null;
            _listaArtistas = _artistasControllers.Todos();
            dataGridView1.DataSource = _listaArtistas;
        }


        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
            {
                ArtistasModels nuevoArtista = new ArtistasModels
                {
                    Nombre = txt_Nombre.Text
                };

                _artistasControllers.Insertar(nuevoArtista);
                cargarDataGridView(); 
                txt_Nombre.Clear(); 
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
                var idArtista = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Artista"].Value);
                _artistasControllers.Eliminar(idArtista); 
                cargarDataGridView(); 
            }
            else
            {
                MessageBox.Show("Seleccione un artista para eliminar.");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var idArtista = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Artista"].Value);
                string nuevoNombre = txt_Nombre.Text;

                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    ArtistasModels artistaModificado = new ArtistasModels
                    {
                        ID_Artista = idArtista,
                        Nombre = nuevoNombre
                    };

                    _artistasControllers.Modificar(artistaModificado); 
                    cargarDataGridView(); 
                    txt_Nombre.Clear(); 
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un nombre válido.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un artista para modificar.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
