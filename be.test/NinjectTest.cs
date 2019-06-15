using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.test
{
    public abstract class NinjectTest
    {
        protected IKernel Kernel { get; set; }

        [TestInitialize]
        public void DoInitialize()
        {
            XmlConfigurator.Configure();
            Kernel = new StandardKernel();
            try
            {
                RegisterServices();
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        public abstract void RegisterServices();

        public T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
