using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class patent_achievements : System.Web.UI.Page
    {

        string conStr = "Data Source=DESKTOP-API2RQR\\MSSQLSERVER_2019;Initial Catalog=Talent-research;Integrated Security=True";
        string dbID;

        protected void Page_Load(object sender, EventArgs e)
        {
            showTableData();
        }

        protected void dataDelete(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            //取得資料庫裡資料表的PK(ID)存到dbID變數裡，btnDelete.ID.Substring(9)為那筆資料的編號
            dbID = Session[btnDelete.ID.Substring(9)].ToString();
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
                    string deleteStr = "DELETE Patent_data WHERE PlanID = @PlanID";
                    SqlCommand cmd = new SqlCommand(deleteStr, con);
                    cmd.Parameters.AddWithValue("@PlanID", dbID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        System.Windows.Forms.MessageBox.Show("刪除成功");
                    }
                    showTableData();
                    con.Close();
                }
                else
                    System.Windows.Forms.MessageBox.Show("您的權限不足");

            }
        }

        protected void dataUpdate(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            btnConfirm.Text = "確認修改";
            string PatType = "";
            string Dom = "";
            string YorN = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = (Button)sender;
            //取得資料庫裡資料表的PK(ID)存到dbID變數裡，btnDelete.ID.Substring(9)為那筆資料的編號
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Patent_data WHERE PlanID = @PlanID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@PlanID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if (reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbName.Value = reader[1].ToString().Trim();
                txbPatentApprovalYear.Value = reader[2].ToString().Trim();
                txbPatentName.Value = reader[3].ToString().Trim();
                txbCountry.Value = reader[4].ToString().Trim();
                PatType = reader[5].ToString().Trim();
                Dom = reader[6].ToString().Trim();
                txbPatentNum.Value = reader[7].ToString().Trim();
                txbCreator.Value = reader[8].ToString().Trim();
                txbPatentee.Value = reader[9].ToString().Trim();
                txbPatentFilingDate.Value = reader[10].ToString().Substring(0, 9).Trim();
                txbPatentApplicationNum.Value = reader[11].ToString().Trim();
                txbPatentApplicationFee.Value = reader[12].ToString().Trim();
                txbPatentPeriodStartDate.Value = reader[13].ToString().Substring(0, 9).Trim();
                txbPatentPeriodExpiryDate.Value = reader[14].ToString().Substring(0, 9).Trim();
                txbPatentOfficeNum.Value = reader[15].ToString().Trim();
                txbPatentOfficeName.Value = reader[16].ToString().Trim();
                txbMaintenancePatentAnnualFee.Value = reader[17].ToString().Trim();
                txbTechnicalSituation.Value = reader[18].ToString().Trim();
                YorN = reader[19].ToString().Trim();
            }
            if(PatType == "發明")
            {
                rdbInvention.Checked = true;
            }
            if(PatType == "新型")
            {
                rdbNew1.Checked = true;
            }
            if(PatType == "新樣式")
            {
                rdbNew2.Checked = true;
            }
            if(Dom == "國內")
            {
                rdbDomestic.Checked = true;
            }
            if(Dom == "國外")
            {
                rdbForeign.Checked = true;
            }
            if(YorN == "Y")
            {
                rpiY.Checked = true;
            }
            if(YorN == "N")
            {
                rpiN.Checked = true;
            }
            Newtable.Visible = true;
            reader.Close();
            con.Close();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            txbName.Value = "";
            txbPatentApprovalYear.Value = "";
            txbPatentName.Value = "";
            txbCountry.Value = "";
            txbPatentNum.Value = "";
            txbCreator.Value = "";
            txbPatentee.Value = "";
            txbPatentFilingDate.Value = "";
            txbPatentApplicationNum.Value = "";
            txbPatentApplicationFee.Value = "";
            txbPatentPeriodStartDate.Value = "";
            txbPatentPeriodExpiryDate.Value = "";
            txbPatentOfficeNum.Value = "";
            txbPatentOfficeName.Value = "";
            txbMaintenancePatentAnnualFee.Value = "";
            txbTechnicalSituation.Value = "";
            rdbDomestic.Checked = false;
            rdbForeign.Checked = false;
            rdbInvention.Checked = false;
            rdbNew1.Checked = false;
            rdbNew2.Checked = false;
            rpiN.Checked = false;
            rpiY.Checked = false;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            PK.Visible = false;
            txbName.Value = "";
            txbPatentApprovalYear.Value = "";
            txbPatentName.Value = "";
            txbCountry.Value = "";
            txbPatentNum.Value = "";
            txbCreator.Value = "";
            txbPatentee.Value = "";
            txbPatentFilingDate.Value = "";
            txbPatentApplicationNum.Value = "";
            txbPatentApplicationFee.Value = "";
            txbPatentPeriodStartDate.Value = "";
            txbPatentPeriodExpiryDate.Value = "";
            txbPatentOfficeNum.Value = "";
            txbPatentOfficeName.Value = "";
            txbMaintenancePatentAnnualFee.Value = "";
            txbTechnicalSituation.Value = "";
            rdbDomestic.Checked = false;
            rdbForeign.Checked = false;
            rdbInvention.Checked = false;
            rdbNew1.Checked = false;
            rdbNew2.Checked = false;
            rpiN.Checked = false;
            rpiY.Checked = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            PK.Visible = false;
            string patentType = "";
            string domesticForeign = "";
            string isRPI = "";

            if (rdbInvention.Checked)
                patentType = "發明";
            if (rdbNew1.Checked)
                patentType = "新型";
            if (rdbNew2.Checked)
                patentType = "新樣式";

            if (rdbDomestic.Checked)
                domesticForeign = "國內";
            if (rdbForeign.Checked)
                domesticForeign = "國外";

            if (rpiY.Checked)
                isRPI = "Y";
            if (rpiN.Checked)
                isRPI = "N";
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
                    if (txbPatentFilingDate.Value == "" || txbPatentPeriodStartDate.Value == "" || txbPatentPeriodExpiryDate.Value == "")
                    {
                        System.Windows.Forms.MessageBox.Show("請輸入日期");
                        return;
                    }
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {

                            string sqlUpdate = "UPDATE Patent_data SET ResearcherName = @RName ,PatentApprovalYear = @PatentApprovalYear, PatentName = @PatentName," +
                                "Country = @Country, PatentCategory = @PatentCategory, DomesticForeign = @DomesticForeign, Patentnum = @PatentNum," +
                                "Creator = @Creator, Patentee = @Patentee, PatentFilingDate = @PatentFilingDate, PatentApplicationnum = @PatentApplicationNum," +
                                "PatentApplicationFee = @PatentApplicationFee, PatentPeriodStartDate = @PatentPeriodStartDate, PatentPeriodExpiryDate = @PatentPeriodExpiryDate," +
                                "PlanNum = @PlanNum, PatentTrademarkServices = @PTS, MaintenancePatentAnnualFee = @MaintenancePatentAnnualFee," +
                                "TechnicalSituation = @TechnicalSituation, YorNRPI = @YorNRPI WHERE PlanID = @PlanID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@RName", txbName.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentApprovalYear", txbPatentApprovalYear.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentName", txbPatentName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Country", txbCountry.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentCategory", patentType);
                            cmdUpdate.Parameters.AddWithValue("@DomesticForeign", domesticForeign);
                            cmdUpdate.Parameters.AddWithValue("@PatentNum", txbPatentNum.Value);
                            cmdUpdate.Parameters.AddWithValue("@Creator", txbCreator.Value);
                            cmdUpdate.Parameters.AddWithValue("@Patentee", txbPatentee.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentFilingDate", txbPatentFilingDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentApplicationNum", txbPatentApplicationNum.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentApplicationFee", txbPatentApplicationFee.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentPeriodStartDate", txbPatentPeriodStartDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatentPeriodExpiryDate", txbPatentPeriodExpiryDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanNum", txbPatentOfficeNum.Value);
                            cmdUpdate.Parameters.AddWithValue("@PTS", txbPatentOfficeName.Value);
                            cmdUpdate.Parameters.AddWithValue("@MaintenancePatentAnnualFee", txbMaintenancePatentAnnualFee.Value);
                            cmdUpdate.Parameters.AddWithValue("@TechnicalSituation", txbTechnicalSituation.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorNRPI", isRPI);
                            cmdUpdate.Parameters.AddWithValue("@PlanID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            showTableData();
                            if (cmdUpdate.ExecuteNonQuery() > 0)
                                System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlIns = "INSERT INTO Patent_data VALUES(@RName ,@PatentApprovalYear, @PatentName, @Country, @PatentCategory, @DomesticForeign, @PatentNum," +
                                " @Creator, @Patentee, @PatentFilingDate, @PatentApplicationNum, @PatentApplicationFee, @PatentPeriodStartDate, @PatentPeriodExpiryDate," +
                                " @PatentOfficeNum, @PatentOfficeName, @MaintenancePatentAnnualFee, @TechnicalSituation, @YorNRPI, @UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@RName", txbName.Value);
                            cmdIns.Parameters.AddWithValue("@PatentApprovalYear", txbPatentApprovalYear.Value);
                            cmdIns.Parameters.AddWithValue("@PatentName", txbPatentName.Value);
                            cmdIns.Parameters.AddWithValue("@Country", txbCountry.Value);
                            cmdIns.Parameters.AddWithValue("@PatentCategory", patentType);
                            cmdIns.Parameters.AddWithValue("@DomesticForeign", domesticForeign);
                            cmdIns.Parameters.AddWithValue("@PatentNum", txbPatentNum.Value);
                            cmdIns.Parameters.AddWithValue("@Creator", txbCreator.Value);
                            cmdIns.Parameters.AddWithValue("@Patentee", txbPatentee.Value);
                            cmdIns.Parameters.AddWithValue("@PatentFilingDate", txbPatentFilingDate.Value);
                            cmdIns.Parameters.AddWithValue("@PatentApplicationNum", txbPatentApplicationNum.Value);
                            cmdIns.Parameters.AddWithValue("@PatentApplicationFee", txbPatentApplicationFee.Value);
                            cmdIns.Parameters.AddWithValue("@PatentPeriodStartDate", txbPatentPeriodStartDate.Value);
                            cmdIns.Parameters.AddWithValue("@PatentPeriodExpiryDate", txbPatentPeriodExpiryDate.Value);
                            cmdIns.Parameters.AddWithValue("@PatentOfficeNum", txbPatentOfficeNum.Value);
                            cmdIns.Parameters.AddWithValue("@PatentOfficeName", txbPatentOfficeName.Value);
                            cmdIns.Parameters.AddWithValue("@MaintenancePatentAnnualFee", txbMaintenancePatentAnnualFee.Value);
                            cmdIns.Parameters.AddWithValue("@TechnicalSituation", txbTechnicalSituation.Value);
                            cmdIns.Parameters.AddWithValue("@YorNRPI", isRPI);
                            cmdIns.Parameters.AddWithValue("@UID", "2");
                            if (cmdIns.ExecuteNonQuery() > 0)
                                System.Windows.Forms.MessageBox.Show("資料已新增");
                            showTableData();
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

        private void showTableData() //顯示資料
        {
            btnConfirm.Visible = false;
            btnRestar.Visible = false;
            tableData.Rows.Clear();
            showTableFirstRow();
            Newtable.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string queryStr = "SELECT * FROM Patent_data WHERE UID = @UID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@UID", "2"); //"b"參數待修改，改成使用者的員工編號
            IDataReader reader = cmd.ExecuteReader();
            int rowCount = 1; //第幾筆資料
            while (reader.Read())
            {
                //每筆資料的第一個欄位的編號
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellNum = new HtmlTableCell();
                cellNum.InnerText = rowCount.ToString();
                row.Cells.Add(cellNum);
                Session[rowCount.ToString()] = reader[0].ToString(); //Session["畫面上的第幾筆資料"] = "資料庫裡資料表的PK(ID)"

                //每筆資料的第二個欄位以後的資料，reader.FieldCount - 1 是因為最後一個欄位是員工編號不用顯示在畫面上
                for (int i = 1; i < reader.FieldCount - 1; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if (i == 10 || i == 13|| i == 14)
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

                //每筆資料的最後一個欄位動態新增修改和刪除按鈕
                HtmlTableCell cellButton = new HtmlTableCell();
                Button btnUpdate = new Button();
                btnUpdate.Text = "更改";
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

                tableData.Rows.Add(row);
                rowCount++;
            }

            reader.Close();
            con.Close();
        }

        private void showTableFirstRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "編號";
            row.Cells.Add(cell0);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "姓名";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "專利核准年度";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "專利名稱";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "國別";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "專利類別";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "國內/外";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "專利號碼";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "發明人";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "專利權人";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "專利申請日";
            row.Cells.Add(cell10);
            HtmlTableCell cell11 = new HtmlTableCell();
            cell11.InnerText = "專利申請號";
            row.Cells.Add(cell11);
            HtmlTableCell cell12 = new HtmlTableCell();
            cell12.InnerText = "專利申請費";
            row.Cells.Add(cell12);
            HtmlTableCell cell13 = new HtmlTableCell();
            cell13.InnerText = "專利期間起日";
            row.Cells.Add(cell13);
            HtmlTableCell cell14 = new HtmlTableCell();
            cell14.InnerText = "專利期間迄日";
            row.Cells.Add(cell14);
            HtmlTableCell cell15 = new HtmlTableCell();
            cell15.InnerText = "計畫編號";
            row.Cells.Add(cell15);
            HtmlTableCell cell16 = new HtmlTableCell();
            cell16.InnerText = "事務所名稱";
            row.Cells.Add(cell16);
            HtmlTableCell cell17 = new HtmlTableCell();
            cell17.InnerText = "維護年費情形";
            row.Cells.Add(cell17);
            HtmlTableCell cell18 = new HtmlTableCell();
            cell18.InnerText = "技轉情形";
            row.Cells.Add(cell18);
            HtmlTableCell cell19 = new HtmlTableCell();
            cell19.InnerText = "是否納入RPI";
            row.Cells.Add(cell19);
            HtmlTableCell cell20 = new HtmlTableCell();
            cell20.InnerText = "----";
            row.Cells.Add(cell20);
            row.Attributes.Add("class", "table-dark");
            tableData.Rows.Add(row);
        }
    }
}