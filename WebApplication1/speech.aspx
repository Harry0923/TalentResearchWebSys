<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="speech.aspx.cs" Inherits="WebApplication1.specch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#datepicker").datepicker();
          $("#datepicker2").datepicker();
      });
  </script>
<style>
    .auto-style1 {
            height: 47px;
    }

    *{
        font-weight:900;
    }

    .btn-info{
        width:50px;
        height:50px;
        margin:20px;
    }

     .btn-primary{
        border-radius:30px;
        margin:5px;
    }

    .btn-danger{
        border-radius:30px;
        margin:5px;
    }

</style>

    <div style="text-align:center">
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才邀請演講資料★</h2>
        <button id="btnNew" runat ="server" class="btn btn-info badge rounded-circle" onserverclick="btnNew_Click">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="tableData" runat="server" class="table table-info table-hover table-bordered align-middle"></table>
            </div>
        </div>
    </div>
        <div>
<table id="Newtable" runat="server" class="table table-bordered table table-hover">
  <thead>
    <tr>
      <th scope="col">研究人才演講資料新增<input id="PK" runat="server"/></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="txbname" runat="server" placeholder="研究人才姓名" /></td>
    </tr>
     <tr>
      <th scope="row">(西元)年度:</th>
      <td><input id="txbYear" runat="server" placeholder="EX:YYYY" /></td>
    </tr>
    <tr>
      <th scope="row">演講名稱:</th>
      <td><input id="txbSpeechName" runat="server" placeholder="演講名稱" style="width:800px" /></td>
    </tr>
    <tr>
      <th scope="row">類別:</th>
      <td>
           <input class="form-check-input" type="radio" name="domesticForeign" id="rdbKey" runat="server">
            <label class="form-check-label" for="flexRadioDefault1">Keynote</label>
           <input class="form-check-input" type="radio" name="domesticForeign" id="rdbInv" runat="server">
            <label class="form-check-label" for="flexRadioDefault1">Invited</label>
      </td>
    </tr>
    <tr>
      <th scope="row">邀請單位/會議:</th>
      <td><input id="txbInvitationUnit" runat="server" placeholder="邀請單位/會議" style="width:800px" /></td>
    </tr>
    <tr>
      <th scope="row">演講期間起日:</th>
      <td><input id="txbSpeechStartDay" runat="server" placeholder="EX:YYYY/MM/DD" /></td>
    </tr>
     <tr>
      <th scope="row">演講期間訖日:</th>
      <td><input id="txbSpeechEndDay" runat="server" placeholder="EX:YYYY/MM/DD" /></td>
    </tr>
</table>
        <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="btnConfirm" runat="server" Text="確認新增" OnClick="btnConfirm_Click"/>
            <asp:Button ID="btnRestar" runat="server" Text="重新填寫" OnClick="btnRestar_Click" />
        </div>
    </div>

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
