<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="serminar_paper.aspx.cs" Inherits="WebApplication1.serminar_paper" %>
<asp:Content ID="ContentSerminar" ContentPlaceHolderID="MainContent" runat="server">
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

        * {
            font-weight: 900;
        }

        .btn-info {
            width: 50px;
            height: 50px;
            margin: 20px;
        }

        table {
            font-size: small;
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
        <h2 style="font-weight:bold; color: #3333CC;">★研究人才研討會資料★</h2>
        <button runat ="server" id="btnNew" onserverclick="btnNew_Click"  class="btn btn-info badge rounded-circle">新增</button>
    </div>
        <br />
 
<div class="container-fluid text-center">
    <div class="row justify-content-center">
        <div class="row table-responsive w-75">
            <table runat="server" id="example" class="table table-info table-hover table-bordered align-middle">
                
            </table>
        </div>
    </div>
</div>
<div>
  <table runat="server" id="Newtable" class="table table-bordered table table-hover" >
     <thead>
          <tr>
                <th scope="col">研究人才研討會資料新增<input id="PK" runat="server" /> </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">研究人才姓名:</th>
                <td><input runat="server" id="txbName" placeholder="姓名"></td>
            </tr>
            <tr>
                <th scope="row">研討會日期:</th>
                <td><input runat="server" id="txbDate" placeholder="EX:YYYY/MM/DD"></td>
            </tr>
            <tr>
                <th scope="row">擔任主持人類型:</th>
                <td>
                    <input runat ="server" id="rdbMain" class="form-check-input" type="radio" name="flexRadioDefault">
                    <label class="form-check-label" for="flexRadioDefault1">總主持人</label>
                    <input runat="server" id="rdbDiv" class="form-check-input" type="radio" name="flexRadioDefault">
                    <label class="form-check-label" for="flexRadioDefault1">分組討論主持人</label>
                    <input runat="server" id="rdbSpeecher" class="form-check-input" type="radio" name="flexRadioDefault">
                    <label class="form-check-label" for="flexRadioDefault1">演講者</label>
                </td>
            </tr>
            <tr>
                <th scope="row">發表論文名稱:</th>
                <td><input runat="server" id="txbPaperName" placeholder="發表論文名稱" style="width:500px"></td>
            </tr>
            <tr>
                <th scope="row">發表論文類型:</th>
                <td>
                    <input runat ="server" id="rdbCre" class="form-check-input" type="radio" name="flexRadioDefaultP">
                    <label class="form-check-label" for="flexRadioDefault1">原創性論文</label>
                    <input runat="server" id="rdbPat" class="form-check-input" type="radio" name="flexRadioDefaultP">
                    <label class="form-check-label" for="flexRadioDefault1">病例報告</label>
                    <input runat="server" id="rdbPpt" class="form-check-input" type="radio" name="flexRadioDefaultP">
                    <label class="form-check-label" for="flexRadioDefault1">簡報性論文</label>
                    <input runat="server" id="rdbPOth" class="form-check-input" type="radio" name="flexRadioDefaultP">
                    <label class="form-check-label" for="flexRadioDefault1">其他(請自行說明)</label>
                    <input id ="txbPOth" runat="server" />
                </td>
            </tr>
            <tr>
                <th scope="row">發表論文方式:</th>
                <td>
                <input runat="server" id="rdbVerbal" class="form-check-input" type="radio" name="flexRadioDefaultPaperType" >
                <label class="form-check-label" for="flexRadioDefaultPaperType">口頭報告</label>
                <input runat="server" id="rdbPost" class="form-check-input" type="radio" name="flexRadioDefaultPaperType" >
                <label class="form-check-label" for="flexRadioDefaultPaperType">海報展示</label>           
                </td>
            </tr>
            <tr>
                <th scope="row">作者排序:</th>
                <td>
                    <input runat="server" id="rdb1" class="form-check-input" type="radio" name="flexRadioDefaultSort">
                    <label class="form-check-label" for="flexRadioDefaultSort">第一</label>
                    <input runat="server" id="rdbCom" class="form-check-input" type="radio" name="flexRadioDefaultSort">
                    <label class="form-check-label" for="flexRadioDefaultSort">通訊</label>
                    <input runat="server" id="rdb2" class="form-check-input" type="radio" name="flexRadioDefaultSort">
                    <label class="form-check-label" for="flexRadioDefaultSort">第二</label>
                    <input runat="server" id="rdb3" class="form-check-input" type="radio" name="flexRadioDefaultSort">
                    <label class="form-check-label" for="flexRadioDefaultSort">第三</label>
                    <input runat="server" id="rdbOth" class="form-check-input" type="radio" name="flexRadioDefaultSort">
                    <label class="form-check-label" for="flexRadioDefaultSort">其他</label>
                    <input runat="server" id="txbOth" >
                </td>
            </tr>
            <tr>
                <th scope="row">論文全體作者:</th>
                <td><input runat="server" id="txbAll" placeholder="論文全體作者"></td>
            </tr>
            <tr>
                <th scope="row">會議名稱:</th>
                <td><input runat="server" id="txbMeetName" placeholder="會議名稱"></td>
            </tr>
            <tr>
                <th scope="row">會議類型:</th>
                <td>            
                    <input runat="server" id="rdbInt" class="form-check-input" type="radio" name="flexRadioDefaultType">
                    <label class="form-check-label" for="flexRadioDefaultType">國際型</label>
                    <input runat="server" id="rdbDom" class="form-check-input" type="radio" name="flexRadioDefaultType">
                    <label class="form-check-label" for="flexRadioDefaultType">國內型</label>
                    <input runat="server" id="rdbArea" class="form-check-input" type="radio" name="flexRadioDefaultType">
                    <label class="form-check-label" for="flexRadioDefaultType">地區型</label>
                </td>
            </tr>
            <tr>
                 <th scope="row">會議地點:</th>
            <td>            
                <input runat="server" id="rdbDomLoc" class="form-check-input" type="radio" name="flexRadioDefaultLoc">
                <label class="form-check-label" for="flexRadioDefaultLoc">國內</label>
                <input runat="server" id="rdbIntLoc" class="form-check-input" type="radio" name="flexRadioDefaultLoc">
                <label class="form-check-label" for="flexRadioDefaultLoc">國外詳細地點</label>
                <input runat="server" id="txbLoc" placeholder="請詳細填寫縣市、機構、會場" style="width:600px">
            </td>
            </tr>
        </tbody>
     </table>
        <div style="text-align:center;color:darkblue;font-weight:900">
            <asp:Button ID="btnConfirm" runat="server" Text="確認新增" OnClick="btnConfirm_Click"/><asp:Button ID="btnRestar" runat="server" Text="重新填寫" OnClick="btnRestar_Click" />
        </div>
</div>

    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
       

</asp:Content>
