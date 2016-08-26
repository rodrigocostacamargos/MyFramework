using System.Web;
using LGT.Framework.Core.Infra;
using LGT.Framework.Core.Resources;

namespace LGT.Framework.Core.Helper
{
    public sealed class LGTHelperFramework
    {
        /// <summary>
        /// Objeto usado para garantir um LOCK para gerar os arquivos de css quando necessário para evitar que mais 
        /// de uma requisição venha a gerar algum recurso.
        /// </summary>
        private static readonly object ObjLock = new object();


        /// <summary>
        /// método privado que gera os arquivos JS e CSS da Framework
        /// </summary>
        /// <param name="pCssFilePath">Caminho onde o arquivo CSS é gerado</param>
        /// <param name="pJsFilePath">Caminho onde o arquivo JS é gerado</param>
        private static void ConfiguraResourceFiles(string pCssFilePath, string pJsFilePath)
        {
            //configura o conteudo do arquivo JS que será gerado para cada página
            LGTHelperFile.GenerateResourceFile(LGTWebResources.GetJsFileContent(),
                                               HttpContext.Current.Request.MapPath("./" + pJsFilePath));

            //configura o conteudo do arquivo CSS que será gerado para cada página
            LGTHelperFile.GenerateResourceFile(LGTWebResources.GetCssFileContent(),
                                               HttpContext.Current.Request.MapPath("./" + pCssFilePath));
        }

        /// <summary>
        /// construtor privado para evitar o uso fora do contexto
        /// </summary>
        private static void GenerateImageFiles()
        {
            foreach (var img in LGTWebResources.GetImageContent())
            {
                LGTHelperFile.GenerateImageResourceFile(img.Value, HttpContext.Current.Request.MapPath(img.Key));
            }
        }
        /// <summary>
        /// Propriedade de define se o framework já foi configurado no contexto da aplicação web
        /// </summary>
        public static bool FrameworkIsConfigured
        {
            get
            {
                var flagConfigured =
                    HttpContext.Current.Application[LGTConsts.LGTApplicationVariableName.FrameworkIsConfigured];
                return flagConfigured != null && flagConfigured.ToString().Equals("1");
            }
        }

        /// <summary>
        /// Configura o framework no contexto da aplicação web, gera arquivos JS e CSS usados pelo sistema base, bem como as imagens
        /// </summary>
        public static void Configure()
        {
            if (FrameworkIsConfigured) return;
            lock (ObjLock)
            {
                //cria os arquivos de JS e CSS do framework
                ConfiguraResourceFiles(LGTConsts.LGTFileNames.CssPrincipal, LGTConsts.LGTFileNames.JsPrincipal);
                //cria os arquivos de imagem do framework
                GenerateImageFiles();
                //ajusta a flag para indicar que já foi configurado
                HttpContext.Current.Application[LGTConsts.LGTApplicationVariableName.FrameworkIsConfigured] = 1;
            }
        }
    }
}