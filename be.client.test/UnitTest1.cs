using System;
using be.client.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace be.client.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStatus()
        {
            var movimento = new Service("http://localhost:52194").Get();
            Assert.IsNotNull(movimento);
        }
    }
}
