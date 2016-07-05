using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityWorkers
{
    abstract class EntityWorker
    {
        protected ManagerContext db = ManagerContext.CreateInstance();
    }
}
