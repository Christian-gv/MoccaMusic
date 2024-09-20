using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoccaMusic.Views;
using MoccaMusic.Views.Albumes;
using MoccaMusic.Views.Artisitas;
using MoccaMusic.Views.Generos;
using MoccaMusic.Views.Ventas;

namespace MoccaMusic.Views.principal
{
    public partial class Fmr_General : Form
    {
        public Fmr_General()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Fondo.JPEG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fmr_General_Load(object sender, EventArgs e)
        {

        }

        private void btn_Artistas_Click(object sender, EventArgs e)
        {
            Fmr_artistas fmr_Artistas = new Fmr_artistas();
            fmr_Artistas.Show();
        }

        private void btn_generos_Click(object sender, EventArgs e)
        {
            Fmr_generos fmr_Generos = new Fmr_generos();
            fmr_Generos.Show();
        }

        private void btn_albumes_Click(object sender, EventArgs e)
        {
            Fmr_Albumes fmr_Albumes = new Fmr_Albumes();
            fmr_Albumes.Show();
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            Fmr_Ventas fmr_Ventas = new Fmr_Ventas();
            fmr_Ventas.Show();
        }
    }
}
