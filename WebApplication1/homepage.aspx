<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
  *{
      font-weight:900;
  }
</style>
<div style="text-align:center">
    <h2>★ 歡迎<asp:Label ID="Label3" runat="server" Text="name"></asp:Label>
                同仁使用中榮研究人才個人網系統 ★</h2>
        </div>
            <center><div style="border-color: #3333FF; border:5px solid #3498db; text-align:center;
                      font-size:x-large; border-radius: 24px; width:1000px; background-color: #E3E3E3;height:120px">
                <a>資料最後更新日為:</a><asp:Label ID="Label2" runat="server" Text="日期"></asp:Label>
                <br />
                <a>煩請點選上方之各項項目，開始使用此系統，謝謝您!</a>
                <br />

                <a style="color:red">您尚未填寫研究年資，請儘速填寫!</a><asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#9900FF" href="\basic_infor.aspx">填寫研究年資由此去!</asp:LinkButton>             
            </div></center>
</asp:Content>
