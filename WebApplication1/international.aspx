<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="international.aspx.cs" Inherits="WebApplication1.international" %>
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
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才國際合作計畫資料查詢★</h2>
       <button runat ="server" id="btnNew" onserverclick="btnNew_Click"  class="btn btn-info badge rounded-circle">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat="server" class="table table-info table-hover table-bordered align-middle">
                   
                </table>
            </div>
        </div>
    </div>
 <div <%--style="display:none"--%>>
    <table runat="server" id="Newtable" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才國際合作計畫資料新增<input id="PK" runat="server" /></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="txbName" runat="server" placeholder="姓名"></td>
    </tr>
    <tr>
      <th scope="row">計畫(西元)年度:</th>
      <td><input id="txbYear" runat="server" placeholder="EX:YYYY"></td>
    </tr>
    <tr>
      <th scope="row">計畫編號:</th>
      <td><input id="txbPNum" runat="server" placeholder="計畫編號" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">計畫名稱:</th>
      <td><input id="txbPName" runat="server" placeholder="計畫名稱" style="width:800px"></td>
    </tr>
     <tr>
      <th scope="row">執行單位:</th>
      <td><input id="txbExeUnit" runat="server" placeholder="執行單位" ></td>
    </tr>
    <tr>
      <th scope="row">計畫類型:</th>
      <td>
         <input class="form-check-input" type="radio" name="flexRadioDefaultP" runat="server" id="rdbPer">
            <label class="form-check-label" for="flexRadioDefaultP">個人</label>
           <input class="form-check-input" type="radio" name="flexRadioDefaultP" runat="server" id="rdbAll">
            <label class="form-check-label" for="flexRadioDefaultP">整合</label>
          <input class="form-check-input" type="radio" name="flexRadioDefaultP" runat="server" id="rdbOth">
            <label class="form-check-label" for="flexRadioDefaultP">其他</label>
      </td>
    </tr>
    <tr>
      <th scope="row">經費提供單位:</th>
      <td><input id="txbFeeUnit" runat="server" placeholder="經費提供單位" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">合作國家:</th>
      <td><input id="txbCooCountry" runat="server" placeholder="合作國家" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">合作機構:</th>
      <td><input id="txbCooOrgan" runat="server" placeholder="合作機構" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間起日:</th>
      <td><input id="txbStartDay" runat="server" placeholder="EX:YYYY/MM/DD"></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間訖日:</th>
      <td><input id="txbEndDay" runat="server" placeholder="EX:YYYY/MM/DD"></td>
    </tr>
    <tr>
      <th scope="row">計畫經費:</th>
      <td><input id="txbPFee" runat="server" placeholder="計畫經費" ></td>
    </tr>
    <tr>
      <th scope="row">管理費:</th>
      <td><input id="txbMFee" runat="server" placeholder="管理費" ></td>
    </tr>
    <tr>
      <th scope="row">是否為主持人:</th>
      <td>
          <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server" id="rdbY">
            <label class="form-check-label" for="flexRadioDefault1">是</label>
           <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server" id="rdbN">
            <label class="form-check-label" for="flexRadioDefault1">否</label>
      </td>
    </tr>
    <tr>
      <th scope="row">備註:</th>
      <td><input id="txbRemark" runat="server" placeholder="備註" style="width:800px"></td>
    </tr>
      </table>
        <div style="text-align:center;color:darkblue;font-weight:900;font-size:small">
            <asp:Button ID="btnComfirm" runat="server" Text="確認新增" OnClick="btnComfirm_Click" /><asp:Button ID="btnRestar" runat="server" Text="重新填寫" OnClick="btnRestar_Click" />
        </div>       
    </div>   

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
