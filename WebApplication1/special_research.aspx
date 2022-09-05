<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="special_research.aspx.cs" Inherits="WebApplication1.special_research" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    
    *{
        font-weight:900;
    }

    .btn-info{
        width:50px;
        height:50px;
        margin:20px;
    }

    .auto-style2 {
        width: 308px;
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
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才其他特殊研究成果資料查詢★</h2>
        <button runat="server" id="btnNew" onserverclick="btnNew_Click" class="btn btn-info badge rounded-circle">新增</button>
    </div>
        <br />
 
    <div class="container-fluid text-center">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat ="server" class="table table-info table-hover table-bordered align-middle">
                   
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
      <th scope="row" class="auto-style2">研究人才姓名:</th>
      <td><input id="txbName" runat ="server" placeholder="研究人才姓名"></td>
    </tr>
     <tr>
      <th scope="row" class="auto-style2">其他研究成果:
          <br />
          字數在500個字以內
         </th>
      <td>
          <asp:TextBox ID="txbWord" runat="server" TextMode="MultiLine" Width="600"></asp:TextBox>
      </td>
    </tr>
      </table>
           <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="btnConfirm"  runat="server" Text="確認新增" OnClick="btnConfirm_Click" /><asp:Button ID="btnrestar" runat="server" Text="重新填寫" />
        </div>
    </div>

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
