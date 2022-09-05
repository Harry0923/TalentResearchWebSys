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
    public partial class techology_transfer : System.Web.UI.Page
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
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Technology_transfer WHERE UID = @UID";
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
                for(int i = 2; i < reader.FieldCount -1; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if( i == 8 || i == 9)
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

        private void dataDelete(object sender, EventArgs e)
        {
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
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
                    string sqlDle = "DELETE  FROM  Technology_transfer WHERE ID = @ID";
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
            btnConfirm.Text = "確認修改";
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            string YorN = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Technology_transfer WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if(reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbName.Value = reader[1].ToString().Trim();
                txbYear.Value = reader[2].ToString().Trim();
                txbTchName.Value = reader[3].ToString().Trim();
                txbPatName.Value = reader[4].ToString().Trim();
                txbAthUnit.Value = reader[5].ToString().Trim();
                txbAthPeo.Value = reader[6].ToString().Trim();
                txbAthedUnit.Value = reader[7].ToString();
                txbStatDay.Value = reader[8].ToString().Substring(0,9).Trim();
                txbEndDay.Value = reader[9].ToString().Substring(0,9).Trim();
                txbStop.Value = reader[11].ToString().Trim();
                txbAuthPer.Value = reader[10].ToString().Trim();
                txbEquity.Value = reader[12].ToString().Trim();
                txbAthFee.Value = reader[13].ToString().Trim();
                txbCJA.Value = reader[14].ToString().Trim();
                YorN = reader[15].ToString().Trim();
                txbPlanId.Value = reader[16].ToString().Trim();
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

        private void TableFirstRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "編號";
            row.Cells.Add(cell0);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "年度";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "技術名稱";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "專利名稱";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "授權單位";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "技術授權人";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "被授權單位";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "合約日期(起)";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "合約日期(迄)";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "授權年限";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "停止條件";
            row.Cells.Add(cell10);
            HtmlTableCell cell12 = new HtmlTableCell();
            cell12.InnerText = "授權金";
            row.Cells.Add(cell12);
            HtmlTableCell cell13 = new HtmlTableCell();
            cell13.InnerText = "權益金";
            row.Cells.Add(cell13);
            HtmlTableCell cell15 = new HtmlTableCell();
            cell15.InnerText = "CxJxA";
            row.Cells.Add(cell15);
            HtmlTableCell cell16 = new HtmlTableCell();
            cell16.InnerText = "納入RPI";
            row.Cells.Add(cell16);
            HtmlTableCell cell14 = new HtmlTableCell();
            cell14.InnerText = "計畫編號";
            row.Cells.Add(cell14);
            HtmlTableCell cell17 = new HtmlTableCell();
            cell17.InnerText = "-----";
            row.Cells.Add(cell17);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
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
                    if (txbStatDay.Value == "" || txbEndDay.Value == "")
                    {
                        System.Windows.Forms.MessageBox.Show("請輸入日期");
                        return;
                    }
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {
                            string YorN = "";
                            if (rdbY.Checked)
                            {
                                YorN = "Y";
                            }
                            if (rdbN.Checked)
                            {
                                YorN = "N";
                            }
                            string sqlUpdate = "UPDATE Technology_transfer SET ReasercherName = @Rname, Year = @Year, TechnicalName = @TchName," +
                                "PatentName = @PatName, AuthorizeUnit = @AuthUnit, TechnicalLicensee = @TecLic, AuthorizedUnit = @AuthedUnit," +
                                "ContractPeriodStartDate = @StartDate, ContractPeriodEndDate = @EndDate, AuthorizationPeriod = @AuthPer, " +
                                "StopContractConditions = @Stop, Equity = @Equity, AuthorizationFee = @AuthFee, YorNRPI = @YorN WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@Rname", txbName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Year", txbYear.Value);
                            cmdUpdate.Parameters.AddWithValue("@TchName", txbTchName.Value);
                            cmdUpdate.Parameters.AddWithValue("@PatName", txbPatName.Value);
                            cmdUpdate.Parameters.AddWithValue("@AuthUnit", txbAthedUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@TecLic", txbAthPeo.Value);
                            cmdUpdate.Parameters.AddWithValue("AuthedUnit", txbAthedUnit.Value);
                            cmdUpdate.Parameters.AddWithValue("@StartDate", txbStatDay.Value);
                            cmdUpdate.Parameters.AddWithValue("@EndDate", txbEndDay.Value);
                            cmdUpdate.Parameters.AddWithValue("@AuthPer", txbAuthPer.Value);
                            cmdUpdate.Parameters.AddWithValue("@Stop", txbStop.Value);
                            cmdUpdate.Parameters.AddWithValue("@Equity", txbEquity.Value);
                            cmdUpdate.Parameters.AddWithValue("@AuthFee", txbAthFee.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorN", YorN);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            PageLoad();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string YorN = "";
                            if (rdbY.Checked)
                            {
                                YorN = "Y";
                            }
                            if (rdbN.Checked)
                            {
                                YorN = "N";
                            }
                            string sqlIns = "INSERT INTO Technology_transfer VALUES( @Rname, @Year, @TchName," +
                                "@PatName, @AuthUnit, @TecL, @AuthedUnit, @Start, @End, @AuthPer, @Stop, @Equity, " +
                                "@AuthFee, @CJA, @YorN, @PlanID ,@UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@Rname", txbName.Value);
                            cmdIns.Parameters.AddWithValue("@Year", txbYear.Value);
                            cmdIns.Parameters.AddWithValue("@TchName", txbTchName.Value);
                            cmdIns.Parameters.AddWithValue("@PatName", txbPatName.Value);
                            cmdIns.Parameters.AddWithValue("@AuthUnit", txbAthUnit.Value);
                            cmdIns.Parameters.AddWithValue("@Tecl", txbAthPeo.Value);
                            cmdIns.Parameters.AddWithValue("@AuthedUnit", txbAthedUnit.Value);
                            cmdIns.Parameters.AddWithValue("@Start", txbStatDay.Value);
                            cmdIns.Parameters.AddWithValue("@End", txbEndDay.Value);
                            cmdIns.Parameters.AddWithValue("@AuthPer", txbAuthPer.Value);
                            cmdIns.Parameters.AddWithValue("@Stop", txbStop.Value);
                            cmdIns.Parameters.AddWithValue("@Equity", txbEquity.Value);
                            cmdIns.Parameters.AddWithValue("@AuthFee", txbAthFee.Value);
                            cmdIns.Parameters.AddWithValue("@CJA", txbCJA.Value);
                            cmdIns.Parameters.AddWithValue("@YorN", YorN);
                            cmdIns.Parameters.AddWithValue("@PlanID", txbPlanId.Value);
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnRestar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            txbAthPeo.Value = "";
            txbAthedUnit.Value = "";
            txbAthFee.Value = "";
            txbAthPeo.Value = "";
            txbAthUnit.Value = "";
            txbEndDay.Value = "";
            txbEquity.Value = "";
            txbName.Value = "";
            txbPatName.Value = "";
            txbPlanId.Value = "";
            txbStatDay.Value = "";
            txbStop.Value = "";
            txbTchName.Value = "";
            txbYear.Value = "";
            txbAuthPer.Value = "";
            txbCJA.Value = "";
            rdbN.Checked = false;
            rdbY.Checked = false;

        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            txbAthPeo.Value = "";
            txbAthedUnit.Value = "";
            txbAthFee.Value = "";
            txbAthPeo.Value = "";
            txbAthUnit.Value = "";
            txbEndDay.Value = "";
            txbEquity.Value = "";
            txbName.Value = "";
            txbPatName.Value = "";
            txbPlanId.Value = "";
            txbStatDay.Value = "";
            txbStop.Value = "";
            txbTchName.Value = "";
            txbYear.Value = "";
            txbAuthPer.Value = "";
            txbCJA.Value = "";
            rdbN.Checked = false;
            rdbY.Checked = false;
        }
    }
}