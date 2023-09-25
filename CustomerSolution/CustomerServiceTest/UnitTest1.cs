using CustomerBL;
using CustomerDALibrary;
using CustomerModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            Provider provider = new Provider();
            ICustomerService service = provider.GetCustomerService();

            Customer customer = null;
            var result = service.AddNew(customer);

            Assert.IsNotNull(result);
        }
    }
}
