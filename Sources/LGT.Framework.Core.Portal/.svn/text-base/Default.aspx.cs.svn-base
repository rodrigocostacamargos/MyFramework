using System;

namespace LGT.Framework.Core.Portal
{
    public partial class Login : LGT.Framework.Core.WebControls.LGTLoggedPage
    {
        protected override bool RequiredLoggin
        {
            get
            {
                return false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LGTSocialHubLogin1.ExecuteLogin += LGTSocialHubLogin1_ExecuteLogin;
        }


        EventArguments.LGTExecuteLoginEventArgs LGTSocialHubLogin1_ExecuteLogin(object sender, LGT.Framework.Core.EventArguments.LGTExecuteLoginEventArgs args)
        {
            this.MessageBoxShow("Sim botemo");
            if (!args.Autenticated)
                args.Autenticated = false;//this.CurrentControler.Autentica(args.Email, args.Pass);
            return args;
        }


    }
}