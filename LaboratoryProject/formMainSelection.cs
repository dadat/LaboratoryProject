using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;
using Mindscape.LightSpeed.Querying;

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
            try
            {
                txtLABOther.Enabled = false;
                checkedListBoxLAB1.CheckOnClick = true;
                checkedListBoxLAB2.CheckOnClick = true;
                checkedListBoxLAB3.CheckOnClick = true;
                checkedListBoxLAB4.CheckOnClick = true;
                checkedListBoxLAB5.CheckOnClick = true;
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    var listDoc = (from doc in uow.TblDoctors where doc.IsActive == true select doc).ToList();
                    listToComboDoc(listDoc);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Combo box for Doctor error: " + er.ToString());
                throw;
            }
        }

        private void listToComboDoc(List<TblDoctor> doctors)
        {
            try
            {
                foreach (var item in doctors)
                {
                    txtDoctor.Items.Add(item.DocLastName + ", " + item.DocFirstName + " - " + item.CodeDoctor);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("List error: " + er.ToString());
                throw;
            }


        }

        private void userControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            FormUserControl a = new FormUserControl();
            a.ShowDialog();
            Show();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            FormServicesMaint a = new FormServicesMaint();
            a.ShowDialog();
            Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            FormDocPatient a = new FormDocPatient();
            a.ShowDialog();
            Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var pFName = txtFirstName.Text.ToUpper();
                var pLName = txtLastName.Text.ToUpper();
                var pTCode = "GENERATE CODE HERE";
                var pDoctor = txtDoctor.Text.Split(' ').Last();
                var pAddress = txtAddress.Text.ToUpper();
                var pAge = txtAge.Text.ToUpper();
                var pGender = txtGender.Text.ToUpper();
                var patientCompleteCode = "";
                var pContact = txtContact.Text;

                if (txtPatientCode.Text == "")
                {
                    Random r = new Random();
                    int rand = r.Next(9999);
                    patientCompleteCode = pFName.Substring(0, 3) + pLName.Substring(0, 3) + rand.ToString();
                }
                else
                {
                    patientCompleteCode = txtPatientCode.Text;
                }
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblTransaction tTrans = new TblTransaction();
                    tTrans.CodeTransaction = pTCode;
                    tTrans.CodeDoctor = pDoctor;
                    tTrans.CodePatient = patientCompleteCode;
                    tTrans.CodeTransaction = generateTransactionCode(patientCompleteCode);
                    tTrans.DateRegistered = DateTime.Today;

                    TblPatient tPatient = new TblPatient();
                    if (txtPatientCode.Text == "")
                    {
                        tPatient.CodePatient = patientCompleteCode;
                        tPatient.DateRegistered = DateTime.Today;
                        tPatient.FirstName = pFName;
                        tPatient.LastName = pLName;
                        tPatient.Gender = pGender;
                        tPatient.Address = pAddress;
                        tPatient.Age = Convert.ToInt16(pAge);
                        tPatient.Contact = pContact;

                        //Search record if [Patient Code] exists

                        var tryPatient = (from pQuery in uow.TblPatients where pQuery.CodePatient.Equals(patientCompleteCode) select pQuery).ToList();
                        if (tryPatient.Count > 0)
                        {
                            MessageBox.Show("Patient already exists.", "Message");
                        }
                        else
                        {
                            uow.Add(tPatient);
                        }

                    }

                    if (tTrans.Errors.Count == 0 && tPatient.Errors.Count == 0)
                    {

                        uow.Add(tTrans);
                        uow.SaveChanges();
                        MessageBox.Show("Transaction complete.", "Success");
                        clearText();
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error adding transaction: " + er.ToString());
                throw;
            }
        }

        private string generateTransactionCode(string seed)
        {
            try
            {
                Random r = new Random();
                int rand = r.Next(9999);
                var transcode = seed + rand.ToString();
                return transcode;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error generating transaction code: " + er.ToString());
                throw;
            }
        }

        private void btnSearchExisting_Click(object sender, EventArgs e)
        {
            try
            {
                clearText();
                var searchLastName = txtPatientSearch.Text;
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    var listPLastname = (from pa in uow.TblPatients where pa.LastName.Contains(searchLastName) select pa).ToList();
                    listComboPatient(listPLastname);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Searching failed, error: " + er.ToString());
                throw;
            }
        }

        private void listComboPatient(List<TblPatient> patient)
        {
            try
            {
                listExistingPatient.Items.Clear();
                foreach (var item in patient)
                {
                    listExistingPatient.Items.Add(item.LastName + ", " + item.FirstName + " - " + item.CodePatient);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error loading patient list " + er.ToString());
                throw;
            }
        }

        private void listExistingPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearText();
            var p = listExistingPatient.SelectedItem.ToString();
            var patientCode = p.Split(' ').Last();
            try
            {
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    var pIn = (from pTbl in uow.TblPatients where pTbl.CodePatient.Equals(patientCode) select pTbl).FirstOrDefault();
                    txtFirstName.Text = pIn.FirstName;
                    txtLastName.Text = pIn.LastName;
                    txtAddress.Text = pIn.Address;
                    txtAge.Text = Convert.ToString(pIn.Age);
                    txtGender.Text = pIn.Gender;
                    txtContact.Text = pIn.Contact;
                    txtPatientCode.Text = patientCode;
                    txtDoctor.Text = "";
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error getting patient code: " + er.ToString());
                throw;
            }

        }

        private void clearText()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtGender.SelectedIndex = 0;
            txtDoctor.SelectedIndex = 0;
            txtAge.Clear();
            txtPatientCode.Clear();
            txtContact.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnXRAYTest_Click(object sender, EventArgs e)
        {
            if (txtLABOther.Text == "")
            {

            }
            else
            {
                var other = txtLABOther.Text;
                listTestLAB.Items.Add(other);
                txtLABOther.Clear();
            }

        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLABOther.Checked)
            {
                txtLABOther.Enabled = true;
            }
            else
            {
                txtLABOther.Clear();
                txtLABOther.Enabled = false;
            }
        }

        private void checkedListBoxLAB4_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateLABList();
            checkedListBoxLAB4.ClearSelected();
        }

        private void generateLABList()
        {
            listTestLAB.Items.Clear();
            foreach (var item in checkedListBoxLAB1.CheckedItems)
            {
                listTestLAB.Items.Add(item);
            }
            foreach (var item in checkedListBoxLAB2.CheckedItems)
            {
                listTestLAB.Items.Add(item);
            }
            foreach (var item in checkedListBoxLAB3.CheckedItems)
            {
                listTestLAB.Items.Add(item);
            }
            foreach (var item in checkedListBoxLAB4.CheckedItems)
            {
                listTestLAB.Items.Add(item);
            }
            foreach (var item in checkedListBoxLAB5.CheckedItems)
            {
                listTestLAB.Items.Add(item);
            }
        }

        private void checkedListBoxLAB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateLABList();
            checkedListBoxLAB1.ClearSelected();
        }

        private void checkedListBoxLAB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateLABList();
            checkedListBoxLAB2.ClearSelected();
        }

        private void checkedListBoxLAB5_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateLABList();
            checkedListBoxLAB5.ClearSelected();
        }

        private void checkedListBoxLAB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateLABList();
            checkedListBoxLAB3.ClearSelected();
        }

        private void btnLABSubmit_Click(object sender, EventArgs e)
        {

        }

    }
}
