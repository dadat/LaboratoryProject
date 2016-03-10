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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace LaboratoryProject
{
    public partial class formMainSelection : Form
    {
        public formMainSelection()
        {
            InitializeComponent();
        }

        public string patientCompleteCode { get; set; }

        private void patientCodeGen()
        {
            patientInfo();
            if (txtPatientCode.Text == "")
            {
                Random r = new Random();
                int rand = r.Next(9999);
                patientCompleteCode = patientInfo().FirstName.Substring(0, 3) + patientInfo().LastName.Substring(0, 3) + rand.ToString();
            }
            else
            {
                patientCompleteCode = txtPatientCode.Text;
            }
        }

        private XRay xRayInfo()
        {
            XRay xray = new XRay();
            xray.Doctor = patientInfo().Doctor;
            xray.FilmNo = txtXRAYFilmNo.Text.ToUpper();
            xray.Findings = txtXRAYFindings.Text;
            xray.Remarks = txtXRAYRemarks.Text;
            xray.Roentgenography = txtXRAYRoentgenography.Text;
            xray.Radiologist = txtXRAYRadTech.Text;
            xray.DatePerformed = txtXRAYDateTimePerformed.Text;
            return xray;
        }

        private Patient patientInfo()
        {
            Patient patient = new Patient();
            patient.FirstName = txtFirstName.Text.ToUpper();
            patient.LastName = txtLastName.Text.ToUpper();
            patient.Doctor = txtDoctor.Text.Split(' ').Last();
            patient.Address = txtAddress.Text.ToUpper();

            if (txtAge.Text == "")
            {
                patient.Age = 0;
            }
            else
            {
                patient.Age = Convert.ToInt16(txtAge.Text);
            }

            patient.Sex = txtGender.Text.ToUpper();
            patient.Contact = txtContact.Text;
            patient.PatientCode = txtPatientCode.Text;
            return patient;
        }

        private void formMainSelection_Load(object sender, EventArgs e)
        {
            try
            {
                roleDependency();
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

        private void roleDependency()
        {
            if (StaticValues.userRoleLogged != "ADMIN")
            {
                menuStrip1.Visible = false;
            }
            if (StaticValues.userRoleLogged == "SUPER")
            {
                menuStrip1.Visible = true;
            }
            if (StaticValues.userRoleLogged == "XRAY")
            {
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage2);
            }
            if (StaticValues.userRoleLogged == "LAB")
            {
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage3);
            }
            if (StaticValues.userRoleLogged == "ULTRASOUND")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
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

        private string pCodeTemp()
        {
            return patientCompleteCode;
        }

        private void addNewPatient()
        {
            if (txtPatientCode.Text != "")
            {
                return;
            }

            try
            {
                var pFName = txtFirstName.Text.ToUpper();
                var pLName = txtLastName.Text.ToUpper();
                var pTCode = "GENERATE CODE HERE";
                var pDoctor = txtDoctor.Text.Split(' ').Last();
                var pAddress = txtAddress.Text.ToUpper();
                var pAge = "";

                if (txtAge.Text == "")
                {
                    pAge = "0";
                }
                else
                {
                    pAge = txtAge.Text.ToUpper();
                }

                var pGender = txtGender.Text.ToUpper();
                var pContact = txtContact.Text;


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
                        MessageBox.Show("Added new patient.", "Success");
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
                var pContact = txtContact.Text;

                
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

        private string generateXRAYCode(string seed)
        {
            try
            {
                Random r = new Random();
                int rand = r.Next(99999);
                var transcode = seed + rand.ToString();
                return transcode;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error generating transaction code: " + er.ToString());
                throw;
            }
        }

        private string generateLABCode(string seed)
        {
            try
            {
                Random r = new Random();
                int rand = r.Next(99999);
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
                //do nothing
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
            try
            {
                var pTextFirstname = "";
                var pTextLastname = "";
                var pAge = "";

                pTextFirstname = txtFirstName.Text;
                pTextLastname = txtLastName.Text;
                pAge = txtAge.Text;
                if (pTextLastname == "" || pAge == "" || pTextFirstname == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Patient details incomplete, continue saving?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        patientCodeGen();
                        addNewPatient();
                        if (patientCompleteCode == "")
                        {
                            MessageBox.Show("Input Patient Details");
                            return;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    patientCodeGen();
                    addNewPatient();
                }

                string request = "";
                decimal labPrice = 0;
                string labCode = "";
                DateTime labDateEnc = DateTime.Now;
                string labDate = "";
                string labDoc = "";

                string[] items = listTestLAB.Items.OfType<object>().Select(item => item.ToString()).ToArray();
                request = string.Join(", ", items);

                //End Request loop

                labCode = generateLABCode("LAB");

                labDate = txtLABDate.Text;

                labDoc = txtDoctor.Text.Split(' ').Last();

                if (txtLABTotal.Text == "")
                {
                    labPrice = decimal.Parse("0");
                }
                else
                {
                    labPrice = decimal.Parse(txtLABTotal.Text);
                }

                Laboratory labObj = new Laboratory(request, labPrice, labCode, labDateEnc, labDate, labDoc, patientCompleteCode);

                if (labObj.insertLaboratory() == true)
                {
                    MessageBox.Show("Laboratory Record added.");
                    UncheckAllItems();
                }
                else
                {
                    MessageBox.Show("Laboratory Record not added.");
                }

            }
            catch (Exception exLabSubmit)
            {
                MessageBox.Show("Laboratory Error: " + exLabSubmit.Message + Environment.NewLine + Environment.NewLine + "Input Patient Details or Total is blank/invalid.");
            }
        }

        private void UncheckAllItems()
        {
            while (checkedListBoxLAB1.CheckedIndices.Count > 0)
                checkedListBoxLAB1.SetItemChecked(checkedListBoxLAB1.CheckedIndices[0], false);
            while (checkedListBoxLAB2.CheckedIndices.Count > 0)
                checkedListBoxLAB2.SetItemChecked(checkedListBoxLAB2.CheckedIndices[0], false);
            while (checkedListBoxLAB3.CheckedIndices.Count > 0)
                checkedListBoxLAB3.SetItemChecked(checkedListBoxLAB3.CheckedIndices[0], false);
            while (checkedListBoxLAB4.CheckedIndices.Count > 0)
                checkedListBoxLAB4.SetItemChecked(checkedListBoxLAB4.CheckedIndices[0], false);
            while (checkedListBoxLAB5.CheckedIndices.Count > 0)
                checkedListBoxLAB5.SetItemChecked(checkedListBoxLAB5.CheckedIndices[0], false);
            listTestLAB.Items.Clear();
            txtLABDate.Clear();
            txtLABTotal.Clear();
        }

        private void btnXRAYSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAge.Text == "")
                {
                    txtAge.Text = "0";
                }
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblXRay tXray = new TblXRay();
                    if (txtPatientCode.Text == "")
                    {
                        patientCodeGen();
                        tXray.CodePatient = patientCompleteCode;
                    }
                    else
                    {
                        tXray.CodePatient = txtPatientCode.Text;
                    }
                    
                    tXray.CodeXRay = generateXRAYCode("XR");
                    tXray.FilmNo = xRayInfo().FilmNo;
                    tXray.Findings = xRayInfo().Findings;
                    tXray.Remarks = xRayInfo().Remarks;
                    tXray.Radiologist = xRayInfo().Radiologist;
                    tXray.Roentgenography = xRayInfo().Roentgenography;
                    tXray.DateEncoded = DateTime.Now;
                    tXray.DateXRay = xRayInfo().DatePerformed;

                    if (tXray.Errors.Count == 0)
                    {
                        uow.Add(tXray);
                        uow.SaveChanges();
                        MessageBox.Show("XRay record saved.");
                        addNewPatient();

                        submitXRAYReport(txtFirstName.Text + " " + txtLastName.Text, txtXRAYRoentgenography.Text, txtDoctor.Text, txtXRAYDateTimePerformed.Text, txtAge.Text, txtGender.Text, txtXRAYFilmNo.Text, txtXRAYFindings.Text ,txtXRAYRemarks.Text, txtXRAYRadTech.Text);

                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Saving XRay error: Cause might be lack of Patient First and Last name. Error message: " + Environment.NewLine + er);
            }
        }


        public void submitXRAYReport(string patient, string roent, string doc, string dateperformed, string age, string sex, string filmNo, string findings, string remarks, string radiologist)
        {
            try
            {
                XRay xray = new XRay();
                xray.Patient = patient;
                xray.Roentgenography = roent;
                xray.Doctor = doc;
                xray.DatePerformed = dateperformed;
                xray.FilmNo = filmNo;
                xray.Findings = findings;
                xray.Remarks = remarks;
                xray.Radiologist = radiologist;
                xray.Age = age;
                xray.Gender = sex;

                List<XRay> listXray = new List<XRay>();
                listXray.Add(xray);
                StaticValues.listOb = listXray;

                crXRay xReport = new crXRay();
                xReport.SetDataSource(listXray);

                FormReportsXRay fXRAY = new FormReportsXRay();
                fXRAY.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void btnULTRASubmit_Click(object sender, EventArgs e)
        {
            var pTextFirstname = "";
            var pTextLastname = "";
            var pAge = "";

            pTextFirstname = txtFirstName.Text;
            pTextLastname = txtLastName.Text;
            pAge = txtAge.Text;
            if (pTextLastname == "" || pAge == "" || pTextFirstname == "")
            {
                DialogResult dialogResult = MessageBox.Show("Patient details incomplete, continue saving?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    patientCodeGen();
                    addNewPatient();
                    if (patientCompleteCode == "")
                    {
                        MessageBox.Show("Input Patient Details");
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                patientCodeGen();
                addNewPatient();
            }

            var ultraCode = generateXRAYCode("XR");

            Ultrasound ultra = new Ultrasound(txtULTRAFindings.Text, txtULTRAImpression.Text, txtULTRARadiologist.Text, patientCompleteCode, ultraCode, txtULTRADate.Text, DateTime.Now);

            if (ultra.insertUltrasound() == true)
            {
                MessageBox.Show("Ultrasound successfully added.");
                submitUltrasoundReport();
                FormReportsUltrasound frmUltra = new FormReportsUltrasound();
                frmUltra.Show();
            }
            else
            {
                MessageBox.Show("Error adding Ultrasound");
            }
        }

        public void submitUltrasoundReport()
        {
            try
            {
                List<UltrasoundClass> listUltra = new List<UltrasoundClass>();
                UltrasoundClass ultraObj = new UltrasoundClass();

                ultraObj.Address = txtAddress.Text;
                ultraObj.Age = txtAge.Text;
                ultraObj.CivilStatus = txtULTRACivilStatus.Text;
                ultraObj.DatePerformed = txtULTRADate.Text;
                ultraObj.Doctor = txtDoctor.Text;
                ultraObj.FileNo = txtULTRAFileNo.Text;
                ultraObj.Findings = txtULTRAFindings.Text;
                ultraObj.Gender = txtGender.Text;
                ultraObj.Impression = txtULTRAImpression.Text;
                ultraObj.Patient = txtFirstName.Text + " " + txtLastName.Text;
                ultraObj.Radiologist = txtULTRARadiologist.Text;
                listUltra.Add(ultraObj);

                StaticValues.listUltraObj = listUltra;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Developer: \nDavid Martin Barredo\n\nInquiries: \ndavid@barredo.co\n\nGithub: \ngithub.com/dadat", "About");
        }

    }
}
