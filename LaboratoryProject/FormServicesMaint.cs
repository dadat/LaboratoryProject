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
    public partial class FormServicesMaint : Form
    {
        public FormServicesMaint()
        {
            InitializeComponent();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            try
            {
                var servName = txtServiceName.Text.ToUpper();
                var servAmt = Convert.ToDecimal(txtFee.Text);
                var servClass = txtClassification.Text;
                var servCode = txtServiceCode.Text.ToUpper();
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblService tService = new TblService();
                    tService.AmountService = servAmt;
                    tService.TitleService = servName;
                    tService.IsActive = true;
                    tService.ClassificationService = servClass;
                    tService.DateRegistered = DateTime.Now;
                    tService.CodeService = servCode;
                    if (tService.Errors.Count == 0)
                    {
                        uow.Add(tService);
                        uow.SaveChanges();
                        MessageBox.Show("Added new service.");
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Adding service error: " + er.ToString());
                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
