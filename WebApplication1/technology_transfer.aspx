<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="technology_transfer.aspx.cs" Inherits="WebApplication1.techology_transfer" %>
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
  } );
  </script>
  <style>
  label {
    display: inline-block;
    width: 5em;
  }
  </style>
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
    a{
        font-size:small;
    }
    table{
        font-size:small;
    }

</style>

    <div style="text-align:center">
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才技術移轉資料★</h2>
        <button id="btnNew" runat="server" class="btn btn-info badge rounded-circle" onserverclick="btnNew_Click">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat ="server" class="table table-info table-hover table-bordered align-middle">
                    
                </table>
                <asp:Label ID="Label1" runat="server" Text="*技術移轉相關資料煩請洽承辦人陳舜芳小姐聯絡，分機4782 ; 謝謝 !" Font-Bold="True" Font-Size="Small" ForeColor="#3333CC"></asp:Label>
            </div>
        </div>
    </div>
<div <%--style="display:none"--%>>
    <table runat ="server" id="Newtable" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才技術移轉資料新增<input id ="PK" runat="server" /></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id ="txbName" runat="server" placeholder="姓名"></td>
    </tr>
     <tr>
      <th scope="row">(西元)年度:</th>
      <td><input id="txbYear" runat="server" placeholder="EX:YYYY" ></td>
    </tr>
    <tr>
      <th scope="row">技術名稱:</th>
      <td><input id="txbTchName" runat ="server" placeholder="技術名稱" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">專利名稱:</th>
      <td><input id="txbPatName" runat="server" placeholder="專利名稱" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">授權單位:</th>
      <td><input id="txbAthUnit" runat="server" placeholder="授權單位" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">技術授權人:</th>
      <td><input id="txbAthPeo" runat="server" placeholder="技術授權人" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">被授權單位:</th>
      <td><input id="txbAthedUnit" runat="server" placeholder="被授權單位" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">合約期間起日:</th>
      <td><input id="txbStatDay" runat="server" placeholder="EX:YYYY/MM/DD"></td>
    </tr>
    <tr>
      <th scope="row">合約期間訖日:</th>
      <td><input id="txbEndDay" runat="server" placeholder="EX:YYYY/MM/DD" ></td>
    </tr>
       <tr>
      <th scope="row">授權年限:</th>
      <td><input id="txbAuthPer" runat="server"></td>
    </tr>
    <tr>
      <th scope="row">停止合約條件:</th>
      <td><input id="txbStop" runat="server" placeholder="停止合約條件" ></td>
    </tr>
    <tr>
      <th scope="row">授權金:</th>
      <td><input id="txbEquity" runat="server" placeholder="授權金" ></td>
    </tr>
    <tr>
      <th scope="row">權益金:</th>
      <td><input id="txbAthFee" runat="server" placeholder ="權益金" ></td>
    </tr>
       <tr>
      <th scope="row">CxJxA:</th>
      <td><input id="txbCJA" runat="server" ></td>
    </tr>
    <tr>
      <th scope="row">計畫編號:</th>
      <td><input id="txbPlanId" runat="server" placeholder="計畫編號" ></td>
    </tr>    <tr>
      <th scope="row" style="color:red">是否納入RPI計算:</th>
      <td>
          <input id="rdbY" runat="server" class="form-check-input" type="radio" name="flexRadioDefault">
            <label class="form-check-label" for="flexRadioDefault1">是</label>
           <input id="rdbN" runat="server" class="form-check-input" type="radio" name="flexRadioDefault">
            <label class="form-check-label" for="flexRadioDefault1">否</label>
      </td>
    </tr>
      </table>
        <div style="text-align:center;color:darkblue;font-weight:900;font-size:small">
            <asp:Button ID="btnConfirm" runat="server" Text="確認新增" OnClick="btnConfirm_Click" /><asp:Button ID="btnRestar" runat="server" Text="重新填寫" OnClick="btnRestar_Click" />
        </div>       
    </div>   

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
