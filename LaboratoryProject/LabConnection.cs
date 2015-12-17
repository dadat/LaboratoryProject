using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;

namespace LaboratoryProject
{
    class LabConnection
    {


        private void LoadLabConnection()
        {
            try
            {
                StaticValues.lscon.ConnectionString = "Data Source=localhost;Initial Catalog=dblabserv;Persist Security Info=True;User ID=dvduser;Password=dvdpassword";
                StaticValues.lscon.IdentityMethod = IdentityMethod.IdentityColumn;
                StaticValues.lscon.DataProvider = DataProvider.SqlServer2008;
                StaticValues.lscon.QuoteIdentifiers = true;
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.ToString());
                throw;
            }           

        }

        public void LoadConnection()
        {
            LoadLabConnection();
        }

    }

}
