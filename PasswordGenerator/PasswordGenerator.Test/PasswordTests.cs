using NUnit.Framework;
using System.Text.RegularExpressions;

namespace PasswordGenerator.Test
{
    public class PasswordTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void PasswordGenerator_NoParameters_PasswordLength15()
        {
            var pwd = new Password();
            var result = pwd.Next();
            Assert.AreEqual(15, result.Length);
        }

        [Test]
        [Repeat(1000)]
        public void PasswordGenerator_IdenticalConsecutive_False()
        {
            var pwd = new Password(40);
            var result = Regex.IsMatch(pwd.Next(), @"(.)\1{2,}");
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PasswordGenerator_LengthParameter28_PasswordLength28()
        {
            var pwd = new Password(28);
            var result = pwd.Next();
            Assert.AreEqual(28, result.Length);
        }



    }
}