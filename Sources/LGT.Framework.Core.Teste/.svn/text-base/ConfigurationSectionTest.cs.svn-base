using LGT.Framework.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LGTFrameworkTeste
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ConfigurationSectionTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void TwitterApiConfiguration()
        {
            Assert.AreEqual(LGTHelperConfiguraton.FaceBookAppId, "204100086300230");
            Assert.AreEqual(LGTHelperConfiguraton.FaceBookAppSecret, "2d353c5259381a1f6f44c6d48f6a0b85");
        }

        [TestMethod]
        public void FaceBookApiConfiguration()
        {
            Assert.AreEqual(LGTHelperConfiguraton.FaceBookAppId, "204100086300230");
            Assert.AreEqual(LGTHelperConfiguraton.FaceBookAppSecret, "2d353c5259381a1f6f44c6d48f6a0b85");
        }


        [TestMethod]
        public void JQueryUicssUrlConfiguration()
        {
            Assert.AreEqual(LGTHelperConfiguraton.JQueryCSSUrl,
                            "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/themes/ui-lightness/jquery-ui.css");
        }


        [TestMethod]
        public void BizFullPATH()
        {
            Assert.AreEqual(LGTHelperConfiguraton.ConcretBizClassAssembly,
                            @"D:\Projetos\PedeAi\SRC\PedeAi.BIZ\bin\Debug\PedeAi.Biz.dll");
        }

        [TestMethod]
        public void RedirectInformation()
        {
            Assert.AreEqual(LGTHelperConfiguraton.RedirectLoginPage, "Login.aspx");
            Assert.AreEqual(LGTHelperConfiguraton.RedirectDefaultPage, "Default.aspx");
        }
    }
}