<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPI國科會.aspx.cs" Inherits="WebApplication1.test2" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>
	
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta http-equiv="Content-Language" content="zh-tw">
<title>全部資料列印(word)</title>
<style>
 @page
        {mso-page-border-surround-header:no;
        mso-page-border-surround-footer:no;}
@page Section1
        {size:595.3pt 841.9pt;
        margin:1.0cm 1.0cm 1.0cm 1.0cm;
        mso-header-margin:42.55pt;
        mso-footer-margin:49.6pt;
        mso-paper-source:0;
        layout-grid:18.0pt;}
div.Section1
        {page:Section1;}
-->
</style>
<div class=Section1 style='layout-grid:18.0pt'>
</div>

</head>
<body>
 <p class="MsoNormal" style="text-indent: -32.4pt; margin-left: 25.3pt; margin-right: 0cm; margin-top: 2.0pt; margin-bottom: .0001pt" align="center">
<b>
<span style="font-family: 標楷體"><font size="4">
研究人才研究表現指數(RPI)統計表
<br>國科會計畫申請參考用</font></span></b></p>

<font face="標楷體">
研究人才姓名:<asp:Label ID="Label1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
二級單位:<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
<br>
研究年資:<asp:Label ID="Label3" runat="server" Text=""></asp:Label>
</font>
<p class="MsoNormal" style="text-indent: -32.4pt; margin-left: 25.3pt; margin-right: 0cm; margin-top: 2.0pt; margin-bottom: .0001pt">
　</p>
<font face="標楷體">
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">
<p>

<table BORDER=1 width=853 cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
<font face="標楷體">
   <tr>
    <td width="56"><b>編號</b></td>
    <td width="517"><b>研究成果名稱及相關發表資料</b></td>
    <td width="70"><b>論文性質分類加權分數(C)</b></td>
    <td width="70"><b>刊登雜誌分類排名加權分數(J)</b></td>
    <td width="70"><b>作者排名加權分數(A)</b></td>
    <td width="70"><b>分數CxJxA</b></td>
   </tr>
</font>   

<font face="Times New Roman">
   <tr>
   
   <td width="56"><p align=center style='text-align:center'> &nbsp;　</td>   
   
   <td width="517">總積分　</td>
   <td width="70"><p align=center style='text-align:center'>　</td>
   <td width="70"><p align=center style='text-align:center'>　</td>
   <td width="70"><p align=center style='text-align:center'>　</td>
   <td width="70"><p align=center style='text-align:center'>　</td>
   </tr>
</font>
   
</table>
<p>
<!--1011109修改-->
<!--<font size="2">*僅列出計算西元2006年以後之資料</font>-->
<!--1030109修改 2007 to 2008-->
<font size="2">*僅列出計算西元2008年以後之資料</font>
</span></font>
 </body>

</html>

