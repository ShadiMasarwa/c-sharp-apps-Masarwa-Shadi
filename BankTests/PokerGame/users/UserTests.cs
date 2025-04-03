using Microsoft.VisualStudio.TestTools.UnitTesting;
using c_sharp_apps_Masarwa_Shadi.PokerGame.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            User user = new User("Shadi", User_Role.PLAYER);
            Assert.AreEqual("Shadi", user.Username);
        }
    }
}