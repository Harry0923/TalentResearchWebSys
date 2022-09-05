<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="basic_infor.aspx.cs" Inherits="WebApplication1.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script>
      $(function () {
          $(document).tooltip();
          $("#datepicker").datepicker();
          $("#datepicker2").datepicker();
      });
  </script>
    <style>
        table{
        font-size:small;
    }
    </style>
    <table class="table table-bordered table table-hover">
  <thead>
    <tr>
      <th scope="col">基本資料維護</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">身分證字號:</th>
      <td><input runat="server" id="txbID" placeholder="身分證字號"></td>
    </tr>
     <tr>
      <th scope="row">中文姓名:</th>
      <td><input runat="server" id="txbCname" placeholder="中文姓名"></td>
    </tr>
    <tr>
      <th scope="row">英文姓名:</th>
      <td><input runat="server" id="txbEname" placeholder="EX:王小明 Wang,Xiao-Ming"></td>
    </tr>
    <tr>
      <th scope="row">英文縮寫(發表論文用):</th>
      <td><input runat="server" id="txbESname" placeholder="EX:王小明 Wang,XM"></td>
    </tr>
    <tr>
      <th scope="row">國籍:</th>
      <td><input runat="server" id="txbCountry" placeholder="國籍"></td>
    </tr>
    <tr>
      <th scope="row">出生日期:</th>
      <td><input runat="server" id="txbBorn" type="text" placeholder="民國年YYMMDD"></td>
    </tr>
    <tr>
      <th scope="row">聯絡地址:</th>
      <td><input runat="server" id="txbAddr" placeholder="聯絡地址" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">聯絡電話(公):</th>
      <td><input runat="server" id="txbPb" placeholder="聯絡電話(公)"></td>
    </tr>
    <tr>
      <th scope="row">聯絡電話(宅):</th>
      <td><input runat="server" id="txbPr" placeholder="聯絡電話(宅)"></td>
    </tr>
    <tr>
      <th scope="row">傳真號碼:</th>
      <td><input runat="server" id="txbFax" placeholder="傳真號碼"></td>
    </tr>
    <tr>
      <th scope="row">所屬二級單位:</th>
      <td><input id="txbEUnit" runat="server" /><input id="txbCUint" runat="server" /><button>選項</button><button>重設</button></td>
    </tr>
    <tr>
      <th scope="row">職稱:</th>
      <td><input id="txbJobTitle" runat="server" placeholder="職稱"></td>
    </tr>
    <tr>
      <th scope="row">到職日:</th>
        <td><input id="txbArri" runat="server" type="text"  placeholder="EX:YYYY/MM/DD"></td>
    </tr>
    <tr>
      <th scope="row">研究年資:</th>
      <td>
            <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server" id="rdb5">
            <label class="form-check-label" for="flexRadioDefault1">滿5年以上</label>
           <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server"  id="rdb4">
            <label class="form-check-label" for="flexRadioDefault1">滿4年</label>
          <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server"  id="rdb3">
            <label class="form-check-label" for="flexRadioDefault1">滿3年</label>
          <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server"  id="rbd2">
            <label class="form-check-label" for="flexRadioDefault1">未滿3年</label>
          <a href="#" title="「研究年資」之計算：
 1. 研究年資之起算時間： 
    a) 任國內外大學院校專任助理教授起
    b) 具博士學位任國內外專任教學或研究人員起
    c) 任技正或國內外副研究員或相當副研究員資格起
    d) 任講師或具碩士學位任國內外教學或研究人員滿四年起
    e) 任主治醫師滿二年起

2. 若具多項年資，應合併考慮；例如某A任主治醫師4年後，在職進修4年獲博士學位，其於獲博士學位時之研究年資應為滿6年，其餘類推。">填寫說明</a>
      </td>
    </tr>
    <tr>
      <th scope="row">E-mail:</th>
      <td><input id="txbEmail" runat="server" placeholder="E-mail"></td>
    </tr>
     <tr>
      <th scope="row">專兼任:</th>
      <td>
           <input class="form-check-input" type="radio" name="flexRadioDefault1" runat="server"  id="rdbPro">
            <label class="form-check-label" for="flexRadioDefault2">專任</label>
           <input class="form-check-input" type="radio" name="flexRadioDefault1" runat="server"  id="rdbSpe">
            <label class="form-check-label" for="flexRadioDefault2">合(特)聘</label>
          <input class="form-check-input" type="radio" name="flexRadioDefault" runat="server"  id="rdbBoth">
            <label class="form-check-label" for="flexRadioDefault2">兼任</label>
          <input class="form-check-input" type="radio" name="flexRadioDefault1" runat="server"  id="rdbOth">
            <label class="form-check-label" for="flexRadioDefault2">其他</label>
          <input id="txbOth" runat="server" />
      </td>
    </tr>
</table>
    <div style="text-align:center">
        <asp:Button ID="btnFix" runat="server" Text="修改" Font-Bold="True" Font-Size="Small" ForeColor="#3333CC" OnClick="btnFix_Click" /><button><a href="homepage.aspx">放棄修改</a></button>
    </div>
   <%-- <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>
</asp:Content>
