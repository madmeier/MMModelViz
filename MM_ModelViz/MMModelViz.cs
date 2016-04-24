using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM_ModelViz
{
    public partial class MMModelVizMain : Form
    {
        public MMModelVizMain()
        {
            InitializeComponent();
        }

        private void MatrixToolButtonClick(object sender, EventArgs e)
        {
            var mv = new MMMatrixView();
            mv.Show();
        }

        private void LandscapeToolButton1Click(object sender, EventArgs e)
        {
            var ml = new MmLandscapeView();
            ml.Show();
        }

        private void ShapeDecorationButtonClick(object sender, EventArgs e)
        {
            var ms = new MMShapeDecoration();
            ms.Show();
        }

        private void LineDecorationButtonClick(object sender, EventArgs e)
        {
            var ml = new MMLineDecoration();
            ml.Show();
        }
    }
}
