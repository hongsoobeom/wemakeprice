<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodingTestPage.aspx.cs" Inherits="CodingTest.CodingTestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="codetable">
                <colgroup>
                    <col style="width:150px;" />
                    <col style="width:200px;" />
                </colgroup>
                <tr>
                    <td>[입력]</td>
                    <td></td>
                </tr>
                <tr>
                    <td>URL</td>
                    <td><input id="txt_URL" type="text" style="width:200px;" runat="server" /></td>
                </tr>
                <tr>
                    <td>Type</td>
                    <td>
                        <select id="cmb_Type" style="width:200px;" runat="server">
                            <option>HTML 태그 제외</option>
                            <option>Text 전체</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>출력 단위 묶음</td>
                    <td><input id="txt_Unit" type="text" style="text-align:right; width:200px;" value="100" runat="server"/></td>
                </tr>
                <tr>
                    <td></td>
                    <td id="btn_Run" style="text-align:right;"><input type="button" value="출 력" runat="server" onserverclick="Btn_Run_Click" /></td>
                </tr>
                <tr>
                    <td>[출력]</td>
                    <td></td>
                </tr>
                <tr>
                    <td>몫 : </td>
                    <td id="txt_Value" style="word-break:break-all;" runat="server"></td>
                </tr>
                <tr>
                    <td>나머지 : </td>
                    <td id="txt_Other" style="word-break:break-all;" runat="server"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
