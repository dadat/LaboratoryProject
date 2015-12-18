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
    }
}
