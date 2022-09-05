<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="serve.aspx.cs" Inherits="WebApplication1.serve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/hot-sneaks/jquery-ui.css" rel="stylesheet">
      <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#datepicker").datepicker();
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
        width:120px;
        height:50px;
        margin:20px;
    }
    .center{
        display:inline-block;
        text-align:center;
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
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才院內外服務資料★</h2>
        <button runat ="server" id="btnNew" onserverclick="btnNew_Click" class="btn btn-info badge rounded-circle">新增</button>
        <h4 style="color:darkblue;font-weight:900">注意頁尾填寫說明</h4>
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
        <div>
        <table id="Newtable" runat="server" class="table table-bordered table table-hover">
  <thead>
      <tr>
      <th scope="col" class="auto-style2">研究人才特殊研究成果資料新增<input id="PK" runat="server" /></th>
      </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row" class="auto-style2">年度</th>
      <td><input id="txbYear" runat ="server" placeholder="2022"></td>
    </tr>
     <tr>
      <th scope="row" class="auto-style2">院內外:</th>
      <td><a>院內</a><input id="rdbI" type="radio" runat ="server"><a>院外</a><input id="rdbO" type="radio" runat ="server"></td>
    </tr>
      <tr>
      <th scope="row" class="auto-style2">服務類型:</th>
      <td><input id="txbType" runat ="server"></td>
    </tr>
       <tr>
      <th scope="row" class="auto-style2">職稱:</th>
      <td><input id="txbJobTitle" runat ="server"></td>
    </tr>
      <tr>
      <th scope="row" class="auto-style2">服務單位、團體或活動名稱:</th>
      <td><input id="txbName" runat ="server"></td>
    </tr>
      <tr>
      <th scope="row" class="auto-style2">日期:</th>
      <td><input id="txbDate" runat ="server" placeholder="2022-00-00"></td>
    </tr>
      </table>
           <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="btnConfirm"  runat="server" Text="確認新增" OnClick="btnConfirm_Click"/>
               <asp:Button ID="btnrestar" runat="server" Text="重新填寫" OnClick="btnrestar_Click" />
        </div>
    </div>
<div style="display:none">
<table class="table table-bordered table table-hover">
  <thead>
    <tr>
      <th scope="col">研究人才院內外服務資料新增</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input / placeholder="研究人才姓名"></td>
    </tr>
     <tr>
      <th scope="row">院內外:</th>
      <td>
            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
            <label class="form-check-label" for="flexRadioDefault1">院內</label>
           <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2">
            <label class="form-check-label" for="flexRadioDefault1">院外</label> 
      </td>
    </tr>
    <tr>
      <th scope="row">(西元)年度</th>
      <td>
          <input / placeholder="起">
          <input / placeholder="訖">
          <input / placeholder="每任時間">年
      </td>
    </tr>
    <tr>
      <th scope="row">服務類型:</th>
      <td>
      <select name="paper" id="papers">
      <option value="">行政主管</option>
      <option value="saab">導師</option>
      <option value="saab">出席院內重大活動</option>
      <option value="saab">委員會</option>
       <option value="saab">執行主管指派之專案</option>
        <option value="saab">其他</option>
      </select>
      </td>
    </tr>
    <tr>
      <th scope="row">服務單位、團體或活動名稱:</th>
      <td><input / placeholder="服務單位、團體或活動名稱"></td>
    </tr>
    <tr>
      <th scope="row">研討會日期:</th>
      <td><input / placeholder="此為重大活動必要欄位" id="datepicker"></td>
    </tr>
      </table>
            <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="Button1" runat="server" Text="確認新增" /><asp:Button ID="Button2" runat="server" Text="重新填寫" />
        </div>
    </div>

            <div class="center">
       <div id="accordion" class="ui-widget-content ui-corner-all align-middle" style="width:400px; text-align: center;">
  <h3>院內服務包含:</h3>
  <div>
    <p>
1.行政主管
2.執行院方指派之專案
3.院內重大活動 4.其他
    </p>
  </div>
  <h3>院外服務包含:</h3>
  <div>
    <p>
        1.政府部門相關服務包含:審查委員(Committee member)、主任委員(Committee Chairman)、委員、顧問(Consultant)、其他</p>
      <p>
        &nbsp;2.民間機構相關服務包含:國際學會幹事(Officers of International Society)、國內學會幹事(Officers of Domestic Society)、顧問(Consultant)、理監事或董事(Member of Board of Directors)、召集人(Convener)、其他
    </p>
      <p>
          3.國際學術期刊包含:主編(Editor-in-Chief or Editor)、副主編(Associate Editor or Deputy Editor)、編輯委員(Editorual Board Member)、審查人(Reviewer or Referee)、其他</p>
      <p>
        &nbsp;4.國內學術刊包含:主編(Editor-in-Chief or Editor)、副主編(Associate Editor or Deputy Editor)、編輯委員(Editorual Board Member)、審查人(Reviewer or Referee)、其他</p>
      <p>
        &nbsp;5.其他
    </p>
  </div>
  </div>
    </div>
    </div>

      <script>
          $(function () {
              $("#accordion").accordion({ active: false, collapsible: true, heightStyle: "content"});
          });
  </script>
</asp:Content>
