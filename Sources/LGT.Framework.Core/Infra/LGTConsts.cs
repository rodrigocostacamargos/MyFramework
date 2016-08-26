﻿namespace LGT.Framework.Core.Infra
{
    /// <summary>
    /// Constantes usadas no sistema
    /// </summary>
    public sealed class LGTConsts
    {
        #region Nested type: LGTApplicationVariableName

        public sealed class LGTApplicationVariableName
        {
            public static string LoggedUserKey
            {
                get
                {
                    return "LGTSocialHubLogInformation";
                }
            }
            public static string JsFileName
            {
                get { return "JSFileName"; }
            }

            public static string CssFileName
            {
                get { return "CSSFileName"; }
            }

            public static string FrameworkIsConfigured
            {
                get { return "FrameworkIsConfigured"; }
            }
        }

        #endregion

        #region Nested type: LGTExceptionMessage

        public sealed class LGTExceptionMessage
        {
            public static string FrameworkNotConfigured
            {
                get
                {
                    return
                        "A LGT Framework não foi corretamente inicializar, no arquivo Global.asax no evento Session_Start você deve ter uma chamada para LGTHelperFramework.Configure();";
                }
            }
            public static string NotFindClassForInterface
            {
                get
                {
                    return "Não foi possível encontrar uma classe que implemente a interface '{0}', o Assembly pesquisado foi: '{1}'.";
                }
            }

            public static string NotFindMethodInRealType
            {
                get
                {
                    return "Não foi possível encontrar o método '{0}' na classe '{1}', por favor verifique os parâmetro ou contate o administrador do sistema.";
                }
            }
        }

        #endregion

        #region Nested type: LGTFileNames

        public sealed class LGTFileNames
        {
            public static string JsJqueryTemplatePlugin
            {
                get
                {
                    return "http://ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js";
                }
            }

            public static string JsJqueryUrl
            {
                get { return "https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"; }
            }

            public static string JsJqueryUi
            {
                get { return "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"; }
            }

            public static string CssUiReset
            {
                get { return "http://yui.yahooapis.com/3.3.0/build/cssreset/reset-min.css"; }
            }

            public static string CssPrincipal
            {
                get { return "/Resources/CSS/CssPrincipal.css"; }
            }

            public static string JsPrincipal
            {
                get { return "/Resources/JS/JSPrincipal.js"; }
            }
        }

        #endregion

        #region Nested type: LGTValidatorMessages

        public sealed class LGTValidatorMessages
        {
            public static string RequiredField(string pControlLabel)
            {
                return string.Format("O campo '{0}' é obrigatório.", pControlLabel);
            }
        }

        #endregion
    }
}