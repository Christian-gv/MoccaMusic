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
    public partial class Fmr_reportes_ventas : Form
    {
        public Fmr_reportes_ventas()
        {
            InitializeComponent();
        }

        private void Fmr_reportes_ventas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
