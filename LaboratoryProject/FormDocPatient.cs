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
    public partial class FormDocPatient : Form
    {
        public FormDocPatient()
        {
            InitializeComponent();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtFirstNameDoc.Text == "") || (txtLastNameDoc.Text == ""))
                {
                    MessageBox.Show("Input first name or last name.", "Error");
                    return;
                }
                else
                {
                    var fnameDoc = txtFirstNameDoc.Text.ToUpper();
                    var lnameDoc = txtLastNameDoc.Text.ToUpper();

                    if (txtDocCode.Text == "")
                    {
                        suggestCode();
                    }

                    var codeDoc = txtDocCode.Text.ToUpper();

                    using (var uow = StaticValues.lscon.CreateUnitOfWork())
                    {
                        TblDoctor tDoc = new TblDoctor();
                        tDoc.DocFirstName = fnameDoc;
                        tDoc.DocLastName = lnameDoc;
                        tDoc.DateRegistered = DateTime.Now;
                        tDoc.CodeDoctor = codeDoc;
                        tDoc.IsActive = true;

                        if (tDoc.Errors.Count == 0)
                        {
                            uow.Add(tDoc);
                            uow.SaveChanges();
                            MessageBox.Show("Added new Doctor", "Success");
                            loadDocs();
                        }
                    }
                }

                
            }
            catch (Exception er)
            {
                MessageBox.Show("Adding/Updating Doctor error: " + er.ToString());
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            suggestCode();
        }

        private void suggestCode()
        {
            try
            {
                if ((txtFirstNameDoc.Text == "") || (txtLastNameDoc.Text == ""))
                {
                    return;
                }
                txtDocCode.Clear();
                var fname = txtFirstNameDoc.Text;
                var lname = txtLastNameDoc.Text;
                var newCode = fname[0];
                Random r = new Random();
                int rand = r.Next(99);
                txtDocCode.Text = lname.Substring(0, 2).ToUpper() + newCode.ToString().ToUpper() + rand.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error suggesting Doctor Code: " + er.ToString());
                throw;
            }
        }

        private void FormDocPatient_Load(object sender, EventArgs e)
        {
            loadDocs();
        }

        private void loadDocs()
        {
            try
            {
                listDoctor.Items.Clear();

                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    var listDoc = (from d in uow.TblDoctors where d.IsActive == true orderby d.DocLastName select d).ToList();

                    foreach (var item in listDoc)
                    {
                        listDoctor.Items.Add(item.CodeDoctor + " - " + item.DocLastName + ", " + item.DocFirstName);
                    }

                }


            }
            catch (Exception er)
            {
                MessageBox.Show("Error populating list box: " + er.ToString());
                throw;
            }
        }
    }
}
