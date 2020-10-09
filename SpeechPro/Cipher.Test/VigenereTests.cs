using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cipher.Test
{
    public class VigenereTests
    {
        [Test]
        public void Encrypt_CorrectInputString_CorrectEncrypted()
        {
            var source = "Hello";
            var key = "key";
            var cipher = new Vigenere();
            var encrypted = cipher.Encrypt(source, key);
            var expected = "RIJVS";
            Assert.AreEqual(expected, encrypted);
        }

        [Test]
        public void Encrypt_CorrectInputEnumerable_CorrectEncrypted()
        {
            var source = new List<string> { "Hello", "Vigenere", "cipher" };
            var key = "key";
            var cipher = new Vigenere();
            var encrypted = cipher.Encrypt(source, key);
            var expected = new List<string> { "RIJVS", "FMEORCBI", "MMNRIP" };
            CollectionAssert.AreEqual(expected, encrypted);
        }

        [Test]
        public void Decrypt_CorrectInputString_CorrectDecrypted()
        {
            var encrypted = "Rijvs";
            var key = "key";
            var cipher = new Vigenere();
            var decrypted = cipher.Decrypt(encrypted, key);
            var expected = "HELLO";
            Assert.AreEqual(expected, decrypted);
        }

        [Test]
        public void Decrypt_CorrectInputEnumerable_CorrectEncrypted()
        {
            var source = new List<string> { "Rijvs", "FMEORCBI", "mmnrip" };
            var key = "key";
            var cipher = new Vigenere();
            var decrypted = cipher.Decrypt(source, key);
            var expected = new List<string> { "HELLO", "VIGENERE", "CIPHER" }; ;
            CollectionAssert.AreEqual(expected, decrypted);
        }

        [Test]
        public void Encrypt_IncorrectInput_ThrowException()
        {
            var source = "Hello!";
            var key = "key";
            var cipher = new Vigenere();
            Assert.Throws(typeof(ArgumentException), delegate { cipher.Encrypt(source, key); });
        }

        [Test]
        public void Encrypt_NullKeyProvided_ThrowException()
        {
            var source = "Hello";
            var cipher = new Vigenere();
            Assert.Throws(typeof(ArgumentNullException), delegate { cipher.Encrypt(source, null); });
        }

        [Test]
        public void Encrypt_EmptyEnumerableInput_Empty()
        {
            var source = new List<string>();
            var key = "key";
            var cipher = new Vigenere();
            var encrypted = cipher.Encrypt(source, key);
            Assert.IsEmpty(encrypted);
        }

        [Test]
        public void Encrypt_EmptyInput_EmptyOutput()
        {
            var source = "";
            var key = "key";
            var cipher = new Vigenere();
            var encrypted = cipher.Encrypt(source, key);
            Assert.IsEmpty(encrypted);
        }
    }
}