using LGT.Framework.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LGTFrameworkTeste
{
    [TestClass]
    public class CryptoTest
    {
        [TestMethod]
        public void Encrypt()
        {
            const string cryptoText = "6AV88gfXXSkLUuM4qiXTkw==";
            const string plainText = "Luciano Castro";

            var crypto = LGTHelperCrypto.Encrypt(plainText);
            Assert.AreNotEqual(null, crypto);
            Assert.AreEqual(cryptoText, crypto);


            var decrypto = LGTHelperCrypto.Encrypt(cryptoText);
            Assert.AreNotEqual(null, decrypto);
            Assert.AreEqual(plainText, plainText);
        }
    }
}