using BLL.DI;
using BLL.UnitTest.FakeDataInitializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitTest.DTOTest
{
    public class BaseDTOTest
    {
        [TestInitialize]
        public void ReplaceDALModule()
        {
            BLL.DI.AutofacContainer.Config(new FakeDalModule());
        }
    }
}
