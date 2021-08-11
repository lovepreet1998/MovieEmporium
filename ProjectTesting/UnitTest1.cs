using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieEmporium;
using MovieEmporium.Database;
using System;

namespace ProjectTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnection()
        {
            DBOperation db = new DBOperation();
            Assert.AreEqual(db.ConnectionStatus(), true);
        }


        [TestMethod]
        public void CheckValidation()
        {
            string value = "543ABC";
            Assert.AreEqual(Validator.CheckNumber(value), false);
        }
    }
}
