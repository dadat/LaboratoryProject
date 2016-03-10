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
using System.Security.Cryptography;

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
                var pWord = Crypt(txtAddPassword.Text);
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

        private byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public string Crypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        private string Decrypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
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
