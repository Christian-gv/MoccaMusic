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

namespace MoccaMusic.Views.Ventas
{
    public partial class Fmr_Ventas : Form
    {
        AlbumesController _albumesController = new AlbumesController();
        List<AlbumesModel> _listAlbumes = new List<AlbumesModel>();
        VentasController _ventasControllers = new VentasController();
        List <VentasModel> _listVentas  = new List<VentasModel>();
        public Fmr_Ventas()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo.JPEG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fmr_Ventas_Load(object sender, EventArgs e)
        {
            cargarDataGridView1();
            cargarDataGridView2();
        }
        public void cargarDataGridView1()
        {
            dataGridView1.DataSource = null;
            _listVentas = _ventasControllers.Todos();
            dataGridView1.DataSource = _listVentas;
        }
        public void cargarDataGridView2()
        {
            dataGridView2.DataSource = null;
            _listAlbumes = _albumesController.Todos();
            dataGridView2.DataSource = _listAlbumes;
        }

        private void txt_idÁlbum_TextChanged(object sender, EventArgs e)
        {

        }

        private void dt_fechaventa_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_idÁlbum.Text))
            {
                VentasModel nuevaVenta = new VentasModel
                {
                    ID_Album = Convert.ToInt32(txt_idÁlbum.Text),
                    Fecha_Venta = dt_fechaventa.Value
                };

                VentasModel ventaInsertada = _ventasControllers.Insertar(nuevaVenta);

                if (ventaInsertada != null)
                {
                    MessageBox.Show("Venta agregada con éxito");
                    cargarDataGridView1();
                }
                else
                {
                    MessageBox.Show("Error al agregar la venta");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de álbum válido.");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idVenta = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Venta"].Value);

                bool eliminado = _ventasControllers.Eliminar(idVenta);

                if (eliminado)
                {
                    MessageBox.Show("Venta eliminada con éxito");
                    cargarDataGridView1();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la venta");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una venta para eliminar.");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idVenta = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Venta"].Value);

                VentasModel ventaModificada = new VentasModel
                {
                    ID_Venta = idVenta,
                    ID_Album = Convert.ToInt32(txt_idÁlbum.Text),
                    Fecha_Venta = dt_fechaventa.Value
                };

                bool modificado = _ventasControllers.Modificar(ventaModificada);

                if (modificado)
                {
                    MessageBox.Show("Venta modificada con éxito");
                    cargarDataGridView1();
                }
                else
                {
                    MessageBox.Show("Error al modificar la venta");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una venta para modificar.");
            }
        }
    }
}
