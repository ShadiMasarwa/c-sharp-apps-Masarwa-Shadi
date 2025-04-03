using Microsoft.VisualStudio.TestTools.UnitTesting;
using c_sharp_apps_Masarwa_Shadi.BankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.BankApp.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void SetFirstNameTest()
        {
            Owner owner = new Owner("Shadi", "Masarwa");
            Account account = new Account(owner, 1000, 0);
            Assert.AreEqual("Shadi", owner.GetFirstName());
        }
        [TestMethod()]
        public void SetOverdraftTest()
        {
            Owner owner = new Owner("Shadi", "Masarwa");
            Account account = new Account(owner, 1000, -10);
            Assert.AreEqual(0, account.GetOverdraft());
        }
    }
}