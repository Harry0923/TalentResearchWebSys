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
    public partial class serminar_paper : System.Web.UI.Page
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
            rowCount = 1;
            example.Rows.Clear();
            TableFirstRow();
            Newtable.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Seminar_paper_data WHERE UID = @UID";
            SqlCommand cmdSle = new SqlCommand(sqlSle, con);
            cmdSle.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdSle.ExecuteReader();
            while(reader.Read())
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellNum = new HtmlTableCell();
                cellNum.InnerText = rowCount.ToString();
                row.Cells.Add(cellNum);
                Session[rowCount.ToString()] = reader[0].ToString();
                for(int i = 1; i < reader.FieldCount-1; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if(i == 2)
                    {
                        string date = reader[i].ToString();
                        cell.InnerText = date.Substring(0, 9);
                    }
                    else
                    {
                        cell.InnerText = reader[i].ToString();
                    }
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
            con.Close();
        }

        private void dataUpdate(object sender, EventArgs e)
        {
            btnRestar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認修改";
            string HostType = "";
            string HowToPub = "";
            string PaperType = "";
            string Sort = "";
            string MeetingType = "";
            string MeetLoc = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Seminar_paper_data WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if(reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbName.Value = reader[1].ToString().Trim();
                txbDate.Value = reader[2].ToString().Substring(0, 9);
                HostType = reader[3].ToString().Trim();
                txbPaperName.Value = reader[4].ToString().Trim();
                PaperType = reader[5].ToString().Trim();
                HowToPub = reader[6].ToString().Trim();
                Sort = reader[7].ToString().Trim();
                txbAll.Value = reader[8].ToString().Trim();
                txbMeetName.Value = reader[9].ToString().Trim();
                MeetingType = reader[10].ToString().Trim();
                MeetLoc = reader[11].ToString().Trim();
            }
            Newtable.Visible = true;
            if(HostType == "總主持人")
            {
                rdbMain.Checked = true;
            }
            if(HostType == "分組討論主持人")
            {
                rdbDiv.Checked = true;
            }
            if(HostType == "演講者")
            {
                rdbSpeecher.Checked = true;
            }
            if(PaperType == "原創性論文")
            {
                rdbCre.Checked = true;
            }
            else if(HostType == "病例報告")
            {
                rdbPat.Checked = true;
            }
            else if(HostType == "簡報性論文")
            {
                rdbPpt.Checked = true;
            }
            else
            {
                rdbPOth.Checked = true;
            }
            if(HowToPub == "口頭報告")
            {
                rdbVerbal.Checked = true;
            }
            if(HowToPub == "海報展示")
            {
                rdbPost.Checked = true;
            }
            if(Sort == "第一")
            {
                rdb1.Checked = true;
            }
            else if(Sort == "通訊")
            {
                rdbCom.Checked = true;
            }
            else if(Sort == "第二")
            {
                rdb2.Checked = true;
            }
            else if(Sort == "第三")
            {
                rdb3.Checked = true;
            }
            else
            {
                rdbOth.Checked = true;
                txbOth.Value = Sort;
            }
            if(MeetingType == "國際型")
            {
                rdbInt.Checked = true;
            }
            if(MeetingType == "國內型")
            {
                rdbDom.Checked = true;
            }
            if(MeetingType == "地區型")
            {
                rdbArea.Checked = true;
            }
            if(MeetLoc == "國內")
            {
                rdbDomLoc.Checked = true;
            }
            else
            {
                rdbIntLoc.Checked = true;
                txbLoc.Value = MeetLoc;
            }
            reader.Close();
            con.Close();
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
            if(reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    string sqlDle = "DELETE FROM Seminar_paper_data WHERE ID = @ID";
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

        private void TableFirstRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "編號";
            row.Cells.Add(cell0);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "姓名";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "日期";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "主持類型";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "論文名稱";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "論文類型";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "發表方式";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "作者排序";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "全作者";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "會議名稱";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "會議類型";
            row.Cells.Add(cell10);
            HtmlTableCell cell11 = new HtmlTableCell();
            cell11.InnerText = "會議地點";
            row.Cells.Add(cell11);
            HtmlTableCell cell12 = new HtmlTableCell();
            cell12.InnerText = "---------";
            row.Cells.Add(cell12);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            PK.Visible = false;
            txbAll.Value = "";
            txbDate.Value = "";
            txbLoc.Value = "";
            txbMeetName.Value = "";
            txbName.Value = "";
            txbPaperName.Value = "";
            txbPOth.Value = "";
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdbArea.Checked = false;
            rdbCom.Checked = false;
            rdbCre.Checked = false;
            rdbDiv.Checked = false;
            rdbDom.Checked = false;
            rdbDomLoc.Checked = false;
            rdbInt.Checked = false;
            rdbIntLoc.Checked = false;
            rdbMain.Checked = false;
            rdbOth.Checked = false;
            rdbPat.Checked = false;
            rdbPost.Checked = false;
            rdbPOth.Checked = false;
            rdbPpt.Checked = false;
            rdbSpeecher.Checked = false;
            rdbVerbal.Checked = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            PK.Visible = false;
            string HostType = "";
            string PaperType = "";
            string HowPub = "";
            string AuthorSort = "";
            string IntType = "";
            string InOrOut = "";
            if(rdbMain.Checked)
            {
                HostType = "總主持人";
            }
            if(rdbDiv.Checked)
            {
                HostType = "分組討論主持人";
            }
            if(rdbSpeecher.Checked)
            {
                HostType = "演講者";
            }
            if(rdbVerbal.Checked)
            {
                HowPub = "口頭報告";
            }
            if(rdbPost.Checked)
            {
                HowPub = "海報展示";
            }
            if(rdbCre.Checked)
            {
                PaperType = "原創性論文";
            }
            if(rdbPat.Checked)
            {
                PaperType = "病例報告";
            }
            if(rdbPpt.Checked)
            {
                PaperType = "簡報性論文";
            }
            if(rdbPOth.Checked)
            {
                PaperType = txbPOth.Value;
            }
            if(rdb1.Checked)
            {
                AuthorSort = "1";
            }
            if(rdbCom.Checked)
            {
                AuthorSort = "通訊";
            }
            if(rdb2.Checked)
            {
                AuthorSort = "2";
            }
            if(rdb3.Checked)
            {
                AuthorSort = "3";
            }
            if(rdbOth.Checked)
            {
                AuthorSort = txbOth.Value;
            }
            if(rdbInt.Checked)
            {
                IntType = "國際型";
            }
            if(rdbDom.Checked)
            {
                IntType = "國內型";
            }
            if(rdbArea.Checked)
            {
                IntType = "地區型";
            }
            if (rdbDomLoc.Checked)
            {
                InOrOut = "國內";
            }
            if(rdbIntLoc.Checked)
            {
                InOrOut = txbLoc.Value;
            }
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlcheck = "SELECT  Permission  FROM Permission_data WHERE UID = @UID";
            SqlCommand cmdcheck = new SqlCommand(sqlcheck, con);
            cmdcheck.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdcheck.ExecuteReader();
            if(reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    if (txbDate.Value == "")
                    {
                        System.Windows.Forms.MessageBox.Show("請輸入日期");
                        return;
                    }
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {
                            string sqlUpdate = "UPDATE Seminar_paper_data SET AuthorName=@AuthName, Date=@Date," +
                                "HostType = @Host, PaperName = @Pname, PaperType = @Ptype, HowToPublish = @How, AuthorSort = @AuthSort," +
                                "AllAuthor = @All, MeetingName = @MeetN, MeetingType = @MeetT, DomesticAndForeignOrPlace = @InOrOut WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@AuthName", txbName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Date", txbDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@Host", HostType);
                            cmdUpdate.Parameters.AddWithValue("@Pname", txbPaperName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Ptype", PaperType);
                            cmdUpdate.Parameters.AddWithValue("@How", HowPub);
                            cmdUpdate.Parameters.AddWithValue("@AuthSort", AuthorSort);
                            cmdUpdate.Parameters.AddWithValue("@All", txbAll.Value);
                            cmdUpdate.Parameters.AddWithValue("@MeetN", txbMeetName.Value);
                            cmdUpdate.Parameters.AddWithValue("@MeetT", IntType);
                            cmdUpdate.Parameters.AddWithValue("@InOrOut", InOrOut);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            PageLoad();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlIns = "INSERT INTO Seminar_paper_data VALUES(@AuthorName, @Date, @Host, @PName, @Ptype, @How, @AuthorSort, @All," +
                                "@MeetN, @MeetT, @InOrOut,@UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@AuthorName", txbName.Value);
                            cmdIns.Parameters.AddWithValue("@Date", txbDate.Value);
                            cmdIns.Parameters.AddWithValue("@Host", HostType);
                            cmdIns.Parameters.AddWithValue("@PName", txbPaperName.Value);
                            cmdIns.Parameters.AddWithValue("@Ptype", PaperType);
                            cmdIns.Parameters.AddWithValue("@How", HowPub);
                            cmdIns.Parameters.AddWithValue("@AuthorSort", AuthorSort);
                            cmdIns.Parameters.AddWithValue("@All", txbAll.Value);
                            cmdIns.Parameters.AddWithValue("@MeetN", txbMeetName.Value);
                            cmdIns.Parameters.AddWithValue("@MeetT", IntType);
                            cmdIns.Parameters.AddWithValue("@InOrOut", InOrOut);
                            cmdIns.Parameters.AddWithValue("@UID", "2");
                            cmdIns.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show("資料已新增");
                            PageLoad();
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
            Newtable.Visible = true;
            txbAll.Value = "";
            txbDate.Value = "";
            txbLoc.Value = "";
            txbMeetName.Value = "";
            txbName.Value = "";
            txbPOth.Value = "";
            txbPaperName.Value = "";
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdbArea.Checked = false;
            rdbCom.Checked = false;
            rdbCre.Checked = false;
            rdbDiv.Checked = false;
            rdbDom.Checked = false;
            rdbDomLoc.Checked = false;
            rdbInt.Checked = false;
            rdbIntLoc.Checked = false;
            rdbMain.Checked = false;
            rdbOth.Checked = false;
            rdbPat.Checked = false;
            rdbPost.Checked = false;
            rdbPOth.Checked = false;
            rdbPpt.Checked = false;
            rdbSpeecher.Checked = false;
            rdbVerbal.Checked = false;
        }
    }
}