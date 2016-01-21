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
    public partial class FormReportsUltrasound : Form
    {
        public FormReportsUltrasound()
        {
            InitializeComponent();
        }

        private void FormReportsUltrasound_Load(object sender, EventArgs e)
        {
            try
            {
                crULTRA crUltraObj = new crULTRA();
                crUltraObj.SetDataSource(StaticValues.listUltraObj);
                crViewerUltrasound.ReportSource = crUltraObj;
                crViewerUltrasound.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
    }
}
