
using System;
using System.Web;
using LGT.Framework.Core.Enums;
using LGT.Framework.Core.Infra;

namespace LGT.Framework.Core.Domain
{

    public sealed class LoggedInformation
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public long Key { get; set; }
        public LoginType LoginType { get; set; }
    }

    public class LoggedUser
    {
        private enum Information
        {
            Email = 1,
            Nome = 2,
            Key = 3,
            Autenticated = 4
        }

        private LoggedUser()
        {

        }
        private static T GetInformation<T>(Information info)
        {
            var canUse = ((HttpContext.Current != null) && (HttpContext.Current.Session != null));
            object retorno = null;
            if (canUse)
            {
                var session = HttpContext.Current.Session;
                var information = (LoggedInformation)session[LGTConsts.LGTApplicationVariableName.LoggedUserKey];
                switch (info)
                {
                    case Information.Autenticated:
                        retorno = information != null;
                        break;
                    case Information.Email:
                        retorno = information.Email;
                        break;
                    case Information.Nome:
                        retorno = information.Name;
                        break;
                    case Information.Key:
                        retorno = information.Key;
                        break;


                }
            }
            return (T)retorno;
        }

        public bool Autenticated { get { return GetInformation<bool>(Information.Autenticated); } }
        public string Email { get { return GetInformation<string>(Information.Email); } }
        public string Nome { get { return GetInformation<string>(Information.Nome); } }
        public int Key { get { return GetInformation<int>(Information.Key); } }
        public static LoggedUser Current
        {
            get { return new LoggedUser(); }
        }
    }
}
