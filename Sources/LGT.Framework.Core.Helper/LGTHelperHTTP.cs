using System.Web;
using System.Web.UI;

namespace LGT.Framework.Core.Helper
{
    public sealed class LGTHelperHTTP
    {
        /// <summary>
        /// Obtém a página atual.
        /// Se não for possível utilizá-lo, retorna null.
        /// </summary>
        public static Page CurrentPage
        {
            get
            {
                return (CanUseRequest) && (HttpContext.Current.Handler is Page)
                           ? (Page)(HttpContext.Current.Handler)
                           : null;
            }
        }

        /// <summary>
        /// Obtém se o HttpRequest pode ser utilizado.
        /// </summary>
        public static bool CanUseRequest
        {
            get { return CanUseContext && HttpContext.Current.Request != null; }
        }

        /// <summary>
        /// Obtém se o HttpContext pode ser utilizado.
        /// </summary>
        public static bool CanUseContext
        {
            get { return HttpContext.Current != null; }
        }

        /// <summary>
        /// Retorna o caminho informado concatenado no caminho virtual corrente
        /// </summary>
        /// <param name="finalPath">Caminho final que é concatenado no virtual directory</param>
        /// <returns>Caminho concatenado</returns>
        public static string ResolveApplicationUrl(string finalPath)
        {
            return ResolveApplicationUrl(finalPath, false);
        }

        /// <summary>
        /// Obtém o caminho virtual completo para um caminho relativo.
        /// <example>
        /// string path = HttpHelper.GetVirtualPath("Image/LZCActionButton/new.png");
        /// O valor de path será: http://enderecoDoServidor/aplicacao/Image/LZCActionButton/new.png"
        /// </example>
        /// </summary>
        /// <param name="finalPath">Parte final do caminho relativo.</param>
        /// <param name="fullUrl">se deve retornar a URL completa</param>
        /// <returns>Retorna o caminho virtual completo: http:// + servidor + aplicação + finalPath</returns>
        public static string ResolveApplicationUrl(string finalPath, bool fullUrl)
        {
            string initialPath;
            if (fullUrl)
            {
                var httpsVar = HttpContext.Current.Request.ServerVariables.Get("HTTPS").ToLower();
                var host = HttpContext.Current.Request.ServerVariables.Get("HTTP_HOST");
                var protocol = (httpsVar.Equals("off") || string.IsNullOrEmpty(httpsVar))
                                      ? "http"
                                      : "https";
                var applicationPath = HttpContext.Current.Request.ApplicationPath;
                initialPath = string.Format("{0}://{1}{2}", protocol, host, applicationPath);
            }
            else
                initialPath = HttpContext.Current.Request.ApplicationPath.Equals("/")
                                  ? string.Empty
                                  : HttpContext.Current.Request.ApplicationPath;

            return HttpContext.Current == null
                       ? finalPath
                       : CombineHTTPPath(initialPath, finalPath.Replace("~", string.Empty));
        }


        /// <summary>
        /// Combina dois caminhos http.
        /// </summary>
        /// <param name="path1">O primeiro caminhao a ser combinado.</param>
        /// <param name="path2">O segundo caminhao a ser combinado.</param>
        /// <returns>Os dois caminhos combinados.</returns>
        public static string CombineHTTPPath(string path1, string path2)
        {
            var path2HasBackSlash = false;
            var path1HasBackSlash = false;

            if (path1.Length > 0)
                path1HasBackSlash = path1[path1.Length - 1].Equals('/');

            if (path2.Length > 0)
                path2HasBackSlash = path2[0].Equals('/');


            if (path1HasBackSlash)
                path1 = path1.Substring(0, path1.Length - 1);

            if (path2HasBackSlash)
                path2 = path2.Substring(1, path2.Length - 1);

            return string.Format("{0}/{1}", path1, path2);
        }
    }
}