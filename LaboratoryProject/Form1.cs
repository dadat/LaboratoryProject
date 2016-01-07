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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LabConnection labCon = new LabConnection();
                labCon.LoadConnection();
                Hide();
                formMainSelection a = new formMainSelection();
                a.ShowDialog();
                a = null;
                Show();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
