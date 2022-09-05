<!--#include file="RsToTab.asp" -->
<%
	Security_Check session("security")	'權限檢查
%>	
<%
        
sql = "select distinct 'A' type,id.i_year year,ltrim(rtrim(isnull(id.author,'')))+'. '+isnull(id.paper_name,'')+'. '+'<b>'+isnull(id.journal_name,'')+'</b>'+' '+isnull(id.i_year,'')+';'+id.volume1+ case id.volume2 when '' then '' else '('+id.volume2+')' end+':'+isnull(id.page,'')+case isnull(cast(jd.impact_factor as varchar),'') when '' then '' else '. (Impact factor: '+isnull(cast(jd.impact_factor as varchar),'') end+case isnull(cast(jd.impact_factor as varchar),'') when '' then '' else ';Rank: '+isnull(cast(cast(jd.rank as money) as varchar),'')+'%)' end paper,"
sql =sql & " id.c_goal,id.a_goal,j_goal=case id.journal_type when 'SCI' then isnull(jd.j_goal,0.5) when 'SSCI' then isnull(jd.j_goal,0.5) when 'DI' then isnull(jd.j_goal,0.5) when 'EI' then 1  else 0.5 end,"
sql =sql & " case id.journal_type when 'SCI' then isnull(jd.j_goal,0.5) when 'SSCI' then isnull(jd.j_goal,0.5) when 'DI' then isnull(jd.j_goal,0.5) when 'EI' then 1 else 0.5 end*isnull(id.c_goal,0)*isnull(id.a_goal,0) CJA"
sql =sql & " from index_detail id left outer join journal_maxrank_detail_r5y jd on upper(replace(replace(replace(id.journal_name,',',''),' ',''),'&','and'))=upper(replace(replace(replace(jd.full_name,',',''),' ',''),'&','and'))"
sql =sql & " and convert(int,jd.j_year)=convert(int,id.i_year)-2"
sql =sql & " where id.user_id='" & session("uid") & "' "  
'1011109 change
'sql =sql & " and id.i_year>='2006'"
'1030101 change'
'sql =sql & " and id.i_year>='2007'"
'sql =sql & " and id.i_year>='2008'"
'sql =sql & " and id.i_year>='2009'"
sql =sql & " and id.i_year>='2014'"
sql =sql & " and id.is_rpi='Y' " 
sql =sql & " union all"
sql =sql & " select 'B' type, p_year year,'專利名稱:'+isnull(p_name,'')+' 發明人:'+isnull(inventer,'')+' 證書號碼:'+isnull(p_no,'')+' 國別:'+isnull(country,'')+' 專利期間:'+isnull(convert(char(10),start_date,111),'')+'~'+isnull(convert(char(10),end_date,111),''),"
sql =sql & " case when (country_type='F' and p_type='1') then 50  when (country_type='D' and p_type='1') then 40 when (country_type='F' and p_type in('2','3')) then 20 when (country_type='D' and p_type in('2','3')) then 15 else 0 end,1,1,"
sql =sql & "score=case when (country_type='F' and p_type='1') then 50  when (country_type='D' and p_type='1') then 40 when (country_type='F' and p_type in('2','3')) then 20 when (country_type='D' and p_type in('2','3')) then 15 else 0 end"
sql =sql & " from patent_detail"
sql =sql & " where is_rpi='Y'"
'1011109 change
'sql =sql & " and p_year>='2006'"
'1030101 change'
'sql =sql & " and p_year>='2007'"
'sql =sql & " and p_year>='2008'"
'sql =sql & " and p_year>='2009'"
sql =sql & " and p_year>='2014'"
sql =sql & " and user_id='" & session("uid") & "' "  
sql =sql &" union all"
sql =sql & " select 'C' type, t_year year, '技術名稱:'+t_name+' 技轉對象:'+approved_org+' 技轉金額:'+cast(cast(approve_amount as int) as varchar)+'元  技轉年度:'+cast(t_year as varchar),"
sql =sql & "  case  when approve_amount>=1000000 then 90 when (approve_amount>=500000 and approve_amount<1000000) then 75 when (approve_amount>=200000 and approve_amount<500000) then 60  when approve_amount<200000  then 50 else 0 end,1,1,"
sql =sql & " cja= case  when approve_amount>=1000000 then 90 when (approve_amount>=500000 and approve_amount<1000000) then 75 when (approve_amount>=200000 and approve_amount<500000) then 60  when approve_amount<200000  then 50 else 0 end"
sql =sql & " from tech_transfer"
sql =sql & " where is_rpi='Y'"
'1011109 change
'sql =sql & " and t_year>='2006'"
'1030101'
'sql =sql & " and t_year>='2007'"
'sql =sql & " and t_year>='2008'"
'sql =sql & " and t_year>='2009'"
sql =sql & " and t_year>='2014'"
sql =sql & " and user_id='" & session("uid") & "' "  
sql =sql & " union all"
sql =sql & " select 'D' type,'3000' year,'總積分',null,null,null,sum(score) from rpi_detail"
sql = sql & " where user_id='" & session("uid") & "' "  
sql =sql & " union all"
'1001130 change
'sql =sql & " select 'F' type,'3001' year,'研究表現指數(RPI)【積分x100/指標上限滿分】',null,null,null,round(sum(score)*100/case fu.research_year_type when '1' then 750 when '2' then 525 when '3' then 375 when '4' then 225 else 0 end,3)"
sql =sql & " select 'F' type,'3001' year,'研究表現指數(RPI)【積分x100/指標上限滿分】',null,null,null,round(sum(score)*100/case fu.research_year_type when '1' then 525 when '2' then 300 when '3' then 150 when '4' then 75 else 0 end,4)"
sql =sql & " from rpi_detail rd,fnd_user fu"
sql =sql & " where rd.user_id=fu.user_id"
sql = sql & " and rd.user_id='" & session("uid") & "' "  
sql =sql & " group by fu.research_year_type"
sql =sql & " order by type,year"

%>
<% 
    sql1="select d.dept_name,fu.c_name,"
    '1001130 change
    'sql1=sql1 & " research_year=case fu.research_year_type when '1' then '滿5年以上(選最佳10篇)' when '2' then '滿4年(選最佳7篇)' when '3' then '滿3年(選最佳5篇)' when '4' then '未滿3年(選最佳3篇)' else '未選取' end"
    sql1=sql1 & " research_year=case fu.research_year_type when '1' then '滿5年以上(選最佳7篇)' when '2' then '滿4年(選最佳7篇)' when '3' then '滿3年(選最佳5篇)' when '4' then '未滿3年(選最佳3篇)' else '未選取' end"
    sql1=sql1 & " from fnd_user fu,dept d "
    sql1=sql1 & " where fu.dept_id=d.dept_id"
    sql1 = sql1 & " and user_id='" & session("uid") & "' "  

    Set rs1 = Server.CreateObject("ADODB.Recordset")
	Set rs1 = GetRs(sql1)
	if not rs1.eof then	
	c_name=rs1("c_name")
	dept_name=rs1("dept_name")
	research_year=rs1("research_year")
%>
<% 
Response.ContentType = "application/msword"
Response.AddHeader "content-disposition","attachment;filename="& rs1("c_name")&".doc" 
%>
<%
 	Set rs = Server.CreateObject("ADODB.Recordset")
	Set rs = GetRs(sql)
	if not rs.eof then
%>	
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=big5">
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
<br></font></span></b></p>

<font face="標楷體">
研究人才姓名:<%response.write "" & c_name & ""%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
二級單位:<%response.write "" & dept_name & ""%>
<br>
研究年資:<%response.write "" & research_year & ""%>
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
<%	
     ' Part II：輸出資料表的「內容」
     i_no=1
     While Not rs.EOF
%>
<font face="Times New Roman">
   <tr>
   <%if (rs("paper")="總積分" or rs("paper")="研究表現指數(RPI)【積分x100/指標上限滿分】") then%>
   <td width="56"><p align=center style='text-align:center'> &nbsp;　</td>   
   <%else%>
   <td width="56"><p align=center style='text-align:center'> &nbsp;<%=i_no%>　</td>
   <%end if%>
   <td width="517"><%=rs("paper")%>　</td>
   <td width="70"><p align=center style='text-align:center'><%=rs("c_goal")%>　</td>
   <td width="70"><p align=center style='text-align:center'><%=rs("j_goal")%>　</td>
   <td width="70"><p align=center style='text-align:center'><%=rs("a_goal")%>　</td>
   <td width="70"><p align=center style='text-align:center'><%=rs("cja")%>　</td>
   </tr>
</font>
<%
i_no=i_no+1
 rs.MoveNext
Wend 
%>   
</table>
<p>
<!--1011109修改-->
<!--<font size="2">*僅列出計算西元2006年以後之資料</font>-->
<!--1030101  2007年 修改為 2008年
1040327 2008 change to 2009
-->
<font size="2">*僅列出計算西元2014年以後之資料</font>
</span></font>
 </body>

</html>
<% end if%><% end if%>
