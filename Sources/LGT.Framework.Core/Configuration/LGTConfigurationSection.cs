using System.Configuration;

namespace LGT.Framework.Core.Configuration
{
    /// <summary>
    /// Classe base de configuração de seção da LGT ela provê um método para recuperar valor de chaves da sessão
    /// </summary>
    public class LGTBaseConfigurationSection : ConfigurationSection
    {
        protected T GetKeyValue<T>(string key)
        {
            return (T)this[key];
        }
    }


    /// <summary>
    /// Classe base de configuração de elemento da LGT ela provê um método para recuperar valor de chaves da sessão
    /// </summary>
    public class LGTConfigurationElement : ConfigurationElement
    {
        protected T GetKeyValue<T>(string key)
        {
            return (T)this[key];
        }
    }

    /// <summary>
    /// Classe que provê acesso as seções de configuração das redes sociais com o uso das propriedades appID e appSecret
    /// </summary>
    public class LGTSocialNetworkSection : LGTConfigurationElement
    {
        [ConfigurationProperty("appId", DefaultValue = "", IsRequired = true)]
        public string AppId
        {
            get { return GetKeyValue<string>("appId"); }
        }

        [ConfigurationProperty("appSecret", DefaultValue = "", IsRequired = true)]
        public string AppSecret
        {
            get { return GetKeyValue<string>("appSecret"); }
        }
    }

    /// <summary>
    /// Classe que provê acesso a seção de configurações de elementos externos, como frameworks javascript ou uso de recursos CDN
    /// </summary>
    public class LGTExternalResourceSection : LGTConfigurationElement
    {
        [ConfigurationProperty("Value", DefaultValue = "", IsRequired = true)]
        public string Value
        {
            get { return GetKeyValue<string>("Value"); }
        }
    }

    /// <summary>
    /// Classe que provê acesso a seção de configurações de elementos externos, como frameworks javascript ou uso de recursos CDN
    /// </summary>
    public class Redirects : LGTConfigurationElement
    {
        [ConfigurationProperty("LoginPage", DefaultValue = "", IsRequired = true)]
        public string LoginPage
        {
            get { return GetKeyValue<string>("LoginPage"); }
        }

        [ConfigurationProperty("DefaultPage", DefaultValue = "", IsRequired = true)]
        public string DefaultPage
        {
            get { return GetKeyValue<string>("DefaultPage"); }
        }
    }

    /// <summary>
    /// Classe que permite acessar as configurações do arquivo web.config
    /// </summary>
    public class LGTSettingsSection : LGTBaseConfigurationSection
    {
        private static LGTSettingsSection _currentValues;
        private static readonly object LockObject = new object();
        public static LGTSettingsSection CurrentValues
        {
            get
            {
                if (_currentValues == null)
                {
                    lock (LockObject)
                    {
                        if (_currentValues == null)
                        {
                            _currentValues = (LGTSettingsSection)ConfigurationManager.GetSection("LGTSettings");
                        }
                    }
                }
                return _currentValues;
            }
        }

        [ConfigurationProperty("Twitter")]
        public LGTSocialNetworkSection Twitter
        {
            get { return (LGTSocialNetworkSection)this["Twitter"]; }
        }

        [ConfigurationProperty("Facebook")]
        public LGTSocialNetworkSection FaceBook
        {
            get { return (LGTSocialNetworkSection)this["Facebook"]; }
        }

        [ConfigurationProperty("JQueryUICSS")]
        public LGTExternalResourceSection JQueryUi
        {
            get { return (LGTExternalResourceSection)this["JQueryUICSS"]; }
        }

        [ConfigurationProperty("DataBaseConnectionString")]
        public LGTExternalResourceSection DataBaseConnectionString
        {
            get { return (LGTExternalResourceSection)this["DataBaseConnectionString"]; }
        }

        [ConfigurationProperty("CryptoSymetricKeyBase")]
        public LGTExternalResourceSection CryptoSymetricKeyBase
        {
            get { return (LGTExternalResourceSection)this["CryptoSymetricKeyBase"]; }
        }

        [ConfigurationProperty("ConcretClassAssemblyPath")]
        public LGTExternalResourceSection ConcretClassAssemblyPath
        {
            get { return (LGTExternalResourceSection)this["ConcretClassAssemblyPath"]; }
        }

        [ConfigurationProperty("ConcretBizClassAssembly")]
        public LGTExternalResourceSection ConcretBizClassAssembly
        {
            get { return (LGTExternalResourceSection)this["ConcretBizClassAssembly"]; }
        }

        [ConfigurationProperty("ConcretDaoClassAssembly")]
        public LGTExternalResourceSection ConcretDaoClassAssembly
        {
            get { return (LGTExternalResourceSection)this["ConcretDaoClassAssembly"]; }
        }

        [ConfigurationProperty("ConcretDBContextAssembly")]
        public LGTExternalResourceSection ConcretDBContextAssembly
        {
            get { return (LGTExternalResourceSection)this["ConcretDBContextAssembly"]; }
        }



        [ConfigurationProperty("Redirects")]
        public Redirects Redirects
        {
            get { return (Redirects)this["Redirects"]; }
        }

        [ConfigurationProperty("UsingTransactionScopeProxy")]
        public LGTExternalResourceSection UsingTransactionScopeProxy
        {
            get { return (LGTExternalResourceSection)this["UsingTransactionScopeProxy"]; }
        }

        [ConfigurationProperty("UsingCSSReset")]
        public LGTExternalResourceSection UsingCSSReset
        {
            get { return (LGTExternalResourceSection)this["UsingCSSReset"]; }
        }



    }
}