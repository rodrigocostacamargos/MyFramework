<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LGT.Framework.Core.Portal.Login" %>

<%@ Register Assembly="LGT.Framework.Core.WebControls" Namespace="LGT.Framework.Core.WebControls"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:LGTSocialHubLogin runat="server" id="LGTSocialHubLogin1">
        </cc1:LGTSocialHubLogin>
    </div>
    </form>
</body>
</html>
