<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="award.aspx.cs" Inherits="WebApplication1.award" %>
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
        margin: 5px;
    }
    .btn-danger{
        border-radius:30px;
        margin:5px;
    }

</style>

    <div style="text-align:center">
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才獲獎資料★</h2>
         <button runat ="server" id="btnNew" onserverclick="btnNew_Click"  class="btn btn-info badge rounded-circle">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat="server" class="table table-info table-hover table-bordered align-middle">
                    <thead class="table-dark">
                        <tr>
                            <th sort="true">編號</th>
                            <th sort="true">年度</th>
                            <th>提供單位</th>
                            <th>獲獎項目</th>
                            <th>獲獎日期</th>
                            <th>----</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>1</td>
                            <td>1</td>
                            <td>1</td>
                            <td>1</td>
                            <td>
                                <button class="btn btn-primary badge rounded-pill me-2">更改</button>
                                <button class="btn btn-danger badge rounded-pill">刪除</button>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>2</td>
                            <td>2</td>
                            <td>2</td>
                            <td>2</td>
                            <td>
                                <button class="btn btn-primary badge rounded-pill me-2">更改</button>
                                <button class="btn btn-danger badge rounded-pill">刪除</button>
                            </td>
                        </tr> 
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div>
        <table id="Newtable" runat="server" class="table table-bordered table table-hover">
  <thead>
    <tr>
      <th scope="col">研究人才獲獎資料新增<input id="PK" runat ="server" /></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input id="txbName" runat="server" placeholder="研究人才姓名"></td>
    </tr>
     <tr>
      <th scope="row">獲獎(西元)年度:</th>
      <td><input id="txbYear" runat="server" placeholder="EX:YYYY"></td>
    </tr>
    <tr>
      <th scope="row">獎項提供單位:</th>
      <td><input id="txbUnit" runat="server" placeholder="獎項提供單位" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">獲獎項目:</th>
      <td><input id="txbAward" runat="server" placeholder="獲獎項目" style="width:600px"></td>
    </tr>
    <tr>
      <th scope="row">日期:</th>
      <td><input id="txbDate" runat="server" placeholder="EX:YYYY/MM/DD"></td>
    </tr>
      </table>
            <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="btnComfirm" runat="server" Text="確認新增" OnClick="btnComfirm_Click" /><asp:Button ID="bntRestar" runat="server" Text="重新填寫" OnClick="bntRestar_Click" />
        </div>
    </div>

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
