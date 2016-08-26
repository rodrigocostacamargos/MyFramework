using System.Configuration;
using LGT.Framework.Core.Configuration;

namespace LGT.Framework.Core.Helper
{
    public sealed class LGTHelperConfiguraton
    {
        private static LGTSettingsSection _configuration;

        private static LGTSettingsSection Configuration
        {
            get
            {
                return _configuration ??
                       (_configuration = (LGTSettingsSection)ConfigurationManager.GetSection("LGTSettings"));
            }
        }

        public static string TwitterAppId
        {
            get { return Configuration.Twitter.AppId; }
        }

        public static string TwitterAppSecret
        {
            get { return Configuration.Twitter.AppSecret; }
        }


        public static string FaceBookAppId
        {
            get { return Configuration.FaceBook.AppId; }
        }

        public static string FaceBookAppSecret
        {
            get { return Configuration.FaceBook.AppSecret; }
        }


        public static string JQueryCSSUrl
        {
            get { return Configuration.JQueryUi.Value; }
        }

        public static string ConnectionString
        {
            get { return Configuration.DataBaseConnectionString.Value; }
        }

        public static string CryptoSymetricKeyBase
        {
            get { return Configuration.CryptoSymetricKeyBase.Value; }
        }

        public static string ConcretBizClassAssembly
        {
            get
            {
                return LGTHelperFile.CombinePath(ConcretClassAssemblyPath, Configuration.ConcretBizClassAssembly.Value);
            }
        }

        public static string ConcretDaoClassAssembly
        {
            get
            {
                return LGTHelperFile.CombinePath(ConcretClassAssemblyPath, Configuration.ConcretDaoClassAssembly.Value);

            }
        }

        public static string ConcretDBContextAssembly
        {
            get
            {
                return LGTHelperFile.CombinePath(ConcretClassAssemblyPath, Configuration.ConcretDBContextAssembly.Value);
            }
        }

        public static string RedirectLoginPage
        {
            get { return Configuration.Redirects.LoginPage; }
        }


        public static string RedirectDefaultPage
        {
            get { return Configuration.Redirects.DefaultPage; }
        }

        public static string ConcretClassAssemblyPath
        {
            get { return Configuration.ConcretClassAssemblyPath.Value; }
        }

        public static bool UsingTransactionScopeProxy
        {
            get { return bool.Parse(Configuration.UsingTransactionScopeProxy.Value); }
        }

        public static bool UsingCSSReset
        {
            get { return bool.Parse(Configuration.UsingCSSReset.Value); }
        }

    }
}