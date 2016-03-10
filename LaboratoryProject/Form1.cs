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

                FormUserControl objUser = new FormUserControl();
                using (var uow = StaticValues.lscon.CreateUnitOfWork())
                {
                    //Master user
                    if (txtUsername.Text == "borloloy" && txtPassword.Text == "ido")
                    {
                        StaticValues.userRoleLogged = "SUPER";
                        Hide();
                        formMainSelection a = new formMainSelection();
                        a.ShowDialog();
                        a = null;
                        Show();
                        return;
                    }

                    var userLogging = (from us in uow.TblUsers where us.Password == objUser.Crypt(txtPassword.Text) & us.Username == txtUsername.Text select us).FirstOrDefault();
                    StaticValues.userLoggedIn = userLogging.Username;
                    StaticValues.userRoleLogged = userLogging.Role;

                    if (userLogging.Password == objUser.Crypt(txtPassword.Text) && userLogging.Username == txtUsername.Text)
                    {
                        Hide();
                        formMainSelection a = new formMainSelection();
                        a.ShowDialog();
                        a = null;
                        Show();
                    }
                    else
                    {
                        MessageBox.Show(this, "Username is incorrect.", "Error");
                    }

                }


            }
            catch (Exception er)
            {
                MessageBox.Show(this, "Username or Password is incorrect.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
