<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="research_project.aspx.cs" Inherits="WebApplication1.research_project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#accordion").accordion();
          $("#datepicker").datepicker();
          $("#datepicker2").datepicker();
      });
  </script>
 <style>
    
    *{
        font-weight:900;
    }

    .btn-info{
        width:50px;
        height:50px;
        margin:20px;
    }
    p{
        color:darkblue;
        font-weight:900;
    }
    table{
        font-size:small;
    }
     .auto-style2 {
         height: 36px;
     }
 </style>

    <div style="text-align:center">
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才個人研究計畫資料查詢★</h2>
        <button runat ="server" id="btnNew" onserverclick="btnNew_Click"  class="btn btn-info badge rounded-circle">新增</button>
    </div>
        <br />
  <div id="accordion" style="text-align:center">
  <h4 style="color:darkblue;font-weight:900">注意事項</h4>
  <div>
    <p>
    *請填寫相關執行計畫資料，若有任何問題，請洽相關承辦人 :
     國科會、榮台聯大、衛生署等院外研究計畫煩請與鄭惠月小姐聯絡，分機4001 ;
     </p>
      <p>
          院內研究計畫煩請與張雅玲小姐聯絡，分機4004 ;
     </p>
      <p>
          院校合作研究計畫煩請與張伶小姐聯絡，分機4009 ; 謝謝 !
     </p>
      <p>
          *若研究人才自行登錄之資料與研究部之資料重覆，本部有權將重複之資料刪除
    </p>
     </div>
        </div>
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat="server" class="table table-info table-hover table-bordered align-middle">

                </table>
            </div>
        </div>
    </div>
 <div <%--style="display:none"--%>>
    <table id="Newtable" runat="server" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才個人研究計畫資料新增<input runat="server" id="PK"/></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="txbName" runat="server" placeholder="姓名"></td>
    </tr>
    <tr>
      <th scope="row">計畫(西元)年度:</th>
      <td><input runat="server" id="txbYeay" placeholder="EX:YYYY"></td>
    </tr>
    <tr>
      <th scope="row">計畫編號:</th>
      <td><input id="txbPlanID" runat="server" placeholder="計畫編號" style="width:600px"></td>
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
      <td><input id ="txbFeeUnit" runat="server" placeholder="經費提供單位" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間起日:</th>
      <td><input runat="server" placeholder="EX:YYYY/MM/DD" id="txbStarDay"></td>
    </tr>
    <tr>
      <th scope="row">計畫執行期間訖日:</th>
      <td><input runat="server" placeholder="EX:YYYY/MM/DD" id="txbEndDay"></td>
    </tr>
    <tr>
      <th scope="row">核定計畫經費:</th>
      <td><input runat="server" id="txbPFee" placeholder="核定計畫經費" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">核定管理費:</th>
      <td><input id="txbMFee" runat="server" placeholder="核定管理費" style="width:600px"></td>
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
      <th scope="row">佐證資料上傳:</th>
      <td>
          <input runat="server" id="txbFile" type="file" />

      </td>
    </tr>
    <tr>
      <th scope="row">備註:</th>
      <td><input runat="server" id="txbRemark" placeholder="備註" style="width:800px"></td>
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
