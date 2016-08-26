using LGT.Framework.Core.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LGTFrameworkTeste
{
    [TestClass]
    public class GetResources
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreNotEqual(null, LGTWebResources.GetImageContent());
            Assert.AreNotEqual(null, LGTWebResources.GetCssFileContent());
        }
    }
}