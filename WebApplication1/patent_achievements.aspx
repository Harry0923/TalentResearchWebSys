<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="patent_achievements.aspx.cs" Inherits="WebApplication1.patent_achievements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
  $( function() {
      $(document).tooltip();
      $("#speed").selectmenu();
      $("#datepicker").datepicker();
      $("#datepicker2").datepicker();
      $("#datepicker3").datepicker();
  } );
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
    table{
        font-size:small;
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
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才專利資料★</h2>
        <button id="btnNew" runat ="server" class="btn btn-info badge rounded-circle" onserverclick="btnNew_Click">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="tableData" runat="server" class="table table-info table-hover table-bordered align-middle"></table>
                 <asp:Label ID="Label1" runat="server" Text="*專利相關資料煩請洽承辦人陳舜芳小姐聯絡，分機4782 ; 謝謝 !" Font-Bold="True" Font-Size="Small" ForeColor="#3333CC"></asp:Label>
            </div>
        </div>
    </div>
    
<div <%--style="display:none"--%>>
    <table id="Newtable" runat="server" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才專利資料新增<input id="PK" runat="server"/></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="txbName" runat="server" placeholder="姓名" /></td>
    </tr>
     <tr>
      <th scope="row">專利核准(西元)年度:</th>
      <td><input id="txbPatentApprovalYear" runat="server" placeholder="EX:YYYY" /></td>
    </tr>
    <tr>
      <th scope="row">專利名稱:</th>
      <td><input id="txbPatentName" runat="server" placeholder="專利名稱" style="width:800px" /></td>
    </tr>
    <tr>
      <th scope="row">國別:</th>
      <td><input id="txbCountry" runat="server" placeholder="國別" /></td>
    </tr>
    <tr>
      <th scope="row">專利類別:</th>
      <td>
            <input class="form-check-input" type="radio" name="patentType" id="rdbInvention" runat="server">
            <label class="form-check-label" for="rdbInvention">發明</label>
           <input class="form-check-input" type="radio" name="patentType" id="rdbNew1" runat="server">
            <label class="form-check-label" for="rdbNew1">新型</label>
          <input class="form-check-input" type="radio" name="patentType" id="rdbNew2" runat="server">
            <label class="form-check-label" for="rdbNew2">新樣式</label>
      </td>
    </tr>
     <tr>
      <th scope="row">國內/外:</th>
      <td>
            <input class="form-check-input" type="radio" name="domesticForeign" id="rdbDomestic" runat="server">
            <label class="form-check-label" for="flexRadioDefault1">國內</label>
           <input class="form-check-input" type="radio" name="domesticForeign" id="rdbForeign" runat="server">
            <label class="form-check-label" for="flexRadioDefault1">國外</label>
      </td>
    </tr>
    <tr>
      <th scope="row">專利號碼:</th>
      <td><input id="txbPatentNum" runat="server" placeholder="專利號碼" /></td>
    </tr>
    <tr>
      <th scope="row">發明人:</th>
      <td><input id="txbCreator" runat="server" placeholder="發明人" style="width:800px" /></td>
    </tr>
    <tr>
      <th scope="row">專利權人:</th>
      <td><input id="txbPatentee" runat="server" placeholder="專利權人" style="width:800px" /></td>
    </tr>
    <tr>
      <th scope="row">專利申請日:</th>
      <td><input id="txbPatentFilingDate" runat="server" placeholder="EX:YYYY/MM/DD" /></td>
    </tr>
    <tr>
      <th scope="row">專利申請號:</th>
      <td><input id="txbPatentApplicationNum" runat="server" placeholder="專利申請號" /></td>
    </tr>
    <tr>
      <th scope="row">專利申請費:</th>
      <td><input id="txbPatentApplicationFee" runat="server" placeholder="專利申請費" /></td>
    </tr>
    <tr>
      <th scope="row">專利期間起日:</th>
      <td><input id="txbPatentPeriodStartDate" runat="server" placeholder="EX:YYYY/MM/DD" /></td>
    </tr>
    <tr>
      <th scope="row">專利期間訖日:</th>
      <td><input id="txbPatentPeriodExpiryDate" runat="server" placeholder="EX:YYYY/MM/DD" /></td>
    </tr>
    <tr>
      <th scope="row">計畫編號:</th>
      <td><input id="txbPatentOfficeNum" runat="server" placeholder="計畫編號" /></td>
    </tr>
    <tr>
      <th scope="row">專利商標服務事務所名稱:</th>
      <td><input id="txbPatentOfficeName" runat="server" placeholder="專利商標服務事務所名稱" /></td>
    </tr>
    <tr>
      <th scope="row">維護專利年費情形:</th>
      <td><input id="txbMaintenancePatentAnnualFee" runat="server" placeholder="維護專利年費情形" ></td>
    </tr>
    <tr>
      <th scope="row">技轉情形:</th>
      <td><input id="txbTechnicalSituation" runat="server" placeholder="技轉情形" /></td>
    </tr>
    <tr>
      <th scope="row" style="color:red">是否納入RPI計算:</th>
      <td>
          <input class="form-check-input" type="radio" name="isRPI" id="rpiY" runat="server">
            <label class="form-check-label" for="rpiY">是</label>
           <input class="form-check-input" type="radio" name="isRPI" id="rpiN" runat="server">
            <label class="form-check-label" for="rpiN">否</label>
      </td>
    </tr>
      </table>
        <div style="text-align:center;color:darkblue;font-weight:900;font-size:small">
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
