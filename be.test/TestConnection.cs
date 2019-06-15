using be.business.Model;
using be.business.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.test
{
    [TestClass]
    public class TestConnection : NinjectTest
    {
       public override void RegisterServices()
        {
            Kernel.Bind<BeModel>().ToSelf();
        }
        [TestMethod]
        public void Test()
        {
            var mov = Kernel.Get<MovimentoRepository>();
            var a = mov.FindAll().ToList();
            Assert.IsNotNull(a);

        }
    }
}
