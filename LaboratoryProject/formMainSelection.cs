using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoryProject
{
    public partial class formMainSelection : Form
    {
        public formMainSelection()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formMainSelection_Load(object sender, EventArgs e)
        {

        }

        private void userControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            FormUserControl a = new FormUserControl();
            a.ShowDialog();
            Show();
        }

    }
}
