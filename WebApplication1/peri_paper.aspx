<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="peri_paper.aspx.cs" Inherits="WebApplication1.peri_paper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
<%--<script src="https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js"></script>--%>
  <script>
      $(function () {
          $("#datepicker").datepicker();
          $("#datepicker2").datepicker();
      });

      function Btn() {
          var list = document.getElementById('list');
          var text = document.getElementById('divdisplay');
          if (text.style.display === 'none') {
              text.style.display = 'block';
              list.style.display = 'none';
          } else {
              text.style.display = 'none';
              list.style.display = 'block';
          }
      }
      
  </script>
    <style>
    
    *{
        font-weight:900;
    }

    .btn-info{
        width:70px;
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
        <h2 style="font-weight:bold; color: #3333CC;">★學術期刊論文資料★</h2>
        <button id ="btnNew" class="btn btn-info badge rounded-circle" runat="server" onserverclick="btnNew_Click">新增論文
        </button>
    </div>
        <br />
    <div class="container-fluid text-center" id="list">
        <div class="row justify-content-center">
            <div class="row table-responsive w-75">
                <table id="example" runat="server" class="table table-info table-hover table-bordered align-middle">
                </table>
            </div>
        </div>
    </div>

<div class="col-xs-8" runat="Server">
    <table runat="server" id="Newtable" class="table table-bordered table table-hover" >
  <thead>
    <tr>
      <th scope="col">研究人才學術期刊資料新增<input id="PK" runat="server" /></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">研究人才姓名:</th>
      <td><input runat="server" id="txbRName" placeholder="姓名"></td>
    </tr>
    <tr>
      <th scope="row">(西元)年度:</th>
      <td><input runat="server" id="txbYear" placeholder="EX:YYYY"></td>
    </tr>
    <tr>
      <th scope="row">作者:</th>
      <td><input runat="server" id="txbAuthor" placeholder="作者" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">期刊分類:</th>
      <td>
          <input type="radio" runat="server" id="rdbSCI" name="SCI" /><a>SCI期刊論文</a>
          <input type="radio" runat="server" id="rdbNSCI" name="SCI"/><a>非SCI期刊論文</a>
          <input type="radio" runat="server" id="rdbSSCI" name="SCI" /><a>SSCI期刊論文</a><p></p>
          <input type="radio" runat="server" id="rdbEI" name="SCI" /><a>EI期刊論文</a>
          <input type="radio" runat="server" id="rdbTSSCI" name="SCI" /><a>TSSCI期刊論文</a>
          <input type="radio" runat="server" id="rdbAHCI" name="SCI"/><a>A&HCI期刊論文</a>
          <input type="radio" runat="server" id="rdbDI" name="SCI"/><a>加重計分支國內優良刊(DI)</a>
      </td>
    </tr>
    <tr>
      <th scope="row">(For院內申請)發表期刊名稱:</th>
      <td>
          <asp:Button ID="btnSCI" runat="server" Text="2020[SCI-2020]" OnClick="btnSCI_Click"  />
          <asp:TextBox ID="txbHSCI" runat="server"></asp:TextBox>
          <asp:Button ID="btnSRestar" runat="server" Text="重選" />
      </td>
    </tr>
    <tr>
      <th scope="row">(For國科會申請，以2020年版本為準)發表期刊名稱:</th>
      <td>
          <asp:Button ID="btnCSCI" runat="server" Text="國科會[SCI]" />
          <asp:TextBox ID="txbCSCI" runat="server" Width="800"></asp:TextBox>
          <asp:Button ID="btnCRestar" runat="server" Text="重選" />
      </td>
    </tr>
    <tr>
      <th scope="row">卷數:</th>
      <td><input runat="server" id="txbRoll" placeholder="卷數"></td>
    </tr>
     <tr>
      <th scope="row">冊數:</th>
      <td><input runat="server" id="txbBook" placeholder="冊數" ></td>
    </tr>
    <tr>
      <th scope="row">發表標題:</th>
      <td>
          <asp:TextBox ID="txbPostTitle" runat="server" TextMode="MultiLine" Width="1139px" Height="200px"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <th scope="row">頁數:</th>
      <td><input runat="server" id="txbPageNum" placeholder="頁數" ></td>
    </tr>
    <tr>
      <th scope="row">作者順序:</th>
      <td>
          <input type="radio" runat="server" id="rdb1" name="Author" /><a>第一作者</a>
          <input type="radio" runat="server" id="rdbB1" name="Author"/><a>並列第一作者</a>
          <input type="radio" runat="server" id="rdbC" name="Author" /><a>通訊作者</a>
          <input type="radio" runat="server" id="rdbBC" name="Author" /><a>並列通訊作者</a>
          <a>作者排名加權分數(A)</a><input id="txbAuthorPoint" runat="server" /><p></p>
          <input type="radio" runat="server" id="rdb2" name="Author" /><a>第二作者</a><p></p>
          <input type="radio" runat="server" id="rdb3" name="Author"/><a>第三作者</a><p></p>
          <input type="radio" runat="server" id="rdb4" name="Author"/><a>第四作者</a>
          <input type="radio" runat="server" id="rdbB4" name="Author"/><a>第四作者以後</a>
      </td>
    </tr>
    <tr>
      <th scope="row">論文性質分類:</th>
      <td>
           <input type="radio" runat="server" id="rdbOri" name="Paper" /><a>原始論著</a>
          <a>論文性質加權分數(C)</a><input id="txbPaperPoint" runat="server" /><p></p>
          <input type="radio" runat="server" id="rdbPpt" name="Paper"/><a>簡報型論文</a>
          <input type="radio" runat="server" id="rdbComplex" name="Paper" /><a>綜合評估</a>
          <input type="radio" runat="server" id="rdbCaseReport" name="Paper" /><a>病例報告</a><p></p>
          <input type="radio" runat="server" id="rdbOriLetter" name="Paper" /><a>致編者信(屬原著信函者)</a>
          <input type="radio" runat="server" id="rdbOpinion" name="Paper" /><a>致編者信(對他人著作提出意見者)</a>
          <input type="radio" runat="server" id="rdbReply" name="Paper" /><a>致編者信(回答他人信函者)</a>
      </td>
    </tr>
    <tr>
      <th scope="row">第一作者與通訊作者:</th>
      <td>
          <asp:Label ID="Label3" runat="server" Text="第一作者"></asp:Label>
          <input runat="server" id="txbFAName" placeholder="姓名" style="width:200px">
          <input runat="server" id="txbFAUnit" placeholder="單位" style="width:200px"><p></p>&emsp;&emsp;&emsp;&ensp;&ensp;
          <input runat="server" id="txbFAJobTitle" placeholder="職稱" style="width:200px">
          <input runat="server" id="txbFACard" placeholder="卡號" style="width:200px">
          <br /><br />
          <asp:Label ID="Label4" runat="server" Text="通訊作者"></asp:Label>
          <input runat="server" id="txbCAName" placeholder="姓名" style="width:200px">
          <input runat="server" id="txbCAUnit" placeholder="單位" style="width:200px"><p></p> &emsp;&emsp;&emsp;&ensp;&ensp;
          <input runat="server" id="txbCAJobTitle" placeholder="職稱" style="width:200px">
          <input runat="server" id="txbCACard" placeholder="卡號" style="width:200px">
      </td>
    </tr>
    <tr>
      <th scope="row">IRB認證許可書編號:</th>
      <td><input runat="server" id="txbIRBnum" placeholder="IRB認證許可書編號" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">動物實驗管理小組審查同意書編號:</th>
      <td><input runat="server" id="txbAninum" placeholder="動物實驗管理小組審查同意書編號" style="width:800px"></td>
    </tr>
    <tr>
      <th scope="row">引用研究計畫編號:</th>
      <td>
          <a>院內計畫:</a><input runat="server" id="txbHosIn" placeholder="院內計畫" style="width:800px"><p></p>
          <a>院外計畫:</a><input runat="server" id="txbHosOut" placeholder="院外計畫" style="width:800px"><p></p>
          <a>院校計畫:</a><input runat="server" id="txbHosSch" placeholder="院校計畫" style="width:800px"><p></p>
          <a>產官學計畫:</a><input runat="server" id="txbInd" placeholder="產官學計畫" style="width:800px">
      </td>
    </tr>
    <tr>
      <th scope="row">引用教研部生統小組提供之統計諮詢與統計分析:</th>
      <td>
          <input runat="server" id="ckbConsult" class="form-check-input" type="checkbox" value="" name="flexCheckDefault">
          <label  class="form-check-label" for="flexCheckDefault">統計諮詢</label>
          <input runat="server" id="ckbAnalyze" class="form-check-input" type="checkbox" value="" name="flexCheckDefault2">
          <label class="form-check-label" for="flexCheckDefault">統計分析</label>
          <input runat="server" id="ckbThank" class="form-check-input" type="checkbox" value="" name="flexCheckDefault3">
          <label class="form-check-label" for="flexCheckDefault">列入致謝詞</label>
          <input runat="server" id="ckbHealthDb"  class="form-check-input" type="checkbox" value="" name="flexCheckDefault4">
          <label class="form-check-label" for="flexCheckDefault">健保資料庫</label>
          <input runat="server" id="ckbCancerDb"  class="form-check-input" type="checkbox" value="" name="flexCheckDefault5">
          <label class="form-check-label" for="flexCheckDefault">癌症登記資料庫</label>
      </td>
    </tr>
    <tr>
      <th scope="row">發表單位:</th>
      <td>
          <input class="form-check-input" type="radio" name="PostType" runat="server" id="rdbVGHTC">
            <label class="form-check-label" for="flexRadioDefault1">台中榮總</label>
           <input class="form-check-input" type="radio" name="PostType" runat="server" id="rdbOthUnit">
            <label class="form-check-label" for="flexRadioDefault1">其他單位</label>
      </td>
    </tr>   
    <tr>
      <th scope="row" style="color:red">(非必要)上傳佐證資料-論文摘要Pdf或Word檔:</th>
      <td>
          <input id="File1" type="file" />
      </td>
    </tr>
    <tr>
      <th scope="row" style="color:blue">(非必要)上傳佐證資料-論文全文Pdf:</th>
      <td>
          <input id="File2" type="file" />
      </td>
    </tr>
    <tr>
      <th scope="row">出版社是否允許公開全文:</th>
      <td>
          <input class="form-check-input" type="radio" name="OpenYorN" runat="server" id="rdbOpenY">
            <label class="form-check-label" for="flexRadioDefault1">是</label>
           <input class="form-check-input" type="radio" name="OpenYorN" runat="server" id="rdbOpenN">
            <label class="form-check-label" for="flexRadioDefault1">否</label>
          <asp:Label ID="Label5" runat="server" Text="*公開定義:在PubMed中提供全文檢索者,PubMed無公開者,表出版社不同意公開" ForeColor="Red"></asp:Label>
      </td>
    </tr>
    <tr>
      <th scope="row" style="color:red">是否納入RPI計算(請注意至多7篇):</th>
      <td>
          <input class="form-check-input" type="radio" name="RPIYorN" runat="server" id="rdbRPIY">
            <label class="form-check-label" for="flexRadioDefault1">是</label>
           <input class="form-check-input" type="radio" name="RPIYorN" runat="server" id="rdbRPIN">
            <label class="form-check-label" for="flexRadioDefault1">否</label>
      </td>
    </tr>
  </table>
        <div style="text-align:center;color:darkblue;font-weight:900;font-size:small">
            <asp:Button ID="btnConfirm" runat="server" Text="確認新增" OnClick="btnConfirm_Click" /><asp:Button ID="btnRestar" runat="server" Text="重新填寫" OnClick="btnRestar_Click" />
        </div>   
</div>
<div class="col-xs-4">
    <table runat="server" id="SCITable" class="table table-info table-hover table-bordered align-middle">
        
    </table>
</div>
    

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />
    <script>
        function btn() {
            var list = document.getElementById('list');
            var text = document.getElementById('divdisplay');
            if (text.style.display === 'none') {
                text.style.display = 'block';
                list.style.display = 'none';
            } else {
                text.style.display = 'none';
                list.style.display = 'block';
            }
        }
    </script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <script src="Scripts/dataTable.js"></script>
</asp:Content>
