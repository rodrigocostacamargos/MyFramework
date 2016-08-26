using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LGT.Framework.Core.Domain;
using LGT.Framework.Core.Expcetions;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Infra;
using LGT.Framework.Core.Interfaces.ControllerView;

namespace LGT.Framework.Core.WebControls
{
    public class LGTPage : Page
    {
        /// <summary>
        /// Adiciona um arquivo JS ao Header da página
        /// </summary>
        /// <param name="pSrcJavaScript"></param>
        protected void RegisterJS(string pSrcJavaScript)
        {
            var jsFile = new HtmlGenericControl("script");
            jsFile.Attributes["type"] = "text/javascript";
            jsFile.Attributes["src"] = pSrcJavaScript;
            Page.Header.Controls.AddAt(0, jsFile);

        }
        /// <summary>
        /// adiciona um arquivo CSS ao Header da página
        /// </summary>
        /// <param name="pSrcCss"></param>
        protected void RegisterCSS(string pSrcCss)
        {

            var cssFile = new HtmlLink { Href = pSrcCss };
            cssFile.Attributes["rel"] = "stylesheet";
            cssFile.Attributes["type"] = "text/css";
            cssFile.Attributes["media"] = "all";
            Page.Header.Controls.AddAt(0, cssFile);

        }

        /// <summary>
        /// Registra o arquivo de Javasript do Jquery e JqueryUI e o arquivo JS default da framework da LGT
        /// </summary>
        protected virtual void RegisterJSDefault()
        {
            RegisterJS(LGTHelperHTTP.ResolveApplicationUrl(LGTConsts.LGTFileNames.JsPrincipal, true));
            
            RegisterJS(LGTConsts.LGTFileNames.JsJqueryTemplatePlugin);
            
            RegisterJS(LGTConsts.LGTFileNames.JsJqueryUi);

            RegisterJS(LGTConsts.LGTFileNames.JsJqueryUrl);
        }
        /// <summary>
        /// Registra o estilo CSS do JqueryUI definio no web.config e o arquivo de css reset do laboratório do Yahoo 
        /// e o arquivo CSS default da framework LGT
        /// </summary>
        protected virtual void RegisterCSSDefault()
        {

            RegisterCSS(LGTHelperHTTP.ResolveApplicationUrl(LGTConsts.LGTFileNames.CssPrincipal, true));

            RegisterCSS(LGTHelperConfiguraton.JQueryCSSUrl);

            RegisterCSS(LGTConsts.LGTFileNames.CssUiReset);

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!LGTHelperFramework.FrameworkIsConfigured)
                throw new LGTFrameworkNotConfiguredExpcetion();

            //registra o estilo default
            RegisterCSSDefault();
            //registra o arquivo JS default
            RegisterJSDefault();

        }
        protected void MessageBoxShow(string text)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "JSAlert", string.Format("alert('{0}')", text), true);
        }
    }

    public class LGTLoggedPage : LGTPage
    {
        protected virtual bool RequiredLoggin
        {
            get { return true; }
        }
        public LGTLoggedPage()
        {
            this.Load += LGTLoggedPage_Load;
        }

        void LGTLoggedPage_Load(object sender, EventArgs e)
        {
            //se está autenticado ou não requer login na página sai fora
            if ((this.CurrentUser.Autenticated) || (!RequiredLoggin)) return;

            //caso contrário força o redirect
            var url = LGTHelperHTTP.ResolveApplicationUrl(LGTHelperConfiguraton.RedirectLoginPage);
            System.Web.HttpContext.Current.Response.Redirect(url);
        }

        public LoggedUser CurrentUser
        {
            get { return LoggedUser.Current; }
        }
    }


    public class LGTPageMVC<T> : LGTLoggedPage, ILGTBaseView
        where T : class, ILGTBaseController
    {
        private T _currentControler;
        protected T CurrentControler
        {
            get
            {
                if (_currentControler == null)
                {
                    lock (this)
                    {
                        if (_currentControler == null)
                        {
                            _currentControler = (T)Activator.CreateInstance(typeof(T), new object[] { this });

                        }
                    }
                }
                return _currentControler;
            }
        }

        public void MostraTexto(string pTexto)
        {

            this.MessageBoxShow(pTexto);
        }
    }
}