<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="個人資料.aspx.cs" Inherits="WebApplication1.test" %>

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
        margin:1.5cm 1.5cm 1.0cm 2.0cm;
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
 
<p align="center"><font face="標楷體" style="font-size: 17pt">台中榮民總醫院研究人才個人網資料
<br><asp:Label ID="Label1" runat="server" Text=""></asp:Label><b><asp:Label ID="Label2" runat="server" Text=""></asp:Label></b>
</font> </p>
<p align="center"><font face="標楷體" style="font-size: 17pt">目錄
</font> 
<p style="text-align: left"><font face="標楷體" style="font-size: 14pt">
一、	基本資料<br>
二、	研究成果<br>
三、	研發成果智慧財產權<br>
四、	研究計畫<br>
五、	產學合作<br>
六、	院內服務<br>
七、	院外服務<br>
八、	邀請演講<br>
九、	獲獎<br>
十、	其他特殊研究成果<br>

</font> </p> 
<p align="center"> 
<br clear=all style='page-break-before:always'>
<span style="font-size: 22.0pt; font-family: 標楷體; color: black; letter-spacing: 2.0pt">
台中榮民總醫院研究人才個人網資料</span></p>
</p>
<p style="text-align: left">　</p>
<p class="MsoNormal" style="text-indent: -32.4pt; margin-left: 25.3pt; margin-right: 0cm; margin-top: 2.0pt; margin-bottom: .0001pt">
<b><span style="font-size: 16.0pt; font-family: 標楷體; color: blue">   一、基本資料</span></b></font>
<br>
<div align="center">
    <TABLE BORDER=1 width=100% cellspacing="0" cellpadding="0" style="border-collapse: collapse" bordercolor="#111111">
    <font >
	     <TR width=100%><TD width="147" align="left" >
			<p><b><font face="標楷體" >中文姓名</font></b></TD>
         <TD align="left" width="456"><font face="標楷體"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></font>　</TD>
			<TD align="left" width="120"><b><font face="標楷體" ><asp:Label ID="Label4" runat="server" Text="英文姓名"></asp:Label></font></b></TD>
         <TD align="left" width="196"><font size="3" face="Time and romans"></font>　</TD></TR>         
	     <TR><TD align="left" width="147"><font face="標楷體" ><b>性別</b></TD>
         <TD align="left" width="456"><font face="標楷體"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></TD>
         <TD align="left" width="120">
			<p><b><font face="標楷體" >出生日期</b></TD>
         <TD align="left"><font face="標楷體"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></TD></TR>
	     <TR><TD align="left" width="147"><b><font face="標楷體" >聯絡地址</font></b></TD>
         <TD align="left" width="772" colspan="3"><font face="標楷體">　</TD></TR>                     
	     <TR><TD align="left" width="147"><b><font face="標楷體" >聯絡電話(公)</font></b></TD>
         <TD align="left" width="456"><font face="Time and romans">　</TD>
         <TD align="left" width="120">
			<p><b><font face="標楷體" >(宅)</font></b></TD>
         <TD align="left"><font face="Time and romans">　</TD></TR>                     
	     <TR><TD align="left" width="147"><b><font face="標楷體" >傳真號碼</font></b></TD>
         <TD align="left" width="456"><font face="Time and romans">　</TD>
         	<TD align="left" width="120"><b><font face="標楷體" >E-mail</font></b></TD>
         <TD align="left" width="196"><font face="Time and romans"></font></font>　</TD>
         </TR>
	                               
    </TABLE>  
	</div>

<p>
<p>　<p class="MsoNormal" style="margin-right:9.5pt"><b>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">二、研究成果</span></b></p>
<b>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">（<span lang="EN-US">A</span>）期刊發表</span></b></p>
<H2 ALIGN=left>
<%--<FONT face=Times New Roman><CENTER><div align=center><TABLE width=100% BORDER=0 style=text-align:justify;text-justify:inter-ideograph;line-height:125% ><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>1.</TD><TD valign=top>&nbsp;</TD></TR><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>2.</TD><TD valign=top>1234. 123. <b>AATCC REVIEW</b> 2020;12(1):10 (SCI).(Impact factor: 0.364;Rank: 83.33%)<font face="標楷體">第一</font></TD></TR><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>3.</TD><TD valign=top>1234. 123. <b>AATCC REVIEW</b> 2020;12(1):10 (SCI).(Impact factor: 0.364;Rank: 95.65%)<font face="標楷體">第一</font></TD></TR><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>4.</TD><TD valign=top>1234. 123. <b>AATCC REVIEW</b> 2020;12(1):10 (SCI).(Impact factor: 0.364;Rank: 92.96%)<font face="標楷體">第一</font></TD></TR><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>5.</TD><TD valign=top>234. 234. <b>ACADEMIC MEDICINE</b> 2020;2(100):121 (SCI).(Impact factor: 4.937;Rank: 2.44%)<font face="標楷體">第一</font></TD></TR><TR width=100% style=word-break:normal><FONT face=Times New Roman><TD valign=top>6.</TD><TD valign=top>234. 234. <b>ACADEMIC MEDICINE</b> 2020;2(100):121 (SCI).(Impact factor: 4.937;Rank: 7.14%)<font face="標楷體">第一</font></TD></TR></TABLE></div></CENTER></FONT>--%>
<p class="MsoNormal" style="margin-right:9.5pt"><b>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">（<span lang="EN-US">B</span>）專書發表</span></b>
<br>


<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="87"><b><font face="標楷體">出版年度</font></b></td><td width="273"><b><font face="標楷體">作者</font></b></td><td>
    <b>
    <font face="標楷體">專書名稱</font></b></td><td width="302"><b><font face="標楷體">出版社/學術專書</font></b></td>
   </tr>

<%--   <tr>
   <td width="87"><font face="Time and romans">1900　</font></td>
   <td width="273"><font face="標楷體">1230　</font></td>
   <td><font face="標楷體">1230　</font></td>
   <td width="302"><font face="標楷體">23　</font></td>   
   </tr>--%>
   
</table>
<p class="MsoNormal" style="margin-right:9.5pt"><b>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">（<span lang="EN-US">C</span>）研討會發表</span></b></p>
<%--<FONT face=Times New Roman><CENTER><TABLE width=100% style=text-align:justify;text-justify:inter-ideograph;line-height:125% BORDER=0><TR width=100% % style=word-break:normal><FONT face=Times New Roman><TD valign=top>1.</TD><TD valign=top>23423, 4324,234234,,2021</TD></TR></TABLE></CENTER></FONT>--%>
<p class="MsoNormal" style="margin-right:9.5pt"><b>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">三、研發成果智慧財產權：</span></b></p>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">（<span lang="EN-US">A</span>）專利</span></p>
<p>


<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td><b><font face="標楷體">專利名稱</font></b></td>
    <td><b><font face="標楷體">專利國別</font></b></td><td><b><font face="標楷體">國內/外</font></b></td>
    <td><b><font face="標楷體">發明人</font></b></td><td><b><font face="標楷體">專利權人</font></b></td>
    <td><b><font face="標楷體">專利期間期間</font></b></td>
   </tr>

<%--   <tr><font face="標楷體">
   <td>4234　</td>
   <td>234　</td>
   <td>國內　</td>   
   <td>234　</td>
   <td>234　</td>
   </font>
   <font face="Times New Roman">
   <td>2021/03/17至2021/03/25　</td>
   </font>
   </tr>--%>
   
</table>
<p class="MsoNormal" style="text-align: justify; text-justify: inter-ideograph; line-height: 16.0pt; margin-top: 6.0pt">
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue">（<span lang="EN-US">B</span>）技術授權</span></p>
<p>


<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td><b><font face="標楷體">技術名稱</font></b></td><td><b><font face="標楷體">授權單位</font></b></td>
    <td><b><font face="標楷體">被授權單位</font></b></td><td><b><font face="標楷體">合約期間</font></b></td>
    <td><b><font face="標楷體">權益金(元)</font></b></td>
   </tr>

<%--   <tr><font face="標楷體">
   <td>測試技術　</td>
   <td>123　</td>
   <td>123　</td>
   </font>
   <font face="Times New Roman">
   <td>2021/03/17至2021/03/31　</td>
   <td>2342　</td>
   </font>
   </tr>--%>
   
</table>
　</h2>
<span style="font-size: 16.0pt; font-family: 標楷體; color: blue"><b>四、研究計畫</b></span></b></h2>
</p>
</p>
<p>


<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="6%"><b><font face="標楷體">年度</font></b></td><td width="297"><b><font face="標楷體">計畫名稱</font></b></td>
    <td width="57"><b><font face="標楷體">類型</font></b></td><td width="113"><b><font face="標楷體">計畫內擔任之工作</font></b></td>
    <td width="122"><b><font face="標楷體">執行期間</font></b></td><td width="136"><b><font face="標楷體">經費提供單位</font></b></td>
    <td width="137"><b><font face="標楷體">執行經費(元)</font></b></td>
   </tr>

<%--   <tr>
   <font face="Times New Roman">
   <td width="6%"> 2008　</td>
   </font>
   <font face="標楷體">
   <td width="297">testest　</td>
   <td width="57">個人                　</td>
   <td width="113">主持人　</td>
   </font>
   <font face="Times New Roman">
   <td width="122"> 2021/03/17~2021/03/25　</td>
   </font>
   <font face="標楷體">
   <td width="136">資訊室　</td>
   </font>
   <font face="Times New Roman">
   <td width="137"> 10000　</td>
   </font>
   </tr>--%>
   
</table>
<p>
<H2 ALIGN=left>
<font face="標楷體" color=blue>
<b>
五、產學合作</span></b> &nbsp;&nbsp;
</h2>
</p>
<p>


<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="53"><b><font face="標楷體">年度</font></b></td><td width="317"><b><font face="標楷體">計畫名稱</font></b></td>
    <td width="262"><b><font face="標楷體">合作廠商</font></b></td><td width="168"><b><font face="標楷體">執行期間</font></b></td>
    <td width="136"><b><font face="標楷體">執行經費(元)</font></b></td>
   </tr>

<%--   <tr>
   <font face="Times New Roman">
   <td width="53"> 2021　</td>
   </font>
   <font face="標楷體">
   <td width="317">1231231　</td>
   <td width="262">測測測試　</td>
   <td width="168"><font face="Times New Roman"> 2021/03/18~2021/03/25　</font></td>
   <td width="136"><font face="Times New Roman"> 100000　</font></td>
   </tr>--%>
   
</table>
<p>
<H2 ALIGN=left><font face="Times New Roman"><b><span style="font-size: 16.0pt; font-family: 標楷體; color: blue">六、院內服務：</font></h2>
</p>
<p>
<font face="標楷體">


</font>

<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="54"><b><font face="標楷體">年度</font></b></td>
    <td width="102"><b><font face="標楷體">服務類別</font></b></td>
    <td width="502"><b><font face="標楷體">服務單位</font></b></td>
    <td width="393"><b><font face="標楷體">服務職稱</font></b></td>
   </tr>

<%--   <tr>  
   <td width="54"><font face="Times New Roman">2020~2021　</font></td>
   <td width="102"><font face="標楷體">行政主管 </font> </td>
   <td width="502"><font face="標楷體">123　</font></td>
   <td width="393"><font face="標楷體">123　</font></td>
   </tr>--%>
   
</table>
<p>
<H2 ALIGN=left><span style="font-size: 16.0pt; font-family: 標楷體; color: blue">
<font face="標楷體"><b>七、院外服務：</b> &nbsp;&nbsp;</font></h2>
</p>
<p>
<font face="Times New Roman">


</font>

<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="43"><b><font face="標楷體">年度</font></b></td>
    <td width="270"><b><font face="標楷體">服務類別</font></b></td>
    <td width="324"><b><font face="標楷體">服務單位</font></b></td>
    <td width="280"><b><font face="標楷體">服務職稱</font></b></td>
   </tr>

<%--   <tr>
   <td width="43"><font face="Times New Roman">2021~2021　</font></td>
   <td width="270"><font face="標楷體"> </font> </td>
   <td width="324"><font face="標楷體">123123　</font></td>
   <td width="280"><font face="標楷體">321321231　</font></td>
   </tr>--%>
   
</table>
<p>
<H2 ALIGN=left><font face="標楷體"><b>八、邀請演講：</b>&nbsp;</font></h2>
<p>
<font face="Times New Roman">


</font>

<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td><b><font face="標楷體">時間(起)</font></b></td><td><b>
	<font face="標楷體">時間(迄)</font></b></td>
    <td><b><font face="標楷體">演講名稱</font></b></td><td><b>
	<font face="標楷體">類別</font></b></td>
    <td><b><font face="標楷體">邀請單位/會議</font></b></td>
   </tr>

<%--   <tr>
   <td><font face="Times New Roman"> 2021/3/30　</font></td>
   <td><font face="Times New Roman"> 2021/3/31　</font></td>
   <td><font face="標楷體">123123　</font></td>
   <td><font face="Times New Roman">Keynote　</font></td>
   <td><font face="標楷體">1231232　</font></td>
   </tr>--%>
   
</table>


<H2 ALIGN=left><font face="標楷體"><b>
九、獲獎</b></font></font><font color="#800080" face="標楷體" size="3"><b><font face="Times New Roman">
<font color="#800080" face="標楷體" size="3">&nbsp;&nbsp; </font> </font> </h2>
</p>
<p>
<font face="Times New Roman">


</font>

<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="53"><b><font face="標楷體">年度</font></b></td><td width="323"><b>
	<font face="標楷體">提供單位</font></b></td>
    <td width="355"><b><font face="標楷體">獲獎項目</font></b></td><td width="217"><b>
	<font face="標楷體">獲獎日期</font></b></td>
   </tr>

<%--   <tr><font face="標楷體">
   <td width="53"><font face="Times New Roman">2021 </font> </td>
   <td width="323"><font face="標楷體">789 </font> </td>
   <td width="355"><font face="標楷體">789 </font> </td>
   <td width="217"><font face="Times New Roman">20210101 </font> </td>
   </tr>

   <tr><font face="標楷體">
   <td width="53"><font face="Times New Roman">2020 </font> </td>
   <td width="323"><font face="標楷體">456 </font> </td>
   <td width="355"><font face="標楷體">456 </font> </td>
   <td width="217"><font face="Times New Roman">20200101 </font> </td>
   </tr>

   <tr><font face="標楷體">
   <td width="53"><font face="Times New Roman">2019 </font> </td>
   <td width="323"><font face="標楷體">123 </font> </td>
   <td width="355"><font face="標楷體">123 </font> </td>
   <td width="217"><font face="Times New Roman">20190101 </font> </td>
   </tr>--%>
   
</table>

<H2 ALIGN=left>
<font face="標楷體">
<font color="#0000FF">十、其他特殊研究成果</font>
</font>
<font face="Times New Roman">&nbsp;&nbsp; 
</font> </h2>
<p>

<table BORDER=1 width=100% cellspacing=0 cellpadding=0 style='border-collapse: collapse' bordercolor=#111111>
   <tr>
    <td width="628"><b><font face="標楷體">其他特殊研究成果</font></b></td>
   </tr>

<%--   <tr><font face="標楷體">
   <td width="628"><font face="標楷體">testtest123
　</font></td>
   </tr>--%>
   
</table>

 </font>
</font>
</b>
  </span>
  </body>

</html>


