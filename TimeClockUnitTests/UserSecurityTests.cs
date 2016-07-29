using System;
using TimeClock.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeClockUnitTests
{
    [TestClass]
    public class UserSecurityTests
    {
        [TestMethod]
        public void HashValidation()
        {
            var hash = UserSecurity.CreateHash("password");
            var parts = hash.Split(':');

            // validate overall length of hash
            Assert.AreEqual(71, hash.Length);          
            
            //validate only 5 parts
            Assert.AreEqual(5, parts.Length);
            // validate sha1 
            Assert.AreEqual("sha1", parts[0]);
            // validate 640000 iterations
            Assert.AreEqual("64000", parts[1]);
            // validate 18 byte hash
            Assert.AreEqual("18", parts[2]);
            // validate salt is 32 bytes
            Assert.AreEqual(32, parts[3].Length);
            // validate hash is 24 bytes
            Assert.AreEqual(24, parts[4].Length);

        }

        [TestMethod]
        public void HashesAreDifferent()
        {
            var h1 = UserSecurity.CreateHash("password");
            var h2 = UserSecurity.CreateHash("password");
            Assert.AreNotEqual(h1, h2, false);
        }

        [TestMethod]
        public void PasswordValidationReturnsTrue()
        {
            var hash = UserSecurity.CreateHash("password");

            Assert.IsTrue(UserSecurity.VerifyPassword("password", hash));
        }

        [TestMethod]
        public void PasswordValidationReturnsFalse()
        {
            var hash = UserSecurity.CreateHash("password");
            Assert.IsFalse(UserSecurity.VerifyPassword("passwOrd", hash));
        }

        [TestMethod]
        public void PasswordWithEmptySpaces()
        {
            var hash = UserSecurity.CreateHash(" ");
            Assert.IsTrue(UserSecurity.VerifyPassword(" ", hash));
        }
    }
}
