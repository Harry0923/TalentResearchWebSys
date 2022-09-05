<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="WebApplication1.book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        <h2 style="font-weight:bold; color: #3333CC;">★專書資料★</h2>
        <button id="btnNew" runat ="server" class="btn btn-info badge rounded-circle" onserverclick="btnNew_Click">新增</button>
    </div>
        <br />

    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="tableData" runat="server" class="table table-info table-hover table-bordered align-middle">
                </table>
            </div>
        </div>
    </div>
    <div >
    <table id="Newtable" runat="server" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">新增專書資料<input id="PK" runat="server"/></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="Name" runat="server" placeholder="姓名"></td>
    </tr>
     <tr>
      <th scope="row">出版(西元)年度:</th>
      <td><input id="YearOfPublication" runat="server" placeholder="EX:YYYY"></td>
    </tr>
    <tr>
      <th scope="row">作者:</th>
      <td><input id="AuthorName" runat="server" placeholder="作者" /></td>
    </tr>
    <tr>
      <th scope="row">專書名稱:</th>
      <td><input id="BookTitle" runat="server" placeholder="專書名稱" /></td>
    </tr>
    <tr>
      <th scope="row">ISBN(國際標準書號):</th>
      <td><input id="ISBNNum" runat="server" placeholder="ISBN(國際標準書號) /"></td>
    </tr>
    <tr>
      <th scope="row">出版社/學術專書:</th>
      <td><input id="PublishingHouse" runat="server" placeholder="出版社/學術專書" /></td>
    </tr>
    <tr>
      <th scope="row">是否經過審查</th>
      <td>            
          <input class="form-check-input" type="radio" name="flexRadioDefault" id="rdbReviewY" runat="server">
            <label class="form-check-label" for="rdbReviewY">是</label>
           <input class="form-check-input" type="radio" name="flexRadioDefault" id="rdbReviewN" runat="server">
            <label class="form-check-label" for="rdbReviewN">否</label>
      </td>
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
