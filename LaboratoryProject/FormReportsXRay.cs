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
    public partial class FormReportsXRay : Form
    {
        public FormReportsXRay()
        {
            InitializeComponent();
        }

        private void FormReportsXRay_Load(object sender, EventArgs e)
        {
            try
            {
                crXRay xReport = new crXRay();
                xReport.SetDataSource(StaticValues.listOb);
                crViewerXRay.ReportSource = xReport;
                crViewerXRay.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
