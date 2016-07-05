using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Repositories;
using BllPart.Exceptions;

namespace BllPart.Services
{
     public abstract class Service
    {
        protected IUnitOfWork unit;

        public Service()
        {
            if (!Constants.IsInitialized)
            {
                throw new NotInitializedException();
            }
            unit = new UnitOfWork(Constants.Connection);
        }
    }
}
