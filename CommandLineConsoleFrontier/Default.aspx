<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CommandLineConsoleFrontier._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Azure Command Line Console</title>
</head>
<style type="text/css">
    body
    {
        background-color: #e1ddd9;
        font-size: 12px;
        color: #564b47;
        padding: 20px;
        margin: 0px;
        text-align: center;
    }
    #inhalt
    {
        text-align: left;
        vertical-align: middle;
        margin: 0px auto;
        padding: 0px;
        width: 550px;
        background-color: #ffffff;
        border: 1px dashed #564b47;
    }
</style>
<body>
    <center>
        <h1 style="text-align: center">
            Azure Command Line Console</h1>
        <form id="commandForm" runat="server">
        <div style="width: 90%; text-align: center;" align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <div style="width: 65%;">
                            <div style="float: left; width: 45%;">
                                <table border="0">
                                    <tr>
                                        <td style="text-align: left">
                                            Path
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pathTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            Command*
                                        </td>
                                        <td>
                                            <asp:TextBox ID="commandTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            Parameters
                                        </td>
                                        <td>
                                            <asp:TextBox ID="parametersTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="processCustomizedCommandButton" runat="server" OnClick="processCustomizedCommandButton_Click"
                                                Text="Process Customized Command" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            try &quot;ver&quot; as Command, keep others empty.
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="float: right; width: 35%;">
                                <table border="0">
                                    <tr>
                                        <td>
                                            <asp:Button ID="applicationsCommandButton" runat="server" Text="Applications" OnClick="applicationsCommandButton_Click"
                                                Width="120px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="processesCommandButton" runat="server" Text="Processes" OnClick="processesCommandButton_Click"
                                                Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="servicesCommandButtom" runat="server" Text="Services" OnClick="servicesCommandButtom_Click"
                                                Width="120px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="performanceCommandButton" runat="server" OnClick="performanceCommandButton_Click"
                                                Text="Performance" Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="networkingCommandButton" runat="server" OnClick="networkingCommandButton_Click"
                                                Text="Networking" Width="120px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="usersCommandButton" runat="server" OnClick="usersCommandButton_Click"
                                                Text="Users" Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            these are predefined commands.
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                        <div>
                            <asp:TextBox ID="resultTextBox" runat="server" Height="400px" TextMode="MultiLine"
                                Width="800px"></asp:TextBox>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </form>
        <h3 style="text-align: right">
            Prototype by: Liang (lzhao@cse.unsw.edu.au)</h3>
    </center>
</body>
</html>
