using JabulaniRubiblueAss.Auth.Encryption;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Auth.Tests
{
    public class EncryptionTests
    {
        private IEncryption Encryption = new JabulaniRubiblueAss.Auth.Encryption.Encryption();

        [Test]
        public void Should_Encrypt_Data()
        {
            //Arrange
            string Id = "2";

            //Act
            var result = Encryption.Encypt(Id);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(Id, Encryption.Decrypt(result));
        }

        [Test]
        public void Should_Decrypt_Data()
        {
            //Arrange
            string Id = Encryption.Encypt("4");

            //Act
            var result = Encryption.Decrypt(Id);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual("4", result);
        }
    }
}
