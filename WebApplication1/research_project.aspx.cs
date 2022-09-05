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
    public partial class research_project : System.Web.UI.Page
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
            btnRestar.Visible = false;
            btnComfirm.Visible = false;
                rowCount = 1;
                example.Rows.Clear();
                TableFirstRow();
                Newtable.Visible = false;
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string sqlSle = "SELECT * FROM Personal_research WHERE UID = @UID";
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
                    for (int i = 1; i < reader.FieldCount - 1; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i == 8 || i==9)
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
                    Button btnDow = new Button();
                    btnDow.Text = "下載";
                    btnDow.CssClass = "btn-primary";
                    btnDow.ID = "btnDow" + rowCount;
                    cellButton.Controls.Add(btnDow);
                    cellButton.Controls.Add(btnUpdate);
                    cellButton.Controls.Add(btnDelete);
                    row.Cells.Add(cellButton);
                    example.Rows.Add(row);
                    rowCount++;
                }
                reader.Close();
                con.Close();
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
            cell2.InnerText = "年度";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "計畫編號";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "計畫名稱";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "執行單位";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "計畫類型";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "經費提供單位";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "計畫執行起日";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "計畫執行迄日";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "計畫經費";
            row.Cells.Add(cell10);
            HtmlTableCell cell11 = new HtmlTableCell();
            cell11.InnerText = "管理費";
            row.Cells.Add(cell11);
            HtmlTableCell cell12 = new HtmlTableCell();
            cell12.InnerText = "是否為主持人";
            row.Cells.Add(cell12);
            HtmlTableCell cell13 = new HtmlTableCell();
            cell13.InnerText = "佐證資料上傳";
            row.Cells.Add(cell13);
            HtmlTableCell cell14 = new HtmlTableCell();
            cell14.InnerText = "備註";
            row.Cells.Add(cell14);
            HtmlTableCell cell15 = new HtmlTableCell();
            cell15.InnerText = "------";
            row.Cells.Add(cell15);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);
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
                    string sqlDle = "DELETE FROM Personal_research WHERE ID = @ID";
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
            btnComfirm.Text = "確認修改";
            btnComfirm.Visible = true;
            btnRestar.Visible = true;
            string PType = "";
            string YorN = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Personal_research WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if (reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbName.Value = reader[1].ToString().Trim();
                txbYeay.Value = reader[2].ToString().Trim();
                txbPlanID.Value = reader[3].ToString().Trim();
                txbPName.Value = reader[4].ToString().Trim();
                txbExeUnit.Value = reader[5].ToString().Trim();
                PType = reader[6].ToString().Trim();
                txbFeeUnit.Value = reader[7].ToString().Trim();
                txbStarDay.Value = reader[8].ToString().Substring(0,9).Trim();
                txbEndDay.Value = reader[9].ToString().Substring(0,9).Trim();
                txbPFee.Value = reader[10].ToString().Trim();
                txbMFee.Value = reader[11].ToString().Trim();
                YorN = reader[12].ToString().Trim();
                txbRemark.Value = reader[13].ToString().Trim();
            }
            if(PType == "個人")
            {
                rdbPer.Checked = true;
            }
            if(PType == "整合")
            {
                rdbAll.Checked = true;
            }
            if(PType == "其他")
            {
                rdbOth.Checked = true;
            }
            if(YorN == "Y")
            {
                rdbY.Checked = true;
            }
            if(YorN == "N")
            {
                rdbN.Checked = true;
            }
            Newtable.Visible = true;
            reader.Close();
            con.Close();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnRestar.Visible = true;
            btnComfirm.Visible = true;
            btnComfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            PK.Visible = false;
            txbEndDay.Value = "";
            txbExeUnit.Value = "";
            txbFeeUnit.Value = "";
            txbFeeUnit.Value = "";
            txbMFee.Value = "";
            txbName.Value = "";
            txbPFee.Value = "";
            txbPlanID.Value = "";
            txbPName.Value = "";
            txbRemark.Value = "";
            txbStarDay.Value = "";
            txbYeay.Value = "";
            rdbAll.Checked = false;
            rdbOth.Checked = false;
            rdbPer.Checked = false;
            rdbY.Checked = false;
            rdbN.Checked = false;
        }

        protected void btnComfirm_Click(object sender, EventArgs e)
        {
            string PaperType = "";
            string YorN = "";
            if(rdbY.Checked)
            {
                YorN = "Y";
            }
            if (rdbN.Checked)
            {
                YorN = "N";
            }
            if(rdbPer.Checked)
            {
                PaperType = "個人";
            }
            if(rdbAll.Checked)
            {
                PaperType = "整合";
            }
            if(rdbOth.Checked)
            {
                PaperType = "其他";
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
                    if (txbStarDay.Value == "" || txbEndDay.Value == "")
                    {
                        System.Windows.Forms.MessageBox.Show("請輸入日期");
                        return;
                    }
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {
                            string sqlUpdate = "UPDATE Personal_research SET ResearcherName = @RN, Year = @Y, PlanID = @PID," +
                                "Planname = @PName, ExecutiveUnit = @EU, ProgramCategory = @PC, FundingUnit = @FU, PlanExecutionDate = @StarDay," +
                                "PlanDeadline = @EndDay, ApprovedPlanExpenses = @APE, ApprovedManagementFee = @MFee,YorNHost = @YorN, TestimonialInformation = @Test," +
                                "Remark = @Remark WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@RN", txbName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Y", txbYeay.Value);
                            cmdUpdate.Parameters.AddWithValue("@PID", txbPlanID.Value);
                            cmdUpdate.Parameters.AddWithValue("@PName", txbPName.Value);
                            cmdUpdate.Parameters.AddWithValue("@EU", txbExeUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@PC", PaperType);
                            cmdUpdate.Parameters.AddWithValue("@FU", txbFeeUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@StarDay", txbStarDay.Value);
                            cmdUpdate.Parameters.AddWithValue("@EndDay", txbEndDay.Value);
                            cmdUpdate.Parameters.AddWithValue("@APE", txbPFee.Value);
                            cmdUpdate.Parameters.AddWithValue("@MFee", txbMFee.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorN", YorN);
                            cmdUpdate.Parameters.AddWithValue("@Test", "Test");
                            cmdUpdate.Parameters.AddWithValue("@Remark", txbRemark.Value);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            PageLoad();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlIns = "INSERT INTO Personal_research VALUES( @RN, @Y, @PID," +
                               " @PName, @EU,  @PC, @FU, @StarDay," +
                               "@EndDay, @APE, @MFee,@YorN,  @Test," +
                               "@Remark, @UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@RN", txbName.Value);
                            cmdIns.Parameters.AddWithValue("@Y", txbYeay.Value);
                            cmdIns.Parameters.AddWithValue("@PID", txbPlanID.Value);
                            cmdIns.Parameters.AddWithValue("@PName", txbPName.Value);
                            cmdIns.Parameters.AddWithValue("@EU", txbExeUnit.Value);
                            cmdIns.Parameters.AddWithValue("@PC", PaperType);
                            cmdIns.Parameters.AddWithValue("@FU", txbFeeUnit.Value);
                            cmdIns.Parameters.AddWithValue("@StarDay", txbStarDay.Value);
                            cmdIns.Parameters.AddWithValue("@EndDay", txbEndDay.Value);
                            cmdIns.Parameters.AddWithValue("@APE", txbPFee.Value);
                            cmdIns.Parameters.AddWithValue("@MFee", txbMFee.Value);
                            cmdIns.Parameters.AddWithValue("@YorN", YorN);
                            cmdIns.Parameters.AddWithValue("@Test", "Test");
                            cmdIns.Parameters.AddWithValue("@Remark", txbRemark.Value);
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
            PK.Visible = false;
            txbEndDay.Value = "";
            txbExeUnit.Value = "";
            txbFeeUnit.Value = "";
            txbFeeUnit.Value = "";
            txbMFee.Value = "";
            txbName.Value = "";
            txbPFee.Value = "";
            txbPlanID.Value = "";
            txbPName.Value = "";
            txbRemark.Value = "";
            txbStarDay.Value = "";
            txbYeay.Value = "";
            rdbAll.Checked = false;
            rdbOth.Checked = false;
            rdbPer.Checked = false;
            rdbY.Checked = false;
            rdbN.Checked = false;
        }
    }
}