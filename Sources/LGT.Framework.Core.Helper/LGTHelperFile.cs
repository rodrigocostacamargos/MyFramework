using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace LGT.Framework.Core.Helper
{
    public sealed class LGTHelperFile
    {
        public static void CreateDirecoty(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public static void GenerateResourceFile(string body, string filepath)
        {
            var path = filepath.Substring(0, filepath.LastIndexOf('\\') + 1);
            CreateDirecoty(path);
            File.WriteAllText(filepath, body, Encoding.Default);
        }

        public static void GenerateImageResourceFile(Image image, string filepath)
        {
            var path = filepath.Substring(0, filepath.LastIndexOf('\\') + 1);
            CreateDirecoty(path);
            //image.Save(filepath);
            var bitmap = new Bitmap(image);
            bitmap.Save(filepath);
        }

        /// <summary>
        /// baseado no array de bytes pBytes cria uma imagem 
        /// </summary>
        /// <param name="pBytes">array com as informações da imagem</param>
        /// <returns>Imagem criada</returns>
        public static Image GenerateImage(byte[] pBytes)
        {
            Image img = null;
            using (img = Image.FromStream(new MemoryStream(pBytes)))
            {

            }
            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public static string GetBase64StringFromImage(Image pImage)
        {
            byte[] pBytes;

            using (var ms = new MemoryStream())
            {
                pImage.Save(ms, pImage.RawFormat);
                pBytes = ms.ToArray();
            }
            return GetBase64StringFromByte(pBytes);
        }

        public static string GetBase64StringFromByte(byte[] pBytes)
        {
            return pBytes != null ? Convert.ToBase64String(pBytes) : string.Empty;
        }

        /// <summary>
        /// Combina dois caminhos .
        /// </summary>
        /// <param name="path1">O primeiro caminhao a ser combinado.</param>
        /// <param name="path2">O segundo caminhao a ser combinado.</param>
        /// <returns>Os dois caminhos combinados.</returns>
        public static string CombinePath(string path1, string path2)
        {
            var path2HasBackSlash = false;
            var path1HasBackSlash = false;

            if (path1.Length > 0)
                path1HasBackSlash = path1[path1.Length - 1].Equals('\\');

            if (path2.Length > 0)
                path2HasBackSlash = path2[0].Equals('\\');


            if (path1HasBackSlash)
                path1 = path1.Substring(0, path1.Length - 1);

            if (path2HasBackSlash)
                path2 = path2.Substring(1, path2.Length - 1);

            return string.Format("{0}\\{1}", path1, path2);
        }
    }
}