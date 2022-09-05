using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class peri_paper : System.Web.UI.Page
    {
        string conStr = "Data Source=DESKTOP-API2RQR\\MSSQLSERVER_2019;Initial Catalog=Talent-research;Integrated Security=True";
        string dbID = "";
        int rowCount = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }
        private void PageLoad()
        {
            btnConfirm.Visible = false;
            btnRestar.Visible = false;
            Newtable.Visible = false;
            SCITable.Visible = false;
            rowCount = 1;
            example.Rows.Clear();
            TableFirstRow();
            Newtable.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Paper_data WHERE UID = @UID";
            SqlCommand cmdSle = new SqlCommand(sqlSle, con);
            cmdSle.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdSle.ExecuteReader();
            while (reader.Read())
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellNum = new HtmlTableCell();
                cellNum.InnerText = rowCount.ToString();
                row.Cells.Add(cellNum);
                Session[rowCount.ToString()] = reader[0].ToString();
                for (int i = 1; i < reader.FieldCount - 4; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.InnerText = reader[i].ToString();
                    row.Cells.Add(cell);
            }
                HtmlTableCell cellButton = new HtmlTableCell();
                Button btnUpdate = new Button();
                btnUpdate.Text = "修改";
                btnUpdate.CssClass = "btn-primary";
                btnUpdate.ID = "btnUpdate" + rowCount;
                btnUpdate.Click += new System.EventHandler(this.dataUpdate);
                Button btnDelete = new Button();
                btnDelete.Text = "刪除";
                btnDelete.CssClass = "btn-danger";
                btnDelete.ID = "btnDelete" + rowCount;
                btnDelete.Click += new System.EventHandler(this.dataDelete);
                cellButton.Controls.Add(btnUpdate);
                cellButton.Controls.Add(btnDelete);
                row.Cells.Add(cellButton);
                example.Rows.Add(row);
                rowCount++;
            }
            reader.Close();
            SCITableFirtRow();
        }

        private void dataDelete(object sender, EventArgs e)
        {
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlcheck = "SELECT  Permission  FROM Permission_data WHERE UID = @UID";
            SqlCommand cmdcheck = new SqlCommand(sqlcheck, con);
            cmdcheck.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdcheck.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    string sqlDle = "DELETE FROM Paper_data WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sqlDle, con);
                    cmd.Parameters.AddWithValue("@ID", dbID);
                    cmd.ExecuteNonQuery();
                    PageLoad();
                    System.Windows.Forms.MessageBox.Show("資料已刪除");
                    con.Close();
                }
                else
                    System.Windows.Forms.MessageBox.Show("您的權限不足");
            }
        }

        private void dataUpdate(object sender, EventArgs e)
        {
            string CateType = "";
            string AuthorOrder = "";
            string PaperType = "";
            string Bio = "";
            string PostUnit = "";
            string OpenYorN = "";
            string RPIYorN = "";
            btnConfirm.Text = "確認修改";
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            Newtable.Visible = true;
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Paper_data WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if (reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbRName.Value = reader[1].ToString().Trim();
                txbYear.Value = reader[2].ToString().Trim();
                txbAuthor.Value = reader[3].ToString().Trim();
                CateType = reader[4].ToString().Trim();
                txbHSCI.Text = reader[5].ToString().Trim();
                txbCSCI.Text = reader[6].ToString().Trim();
                txbRoll.Value = reader[7].ToString().Trim();
                txbBook.Value = reader[8].ToString().Trim();
                txbPostTitle.Text = reader[9].ToString().Trim();
                txbPageNum.Value = reader[10].ToString().Trim();
                AuthorOrder = reader[11].ToString().Trim();
                txbAuthorPoint.Value = reader[12].ToString().Trim();
                PaperType = reader[13].ToString().Trim();
                txbPaperPoint.Value = reader[14].ToString().Trim();
                txbFAName.Value = reader[15].ToString().Trim();
                txbFAUnit.Value = reader[16].ToString().Trim();
                txbFAJobTitle.Value = reader[17].ToString().Trim();
                txbFACard.Value = reader[18].ToString().Trim();
                txbCAName.Value = reader[19].ToString().Trim();
                txbCAUnit.Value = reader[20].ToString().Trim();
                txbCAJobTitle.Value = reader[21].ToString().Trim();
                txbCACard.Value = reader[22].ToString().Trim();
                txbIRBnum.Value = reader[23].ToString().Trim();
                txbAninum.Value = reader[24].ToString().Trim();
                txbHosIn.Value = reader[25].ToString().Trim();
                txbHosOut.Value = reader[26].ToString().Trim();
                txbHosSch.Value = reader[27].ToString().Trim();
                txbInd.Value = reader[28].ToString().Trim();
                Bio = reader[29].ToString().Trim();
                PostUnit = reader[30].ToString().Trim();
                OpenYorN = reader[31].ToString().Trim();
                RPIYorN = reader[32].ToString().Trim();
            }
            if(CateType == "SCI期刊論文")
            {
                rdbSCI.Checked = true;
            }
            if(CateType == "非期刊論文")
            {
                rdbNSCI.Checked = true;
            }
            if(CateType == "SSCI期刊論文")
            {
                rdbSSCI.Checked = true;
            }
            if(CateType == "EI期刊論文")
            {
                rdbEI.Checked = true;
            }
            if(CateType == "TSSCI期刊論文")
            {
                rdbSSCI.Checked = true;
            }
            if(CateType == "A&HCI期刊論文")
            {
                rdbAHCI.Checked = true;
            }
            if(CateType == "加重計分支國內優良刊(DI")
            {
                rdbDI.Checked = true;
            }
            if(AuthorOrder == "第一作者")
            {
                rdb1.Checked = true;
            }
            if(AuthorOrder == "並列第一作者")
            {
                rdbB1.Checked = true;
            }
            if(AuthorOrder == "通訊作者")
            {
                rdbC.Checked = true;
            }
            if(AuthorOrder == "並列通訊作者")
            {
                rdbBC.Checked = true;
            }
            if(AuthorOrder == "第二作者")
            {
                rdb2.Checked = true;
            }
            if(AuthorOrder == "第三作者")
            {
                rdb3.Checked = true;
            }
            if(AuthorOrder == "第四作者")
            {
                rdb4.Checked = true;
            }
            if(AuthorOrder == "第四作者以後")
            {
                rdbB4.Checked = true;
            }
            if(PaperType == "原始論著")
            {
                rdbOri.Checked = true;
            }
            if(PaperType == "簡報型論文")
            {
                rdbPpt.Checked = true;
            }
            if(PaperType == "綜合評估")
            {
                rdbComplex.Checked = true;
            }
            if(PaperType == "病例報告")
            {
                rdbCaseReport.Checked = true;
            }
            if(PaperType == "致編者信(原)")
            {
                rdbOriLetter.Checked = true;
            }
            if(PaperType == "致編者信(意見)")
            {
                rdbOpinion.Checked = true;
            }
            if(PaperType == "致編者信(回)")
            {
                rdbReply.Checked = true;
            }
            if(Bio == "統計諮詢")
            {
                ckbConsult.Checked = true;
            }
            if(Bio == "統計諮詢統計分析")
            {
                ckbConsult.Checked = true;
                ckbAnalyze.Checked = true;
            }
            if (Bio == "統計諮詢統計分析列入致謝詞")
            {
                ckbConsult.Checked = true;
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
            }
            if (Bio == "統計諮詢統計分析列入致謝詞健保資料庫")
            {
                ckbConsult.Checked = true;
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
            }
            if (Bio == "統計諮詢統計分析列入致謝詞健保資料庫癌症登記資料庫")
            {
                ckbConsult.Checked = true;
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
                ckbCancerDb.Checked = true;
            }
            if (Bio == "統計分析")
            {
                ckbAnalyze.Checked = true;
            }
            if (Bio == "統計分析列入致謝詞")
            {
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
            }
            if (Bio == "統計分析列入致謝詞健保資料庫")
            {
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
            }
            if (Bio == "統計分析列入致謝詞健保資料庫癌症登記資料庫")
            {
                ckbAnalyze.Checked = true;
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
                ckbCancerDb.Checked = true;
            }
            if (Bio == "列入致謝詞")
            {
                ckbThank.Checked = true;
            }
            if (Bio == "列入致謝詞健保資料庫")
            {
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
            }
            if (Bio == "列入致謝詞健保資料庫癌症登記資料庫")
            {
                ckbThank.Checked = true;
                ckbHealthDb.Checked = true;
                ckbCancerDb.Checked = true;
            }
            if (Bio == "健保資料庫")
            {
                ckbHealthDb.Checked = true;
            }
            if (Bio == "健保資料庫癌症登記資料庫")
            {
                ckbHealthDb.Checked = true;
                ckbCancerDb.Checked = true;
            }
            if (Bio == "癌症登記資料庫")
            {
                ckbCancerDb.Checked = true;
            }
            if(PostUnit == "台中榮總")
            {
                rdbVGHTC.Checked = true;
            }
            if(PostUnit == "其他單位")
            {
                rdbOthUnit.Checked = true;
            }
            if(OpenYorN == "Y")
            {
                rdbOpenY.Checked = true;
            }
            if(OpenYorN == "N")
            {
                rdbOpenN.Checked = true;
            }
            if(RPIYorN == "Y")
            {
                rdbRPIY.Checked = true;
            }
            if(RPIYorN == "N")
            {
                rdbRPIN.Checked = true;
            }
        }

        private void TableFirstRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "編號";
            row.Cells.Add(cell0);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "研究人才名稱";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "年度";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "作者";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "期刊分類";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "院內期刊名稱";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "國科會期刊名稱";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "卷數";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "冊數";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "發表標題";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "頁數";
            row.Cells.Add(cell10);
            HtmlTableCell cell11 = new HtmlTableCell();
            cell11.InnerText = "作者順序";
            row.Cells.Add(cell11);
            HtmlTableCell cell12 = new HtmlTableCell();
            cell12.InnerText = "作者排名分數";
            row.Cells.Add(cell12);
            HtmlTableCell cell13 = new HtmlTableCell();
            cell13.InnerText = "論文性質";
            row.Cells.Add(cell13);
            HtmlTableCell cell14 = new HtmlTableCell();
            cell14.InnerText = "論文性質分數";
            row.Cells.Add(cell14);
            HtmlTableCell cell15 = new HtmlTableCell();
            cell15.InnerText = "第一作者姓名";
            row.Cells.Add(cell15);
            HtmlTableCell cell16 = new HtmlTableCell();
            cell16.InnerText = "第一作者單位";
            row.Cells.Add(cell16);
             HtmlTableCell cell17 = new HtmlTableCell();
            cell17.InnerText = "第一作者職稱";
            row.Cells.Add(cell17);
            HtmlTableCell cell18 = new HtmlTableCell();
            cell18.InnerText = "第一作者卡號";
            row.Cells.Add(cell18);
            HtmlTableCell cell19 = new HtmlTableCell();
            cell19.InnerText = "通訊作者姓名";
            row.Cells.Add(cell19);
            HtmlTableCell cell20 = new HtmlTableCell();
            cell20.InnerText = "通訊作者單位";
            row.Cells.Add(cell20);
            HtmlTableCell cell21 = new HtmlTableCell();
            cell21.InnerText = "通訊作者職稱";
            row.Cells.Add(cell21);
            HtmlTableCell cell22 = new HtmlTableCell();
            cell22.InnerText = "通訊作者卡號";
            row.Cells.Add(cell22);
            HtmlTableCell cell23 = new HtmlTableCell();
            cell23.InnerText = "IRB編號";
            row.Cells.Add(cell23);
            HtmlTableCell cell24 = new HtmlTableCell();
            cell24.InnerText = "動物實驗編號";
            row.Cells.Add(cell24);
            HtmlTableCell cell25 = new HtmlTableCell();
            cell25.InnerText = "院內計畫";
            row.Cells.Add(cell25);
            HtmlTableCell cell26 = new HtmlTableCell();
            cell26.InnerText = "院外計畫";
            row.Cells.Add(cell26);
            HtmlTableCell cell27 = new HtmlTableCell();
            cell27.InnerText = "院校計畫";
            row.Cells.Add(cell27);
            HtmlTableCell cell28 = new HtmlTableCell();
            cell28.InnerText = "產官學計畫";
            row.Cells.Add(cell28);
            HtmlTableCell cell29 = new HtmlTableCell();
            cell29.InnerText = "生統小組";
            row.Cells.Add(cell29);
            HtmlTableCell cell30 = new HtmlTableCell();
            cell30.InnerText = "發表單位";
            row.Cells.Add(cell30);
            HtmlTableCell cell31 = new HtmlTableCell();
            cell31.InnerText = "公開全文";
            row.Cells.Add(cell31);
            HtmlTableCell cell32 = new HtmlTableCell();
            cell32.InnerText = "RPI計算";
            row.Cells.Add(cell32);
            HtmlTableCell cell33 = new HtmlTableCell();
            cell33.InnerText = "----";
            row.Cells.Add(cell33);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);
        }
        private void SCITableFirtRow()
        {
            SCITable.Rows.Clear();
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "2022SCI---";
            HtmlInputText Input = new HtmlInputText();
            Input.ID = "txbSearch";
            Input.Name = "txbSearch";
            cell0.Controls.Add(Input);
            Button btnSearch = new Button();
            btnSearch.Text = "搜尋";
            btnSearch.ID = "btnSearch";
            btnSearch.CssClass = "btn-primary";
            btnSearch.Click += new System.EventHandler(this.SCISearch);
            cell0.Controls.Add(btnSearch);
            row.Cells.Add(cell0);
            SCITable.Rows.Add(row);
            //SCI BUTTON
            rowCount = 1;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSCI = "SELECT full_name FROM SCI_data WHERE j_year = @JYear ORDER BY full_name ASC";
            SqlCommand cmdSCI = new SqlCommand(sqlSCI,con);
            cmdSCI.Parameters.AddWithValue("@JYear", "2020");
            IDataReader readerSCI = cmdSCI.ExecuteReader();
            while(readerSCI.Read())
            {
                HtmlTableRow SCIrow = new HtmlTableRow();
                HtmlTableCell SCIcell = new HtmlTableCell();
                Button btnSCI = new Button();
                btnSCI.Text = readerSCI[0].ToString().Trim();
                btnSCI.ID = "btnSCI" + rowCount;
                btnSCI.Click += new System.EventHandler(this.SCIdate);
                SCIcell.Controls.Add(btnSCI);
                SCIrow.Cells.Add(SCIcell);
                SCITable.Rows.Add(SCIrow);
                rowCount++;
            }
            readerSCI.Close();
            con.Close();
        }

        private void SCIdate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SCISearch(object sender, EventArgs e)
        {
            Button btnSearch = sender as Button;
            Newtable.Visible = true;
            HtmlInputText Input = (HtmlInputText)this.SCITable.FindControl("txbSearch");
            string Search = "";
            if(Input != null)
            {
                Search = Input.Value;
            }
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string SqlSearch = "SELECT full_name FROM SCI_data WHERE j_year = @JYear and full_name LIKE @NameSearch +'%' ORDER BY full_name ASC";
            SqlCommand cmdSearch = new SqlCommand(SqlSearch, con);
            cmdSearch.Parameters.AddWithValue("@JYear", "2020");
            cmdSearch.Parameters.AddWithValue("@NameSearch", Search);            
            IDataReader readerSearch = cmdSearch.ExecuteReader();
            while (readerSearch.Read())
            {
                HtmlTableRow SCIrow = new HtmlTableRow();
                HtmlTableCell SCIcell = new HtmlTableCell();
                Button btnSCI = new Button();
                btnSCI.Text = readerSearch[0].ToString().Trim();
                btnSCI.ID = "btnSCI" + rowCount;
                btnSCI.Click += new System.EventHandler(this.SCISearchData);
                SCIcell.Controls.Add(btnSCI);
                SCIrow.Cells.Add(SCIcell);
                SCITable.Rows.Add(SCIrow);
                rowCount++;
            }
            SCITable.Visible = true;
            Newtable.Visible = true;
            readerSearch.Close();
            con.Close();
        }

        private void SCISearchData(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnSCI_Click(object sender, EventArgs e)
        {
            SCITable.Visible = true;
            Newtable.Visible = true;
            SCITableFirtRow();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnRestar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            PK.Visible = false;
            txbAninum.Value = "";
            txbAuthor.Value = "";
            txbAuthorPoint.Value = "";
            txbBook.Value = "";
            txbCACard.Value = "";
            txbCAJobTitle.Value = "";
            txbCAName.Value = "";
            txbCAUnit.Value = "";
            txbCSCI.Text = "";
            txbFACard.Value = "";
            txbFAJobTitle.Value = "";
            txbFAName.Value = "";
            txbFAUnit.Value = "";
            txbHosIn.Value = "";
            txbHosOut.Value = "";
            txbHosSch.Value = "";
            txbHSCI.Text = "";
            txbInd.Value = "";
            txbIRBnum.Value = "";
            txbPageNum.Value = "";
            txbPaperPoint.Value = "";
            txbPostTitle.Text = "";
            txbRName.Value = "";
            txbRoll.Value = "";
            txbYear.Value = "";
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdb4.Checked = false;
            rdbAHCI.Checked = false;
            rdbB1.Checked = false;
            rdbB4.Checked = false;
            rdbBC.Checked = false;
            rdbC.Checked = false;
            rdbCaseReport.Checked = false;
            rdbComplex.Checked = false;
            rdbDI.Checked = false;
            rdbEI.Checked = false;
            rdbNSCI.Checked = false;
            rdbOpenN.Checked = false;
            rdbOpenY.Checked = false;
            rdbOpinion.Checked = false;
            rdbOri.Checked = false;
            rdbOriLetter.Checked = false;
            rdbOthUnit.Checked = false;
            rdbPpt.Checked = false;
            rdbReply.Checked = false;
            rdbRPIN.Checked = false;
            rdbRPIY.Checked = false;
            rdbSCI.Checked = false;
            rdbSSCI.Checked = false;
            rdbTSSCI.Checked = false;
            rdbVGHTC.Checked = false;
            ckbAnalyze.Checked = false;
            ckbCancerDb.Checked = false;
            ckbConsult.Checked = false;
            ckbHealthDb.Checked = false;
            ckbThank.Checked = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string CateType = "";
            string AuthorOrder = "";
            string PaperType = "";
            string Bio = "";
            string PostUnit = "";
            string OpenYorN = "";
            string RPIYorN = "";
            if(rdbVGHTC.Checked)
            {
                PostUnit = "台中榮總";
            }
            if(rdbOthUnit.Checked)
            {
                PostUnit = "其他單位";
            }
            if(rdbSCI.Checked)
            {
                CateType = "SCI期刊論文";
            }
            if(rdbNSCI.Checked)
            {
                CateType = "非SCI期刊論文";
            }
            if(rdbSSCI.Checked)
            {
                CateType = "SSCI期刊論文";
            }
            if(rdbEI.Checked)
            {
                CateType = "EI期刊論文";
            }
            if(rdbTSSCI.Checked)
            {
                CateType = "TSSCI期刊論文";
            }
            if(rdbAHCI.Checked)
            {
                CateType = "A&HCI期刊論文";
            }
            if(rdbDI.Checked)
            {
                CateType = "加重計分支國內優良刊(DI)";
            }
            if(rdb1.Checked)
            {
                AuthorOrder = "第一作者";
                txbAuthorPoint.Value = "5";
            }
            if(rdbB1.Checked)
            {
                AuthorOrder = "並列第一作者";
                txbAuthorPoint.Value = "5";
            }
            if(rdbC.Checked)
            {
                AuthorOrder = "通訊作者";
                txbAuthorPoint.Value = "5";
            }
            if(rdbBC.Checked)
            {
                AuthorOrder = "並列通訊作者";
                txbAuthorPoint.Value = "5";
            }
            if(rdb2.Checked)
            {
                AuthorOrder = "第二作者";
                txbAuthorPoint.Value = "3";
            }
            if(rdb3.Checked)
            {
                AuthorOrder = "第三作者";
                txbAuthorPoint.Value = "1";
            }
            if(rdb4.Checked)
            {
                AuthorOrder = "第四作者";
                txbAuthorPoint.Value = "0.5";
            }
            if(rdbB4.Checked)
            {
                AuthorOrder = "第四作者以後";
                txbAuthorPoint.Value = "0.5";
            }
            if(rdbOri.Checked)
            {
                PaperType = "原始論著";
                txbPaperPoint.Value = "3";
            }
            if(rdbPpt.Checked)
            {
                PaperType = "簡報型論文";
                txbPaperPoint.Value = "2";
            }
            if(rdbComplex.Checked)
            {
                PaperType = "綜合評估";
                txbPaperPoint.Value = "1";
            }
            if(rdbOriLetter.Checked)
            {
                PaperType = "致編者(原)";
                txbPaperPoint.Value = "0";
            }
            if(rdbOpinion.Checked)
            {
                PaperType = "致編者(意見)";
                txbPaperPoint.Value = "0";
            }
            if(rdbReply.Checked)
            {
                PaperType = "致編者(回)";
                txbPaperPoint.Value = "0";
            }
            if(ckbConsult.Checked)
            {
                Bio = "統計諮詢";
            }
            if(ckbConsult.Checked && ckbAnalyze.Checked)
            {
                Bio = "統計諮詢統計分析";
            }
            if (ckbConsult.Checked && ckbAnalyze.Checked && ckbThank.Checked)
            {
                Bio = "統計諮詢統計分析列入致謝詞";
            }
            if (ckbConsult.Checked && ckbAnalyze.Checked && ckbThank.Checked && ckbHealthDb.Checked)
            {
                Bio = "統計諮詢統計分析列入致謝詞健保資料庫";
            }
            if (ckbConsult.Checked && ckbAnalyze.Checked && ckbThank.Checked && ckbHealthDb.Checked && ckbCancerDb.Checked)
            {
                Bio = "統計諮詢統計分析列入致謝詞健保資料庫癌症登記資料庫";
            }
            if (ckbAnalyze.Checked)
            {
                Bio = "統計分析";
            }
            if (ckbAnalyze.Checked && ckbThank.Checked)
            {
                Bio = "統計分析列入致謝詞";
            }
            if (ckbAnalyze.Checked && ckbThank.Checked && ckbHealthDb.Checked)
            {
                Bio = "統計分析列入致謝詞健保資料庫";
            }
            if (ckbAnalyze.Checked && ckbThank.Checked && ckbHealthDb.Checked && ckbCancerDb.Checked)
            {
                Bio = "統計分析列入致謝詞健保資料庫癌症登記資料庫";
            }
            if (ckbThank.Checked)
            {
                Bio = "列入致謝詞";
            }
            if (ckbThank.Checked && ckbHealthDb.Checked)
            {
                Bio = "列入致謝詞健保資料庫";
            }
            if ( ckbThank.Checked && ckbHealthDb.Checked && ckbCancerDb.Checked)
            {
                Bio = "列入致謝詞健保資料庫癌症登記資料庫";
            }
            if (ckbHealthDb.Checked)
            {
                Bio = "健保資料庫";
            }
            if (ckbHealthDb.Checked && ckbCancerDb.Checked)
            {
                Bio = "健保資料庫癌症登記資料庫";
            }
            if (ckbCancerDb.Checked)
            {
                Bio = "癌症登記資料庫";
            }
            if(rdbOpenY.Checked)
            {
                OpenYorN = "Y";
            }
            if(rdbOpenN.Checked)
            {
                OpenYorN = "N";
            }
            if(rdbRPIY.Checked)
            {
                RPIYorN = "Y";
            }
            if(rdbRPIN.Checked)
            {
                RPIYorN = "N";
            }
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlcheck = "SELECT  Permission  FROM Permission_data WHERE UID = @UID";
            SqlCommand cmdcheck = new SqlCommand(sqlcheck, con);
            cmdcheck.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdcheck.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {
                            string sqlUpdata = "UPDATE Paper_data SET ResearcherName = @RY, Year = @Year, AuthorName = @AN,PaperCategory = @PC," +
                                "PaperHName = @PHC, PaperCName = @PCN, Roll = @Roll, Book = @Book, PostTitle = @PT, PageNum = @PN," +
                                "AuthorOrder = @AO, AuthorOrderPoint = @AOP, PaperType = @PaperType,PaperTypePoint = @PTP, FAuthorName = @FAN," +
                                "FAuthorUnit=@FAU, FAuthorJobtitle = @FAJ, FAuthorCard = @FAC, CAuthorName = @CAN, CAuthorUnit = @CAU, " +
                                " CAuthorJobtitle = @CAJ,CAuthorCard = @CAC,IRBnum = @IRB, AniNum = @Ani, InHosPlan = @IHP, OutHosPlan = @OHP," +
                                "HosSchPlan = @HSP, IndHosPlan = @IndHP, BioAny = @Bio, PostUnit = @PU, PaperOpenYorN = @POYN," +
                                "RPIYorN = @RPI WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdata, con);
                            cmdUpdate.Parameters.AddWithValue("@RY", txbRName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Year", txbYear.Value);
                            cmdUpdate.Parameters.AddWithValue("@AN", txbAuthor.Value);
                            cmdUpdate.Parameters.AddWithValue("@PC", CateType);
                            cmdUpdate.Parameters.AddWithValue("@PHC", txbHSCI.Text);
                            cmdUpdate.Parameters.AddWithValue("@PCN", txbCSCI.Text);
                            cmdUpdate.Parameters.AddWithValue("@Roll", txbRoll.Value);
                            cmdUpdate.Parameters.AddWithValue("@Book", txbBook.Value);
                            cmdUpdate.Parameters.AddWithValue("@PT", txbPostTitle.Text);
                            cmdUpdate.Parameters.AddWithValue("@PN", txbPageNum.Value);
                            cmdUpdate.Parameters.AddWithValue("@AO", AuthorOrder);
                            cmdUpdate.Parameters.AddWithValue("@AOP", txbAuthorPoint.Value);
                            cmdUpdate.Parameters.AddWithValue("@PaperType", PaperType);
                            cmdUpdate.Parameters.AddWithValue("@PTP", txbPaperPoint.Value);
                            cmdUpdate.Parameters.AddWithValue("@FAN", txbFAName.Value);
                            cmdUpdate.Parameters.AddWithValue("@FAU", txbFAUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@FAJ", txbFAJobTitle.Value);
                            cmdUpdate.Parameters.AddWithValue("@FAC", txbFACard.Value);
                            cmdUpdate.Parameters.AddWithValue("@CAN", txbCAName.Value);
                            cmdUpdate.Parameters.AddWithValue("@CAU", txbCAUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@CAJ", txbCAJobTitle.Value);
                            cmdUpdate.Parameters.AddWithValue("@CAC", txbCACard.Value);
                            cmdUpdate.Parameters.AddWithValue("@IRB", txbIRBnum.Value);
                            cmdUpdate.Parameters.AddWithValue("@Ani", txbAninum.Value);
                            cmdUpdate.Parameters.AddWithValue("@IHP", txbHosIn.Value);
                            cmdUpdate.Parameters.AddWithValue("@OHP", txbHosOut.Value);
                            cmdUpdate.Parameters.AddWithValue("@HSP", txbHosSch.Value);
                            cmdUpdate.Parameters.AddWithValue("@IndHP", txbInd.Value);
                            cmdUpdate.Parameters.AddWithValue("@Bio", Bio);
                            cmdUpdate.Parameters.AddWithValue("@PU", PostUnit);
                            cmdUpdate.Parameters.AddWithValue("@POYN", OpenYorN);
                            cmdUpdate.Parameters.AddWithValue("@RPI", RPIYorN);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            PageLoad();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if(Session["UporIns"] == "Ins")
                        {
                        string sqlIns = "INSERT INTO Paper_data VALUES(@RY, @Year,@AN, @PC," +
                            "@PHC,  @PCN,  @Roll, @Book,@PT, @PN," +
                            " @AO, @AOP, @PaperType,@PTP,@FAN," +
                            "@FAU, @FAJ, @FAC, @CAN, @CAU, " +
                            "  @CAJ,@CAC,@IRB,@Ani, @IHP, @OHP," +
                            "@HSP,@IndHP, @Bio, @PU, @POYN," +
                            "@RPI,@PDF,@PDFWORD,@UID, @SCI)";
                        SqlCommand cmdUpdate = new SqlCommand(sqlIns, con);
                        cmdUpdate.Parameters.AddWithValue("@RY", txbRName.Value);
                        cmdUpdate.Parameters.AddWithValue("@Year", txbYear.Value);
                        cmdUpdate.Parameters.AddWithValue("@AN", txbAuthor.Value);
                        cmdUpdate.Parameters.AddWithValue("@PC", CateType);
                        cmdUpdate.Parameters.AddWithValue("@PHC", txbHSCI.Text);
                        cmdUpdate.Parameters.AddWithValue("@PCN", txbCSCI.Text);
                        cmdUpdate.Parameters.AddWithValue("@Roll", txbRoll.Value);
                        cmdUpdate.Parameters.AddWithValue("@Book", txbBook.Value);
                        cmdUpdate.Parameters.AddWithValue("@PT", txbPostTitle.Text);
                        cmdUpdate.Parameters.AddWithValue("@PN", txbPageNum.Value);
                        cmdUpdate.Parameters.AddWithValue("@AO", AuthorOrder);
                        cmdUpdate.Parameters.AddWithValue("@AOP", txbAuthorPoint.Value);
                        cmdUpdate.Parameters.AddWithValue("@PaperType", PaperType);
                        cmdUpdate.Parameters.AddWithValue("@PTP", txbPaperPoint.Value);
                        cmdUpdate.Parameters.AddWithValue("@FAN", txbFAName.Value);
                        cmdUpdate.Parameters.AddWithValue("@FAU", txbFAUnit.Value);
                        cmdUpdate.Parameters.AddWithValue("@FAJ", txbFAJobTitle.Value);
                        cmdUpdate.Parameters.AddWithValue("@FAC", txbFACard.Value);
                        cmdUpdate.Parameters.AddWithValue("@CAN", txbCAName.Value);
                        cmdUpdate.Parameters.AddWithValue("@CAU", txbCAUnit.Value);
                        cmdUpdate.Parameters.AddWithValue("@CAJ", txbCAJobTitle.Value);
                        cmdUpdate.Parameters.AddWithValue("@CAC", txbCACard.Value);
                        cmdUpdate.Parameters.AddWithValue("@IRB", txbIRBnum.Value);
                        cmdUpdate.Parameters.AddWithValue("@Ani", txbAninum.Value);
                        cmdUpdate.Parameters.AddWithValue("@IHP", txbHosIn.Value);
                        cmdUpdate.Parameters.AddWithValue("@OHP", txbHosOut.Value);
                        cmdUpdate.Parameters.AddWithValue("@HSP", txbHosSch.Value);
                        cmdUpdate.Parameters.AddWithValue("@IndHP", txbInd.Value);
                        cmdUpdate.Parameters.AddWithValue("@Bio", Bio);
                        cmdUpdate.Parameters.AddWithValue("@PU", PostUnit);
                        cmdUpdate.Parameters.AddWithValue("@POYN", OpenYorN);
                        cmdUpdate.Parameters.AddWithValue("@RPI", RPIYorN);
                        cmdUpdate.Parameters.AddWithValue("@PDF", "test");
                        cmdUpdate.Parameters.AddWithValue("@PDFWORD", "test");
                        cmdUpdate.Parameters.AddWithValue("@UID", "2");
                        cmdUpdate.Parameters.AddWithValue("@SCI", "1");
                        cmdUpdate.ExecuteNonQuery();
                        PageLoad();
                        System.Windows.Forms.MessageBox.Show("資料已新增");
                        con.Close();
                        Newtable.Visible = false;
                    }
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("資料格式不正確 !");
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("您的權限不足");
            }
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            btnRestar.Visible = true;
            btnConfirm.Visible = true;
            Newtable.Visible = true;
            PK.Visible = false;
            txbAninum.Value = "";
            txbAuthor.Value = "";
            txbAuthorPoint.Value = "";
            txbBook.Value = "";
            txbCACard.Value = "";
            txbCAJobTitle.Value = "";
            txbCAName.Value = "";
            txbCAUnit.Value = "";
            txbCSCI.Text = "";
            txbFACard.Value = "";
            txbFAJobTitle.Value = "";
            txbFAName.Value = "";
            txbFAUnit.Value = "";
            txbHosIn.Value = "";
            txbHosOut.Value = "";
            txbHosSch.Value = "";
            txbHSCI.Text = "";
            txbInd.Value = "";
            txbIRBnum.Value = "";
            txbPageNum.Value = "";
            txbPaperPoint.Value = "";
            txbPostTitle.Text = "";
            txbRName.Value = "";
            txbRoll.Value = "";
            txbYear.Value = "";
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdb4.Checked = false;
            rdbAHCI.Checked = false;
            rdbB1.Checked = false;
            rdbB4.Checked = false;
            rdbBC.Checked = false;
            rdbC.Checked = false;
            rdbCaseReport.Checked = false;
            rdbComplex.Checked = false;
            rdbDI.Checked = false;
            rdbEI.Checked = false;
            rdbNSCI.Checked = false;
            rdbOpenN.Checked = false;
            rdbOpenY.Checked = false;
            rdbOpinion.Checked = false;
            rdbOri.Checked = false;
            rdbOriLetter.Checked = false;
            rdbOthUnit.Checked = false;
            rdbPpt.Checked = false;
            rdbReply.Checked = false;
            rdbRPIN.Checked = false;
            rdbRPIY.Checked = false;
            rdbSCI.Checked = false;
            rdbSSCI.Checked = false;
            rdbTSSCI.Checked = false;
            rdbVGHTC.Checked = false;
            ckbAnalyze.Checked = false;
            ckbCancerDb.Checked = false;
            ckbConsult.Checked = false;
            ckbHealthDb.Checked = false;
            ckbThank.Checked = false;
        }
    }
}