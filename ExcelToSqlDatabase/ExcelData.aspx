<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelData.aspx.cs" Inherits="ExcelToSqlDatabase.ExcelData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 213px;
        }
        .auto-style2 {
            width: 213px;
            height: 65px;
        }
        .auto-style3 {
            height: 65px;
            width: 345px;
        }
        .auto-style4 {
            width: 345px;
        }
        .auto-style5 {
            background-color: #FF9900;
        }
        .auto-style6 {
            background-color: #CCFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        Import Excel Data to Sql Database</p>
    <p>
        Upload Excel file and Read Data Then Save to SQL Server in ASP.NET</p>
        <table class="auto-style5" style="width: 46%;">
            <tr>
                <td class="auto-style2">Upload Excel File</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style6" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="Button1" runat="server" BorderColor="#CC6600" ForeColor="#990000" Text="Upload And Save To Sql Server" OnClick="Button1_Click1" style="height: 29px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    </form>
    
</body>
</html>
