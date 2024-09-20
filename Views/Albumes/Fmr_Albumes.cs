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

namespace MoccaMusic.Views.Albumes
{
    public partial class Fmr_Albumes : Form
    {
        GenerosController _generoControllers = new GenerosController();
        List<GenerosModel> _listaGeneros = new List<GenerosModel>();
        ArtistasControllers _artistasControllers = new ArtistasControllers();
        List<ArtistasModels> _listaArtistas = new List<ArtistasModels>();
        AlbumesController _albumesController = new AlbumesController();
        List <AlbumesModel>  _listAlbumes = new List<AlbumesModel>();

        public Fmr_Albumes()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo.JPEG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fmr_Albumes_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
            cargarDataGridView2();
            cargarDataGridView3();

        }
        public void cargarDataGridView2()
        {
            dataGridView2.DataSource = null;
            _listaArtistas = _artistasControllers.Todos();
            dataGridView2.DataSource = _listaArtistas;
        }
        public void cargarDataGridView3()
        {
            dataGridView3.DataSource = null;
            _listaGeneros = _generoControllers.Todos();
            dataGridView3.DataSource = _listaGeneros;
        }
        public void cargarDataGridView()
        {
            dataGridView1.DataSource = null;
            _listAlbumes = _albumesController.Todos();
            dataGridView1.DataSource = _listAlbumes;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_idArtista_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_IdGenero_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                AlbumesModel nuevoAlbum = new AlbumesModel
                {
                    Titulo = txt_Nombre.Text,
                    ID_Artista = Convert.ToInt32(txt_idArtista.Text), 
                    ID_Genero = Convert.ToInt32(txt_IdGenero.Text) 
                };

                _albumesController.Insertar(nuevoAlbum);
                MessageBox.Show("Álbum agregado correctamente.");
                cargarDataGridView(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el álbum: " + ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int idAlbum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Album"].Value);
                    _albumesController.Eliminar(idAlbum);
                    MessageBox.Show("Álbum eliminado correctamente.");
                    cargarDataGridView(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el álbum: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un álbum para eliminar.");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    AlbumesModel albumModificado = new AlbumesModel
                    {
                        ID_Album = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Album"].Value),
                        Titulo = txt_Nombre.Text,
                        ID_Artista = Convert.ToInt32(txt_idArtista.Text),
                        ID_Genero = Convert.ToInt32(txt_IdGenero.Text) 
                    };

                    _albumesController.Modificar(albumModificado);
                    MessageBox.Show("Álbum modificado correctamente.");
                    cargarDataGridView(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el álbum: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un álbum para modificar.");
            }
        }
    }
}
