using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class industry_academia : System.Web.UI.Page
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
            btnrestar.Visible = false;
            BtnConfirm.Visible = false;
            rowCount = 1;
            PK.Visible = false;
            example.Rows.Clear();
            TableFirstRow();
            Newtable.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Industry_Cooperation_data where UID = @UID";
            SqlCommand cmdSle = new SqlCommand(sqlSle, con);
            cmdSle.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmdSle.ExecuteReader();
            while (reader.Read())
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellNum = new HtmlTableCell();
                cellNum.InnerText = rowCount.ToString();
                row.Cells.Add(cellNum);
                Session[rowCount.ToString()] = reader[0].ToString(); //session["1"] = 5;
                for (int i = 1; i < reader.FieldCount - 1; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if (i == 6 || i == 7)
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
                    string sqlDle = "DELETE FROM Industry_Cooperation_data WHERE ID = @ID";
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
            cell1.InnerText = "年度";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "計畫編號";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "計畫名稱";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "合作廠商";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "執行機構";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "執行起日";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "執行迄日";
            row.Cells.Add(cell7);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "執行經費(元)";
            row.Cells.Add(cell8);
            HtmlTableCell cell9 = new HtmlTableCell();
            cell9.InnerText = "人事費(元)";
            row.Cells.Add(cell9);
            HtmlTableCell cell10 = new HtmlTableCell();
            cell10.InnerText = "可否更動";
            row.Cells.Add(cell10);
            HtmlTableCell cell11 = new HtmlTableCell();
            cell11.InnerText = "------";
            row.Attributes.Add("class", "table-dark");
            row.Cells.Add(cell11);
            example.Rows.Add(row);

        }
        protected void dataUpdate(object sender, EventArgs e)
        {
            btnrestar.Visible = true;
            BtnConfirm.Visible = true;
            string YorN = "";
            BtnConfirm.Text = "確認修改";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            //System.Windows.Forms.MessageBox.Show(dbID); //取得編號dbID
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Industry_Cooperation_data where ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if (reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbPlanName.Value = reader[3].ToString().Trim();
                txbPerExp.Value = reader[9].ToString().Trim();
                txbPlanExp.Value = reader[8].ToString().Trim();
                txbPlanEndDate.Value = reader[7].ToString().Substring(0,9).Trim();
                txbPlanExeDate.Value = reader[6].ToString().Substring(0,9).Trim();
                txbExeOrgan.Value = reader[5].ToString().Trim();
                txbPartner.Value = reader[4].ToString().Trim();
                txbPlanY.Value = reader[1].ToString().Trim();
                txbPlanID.Value = reader[2].ToString().Trim();
                YorN = reader[10].ToString().Trim();
            }
            if(YorN == "Y")
            {
                rdbY.Checked = true;
            }
            if(YorN == "N")
            {
                rdbY.Checked = true;
            }
            Newtable.Visible = true;
            //string sqlUpdate = "UPDATE Industry_Cooperation_data  "
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnrestar.Visible = true;
            BtnConfirm.Visible = true;
            BtnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            txbPlanID.Value = "";
            txbPlanName.Value = "";
            txbPlanY.Value = "";
            txbPartner.Value = "";
            txbExeOrgan.Value = "";
            txbPlanExeDate.Value = "";
            txbPlanEndDate.Value = "";
            txbPlanExp.Value = "";
            txbPerExp.Value = "";
            rdbN.Checked = false;
            rdbY.Checked = false;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            PK.Visible = false;
            string YorN = "";
            if(rdbY.Checked)
            {
                YorN = "Y";
            }
            if(rdbN.Checked)
            {
                YorN = "N";
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
                    if (txbPlanExeDate.Value == "" || txbPlanEndDate.Value == "")
                    {
                        System.Windows.Forms.MessageBox.Show("請輸入日期");
                        return;
                    }
                    try
                    {
                        if (Session["UporIns"] == "Up")
                        {
                            string sqlUpdate = "UPDATE Industry_Cooperation_data SET Year = @Year, PlanID = @PlanID, PlanName = @PlanName, Partner = @Partner, ExecutiveOrgan = @ExeOrgan, PlanExecutionDate = @PlanExeDate, " +
                                "PlanExecutionEndDate = @PlanExeEndDate, ProgramExpenses = @ProExp, PersonnelExpenses =@PerExp, YorNChang = @YorN  where ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@Year", txbPlanY.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanID", txbPlanID.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanName", txbPlanName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Partner", txbPartner.Value);
                            cmdUpdate.Parameters.AddWithValue("@ExeOrgan", txbExeOrgan.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanExeDate", txbPlanExeDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanExeEndDate", txbPlanEndDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@ProExp", txbPlanExp.Value);
                            cmdUpdate.Parameters.AddWithValue("@PerExp", txbPerExp.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorN", YorN);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            PageLoad();
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlUpdate = "INSERT INTO Industry_Cooperation_data VALUES (@Year, @PlanID,@PlanName, @Partner, @ExeOrgan, @PlanExeDate, " +
                                "@PlanExeEndDate, @ProExp, @PerExp, @YorN ,@UID)";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@Year", txbPlanY.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanID", txbPlanID.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanName", txbPlanName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Partner", txbPartner.Value);
                            cmdUpdate.Parameters.AddWithValue("@ExeOrgan", txbExeOrgan.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanExeDate", txbPlanExeDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@PlanExeEndDate", txbPlanEndDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@ProExp", txbPlanExp.Value);
                            cmdUpdate.Parameters.AddWithValue("@PerExp", txbPerExp.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorN", YorN);
                            cmdUpdate.Parameters.AddWithValue("@UID", "2");
                            cmdUpdate.ExecuteNonQuery();
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

        protected void btnrestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            txbPlanID.Value = "";
            txbPlanName.Value = "";
            txbPlanY.Value = "";
            txbPartner.Value = "";
            txbExeOrgan.Value = "";
            txbPlanExeDate.Value = "";
            txbPlanEndDate.Value = "";
            txbPlanExp.Value = "";
            txbPerExp.Value = "";
            rdbN.Checked = false;
            rdbY.Checked = false;
        }
    }
}