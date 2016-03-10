using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;

namespace LaboratoryProject
{
    public static class StaticValues
    {
        public static LightSpeedContext<LSMLaboratoryUnitOfWork> lscon = new LightSpeedContext<LSMLaboratoryUnitOfWork>();
        public static object listOb;
        public static object listUltraObj;
        public static string userLoggedIn;
        public static string userRoleLogged;
    }
}
