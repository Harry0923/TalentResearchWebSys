<%@ Page Title="" Language="C#" EnableViewState ="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="industry_academia.aspx.cs" Inherits="WebApplication1.industry_academia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
  $( function() {
      $(document).tooltip();  
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
    table{
        font-size:small;
    }
    .btn-primary{
        border-radius:30px;
        margin: 5px;
    }
    .btn-danger{
        border-radius:30px;
        margin:5px;
    }
</style>

    <div style="text-align:center">
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才產學合作計畫資料查詢★</h2>
        <button id ="btnNew" class="btn btn-info badge rounded-circle" runat="server" onserverclick="btnNew_Click">新增</button>
    </div>
        <br />
    <div class="container-fluid text-center" runat="server">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table EnableViewState ="true" id="example" runat="server" class="table table-info table-hover table-bordered align-middle">
                </table>
                <asp:Label ID="Label1" runat="server" Text="*產學合作計畫煩請洽承辦人陳舜芳小姐聯絡，分機4782 ; 謝謝 !" Font-Bold="True" Font-Size="Small" ForeColor="#3333CC"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="*若研究人才自行登錄之資料與研究部門之資料重複，本部有權將重複之資料刪除" Font-Bold="True" Font-Size="Small" ForeColor="#3333CC"></asp:Label>
            </div>
        </div>
    </div>
<div>
    <table id="Newtable" runat="server" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才產學合作計畫資料新增<input id="PK" runat="server"/></th> 
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">計畫編號:</th>
      <td><input id="txbPlanID" placeholder="計畫編號" style="width:800px"  runat="server"/></td>
    </tr>
    <tr>
      <th scope="row">計畫名稱:</th>
      <td><input placeholder="計畫名稱" style="width:800px" id="txbPlanName" runat="server"/></td>
    </tr>
     <tr>
      <th scope="row">計畫(西元)年度:</th>
      <td><input  placeholder="EX:YYYY" id="txbPlanY" runat="server"/></td>
    </tr>
    <tr>
      <th scope="row">合作廠商:</th>
      <td><input ID="txbPartner" runat="server" placeholder="合作廠商" style="width:800px"/></td>
    </tr>
    <tr>
      <th scope="row">執行機關:</th>
      <td><input ID="txbExeOrgan" runat="server" placeholder="專利名稱" style="width:600px"/></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間起日:</th>
      <td><input ID="txbPlanExeDate" placeholder="EX:YYYY/MM/DD" runat="server"/></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間訖日:</th>
      <td><input id="txbPlanEndDate" runat="server" placeholder="EX:YYYY/MM/DD"/></td>
    </tr>
    <tr>
      <th scope="row">計畫經費:</th>
      <td><input id="txbPlanExp" runat="server" placeholder="計畫經費"/></td>
    </tr>
    <tr>
      <th scope="row">人事費:</th>
      <td><input id="txbPerExp" runat="server" placeholder="人事費" ></td>
    </tr>
      <tr>
          <th>是否可更動</th>
          <th><a>Y</a><input type="radio" id="rdbY" runat="server"><a>N</a><input type="radio" id="rdbN" runat="server"></th>
      </tr>
      </table>
        <div style="text-align:center;color:darkblue;font-weight:900;font-size:small">
            <asp:Button ID="BtnConfirm" runat="server" Text="確認新增" onserverclick="btnConfirm-Click" OnClick="BtnConfirm_Click"/>
            <asp:Button ID="btnrestar" runat="server" Text="重新填寫" onserverclick="btnNew_Click" OnClick="btnrestar_Click" />
        </div>       
    </div>      

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
