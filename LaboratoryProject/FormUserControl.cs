using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mindscape.LightSpeed.Querying;
using Mindscape.LightSpeed;

namespace LaboratoryProject
{
    public partial class FormUserControl : Form
    {
        public FormUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var uName = txtAddUsername.Text;
                var pWord = txtAddPassword.Text;
                var role = txtRole.Text;

                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    TblUser tuser = new TblUser();
                    tuser.Username = uName;
                    tuser.Password = pWord;
                    tuser.IsActive = true;
                    tuser.DateRegistered = DateTime.Now;
                    tuser.Role = role;
                    if (tuser.Errors.Count == 0)
                    {
                        uow.Add(tuser);
                        uow.SaveChanges();
                        MessageBox.Show("Successfully added new user");
                        clearText();
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("FormUserControl Adding New User "+ er.ToString());
                throw;
            }

        }

        private void clearText()
        {
            txtAddPassword.Clear();
            txtAddUsername.Clear();
        }

        private void FormUserControl_Load(object sender, EventArgs e)
        {
            txtRole.Text = "USER";
            txtUpdateRole.Text = "USER";
        }
    }
}
