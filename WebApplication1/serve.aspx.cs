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
    public partial class serve : System.Web.UI.Page
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
            btnConfirm.Visible = false;
            rowCount = 1;
            example.Rows.Clear();
            TableFirstRow();
            Newtable.Visible = false;
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Server_data WHERE UID = @UID ";
            SqlCommand cmdSle = new SqlCommand(sqlSle, con);
            cmdSle.Parameters.AddWithValue("UID", "2");
            IDataReader reader = cmdSle.ExecuteReader();
            while (reader.Read())
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellNum = new HtmlTableCell();
                cellNum.InnerText = rowCount.ToString();
                row.Cells.Add(cellNum);
                Session[rowCount.ToString()] = reader[0].ToString();
                for(int i = 1; i < reader.FieldCount -1; i++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if(i == 6)
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
                    string sqlDle = "DELETE FROM Server_data WHERE ID = @ID";
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
            
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認修改";
            btnrestar.Visible = true;
            string OorI = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Server_data WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if(reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                txbYear.Value = reader[2].ToString().Trim();
                OorI = reader[1].ToString().Trim();
                txbType.Value = reader[3].ToString().Trim();
                txbName.Value = reader[5].ToString().Trim();
                txbJobTitle.Value = reader[4].ToString().Trim();
                txbDate.Value = reader[6].ToString().Substring(0, 9);
            }
            if(OorI == "院內")
            {
                rdbI.Checked = true;
            }
            if(OorI == "院外")
            {
                rdbO.Checked = true;
            }
            Newtable.Visible = true;
            reader.Close();
            con.Close();
        }

        private void TableFirstRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell0 = new HtmlTableCell();
            cell0.InnerText = "編號:";
            row.Cells.Add(cell0);
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "院內外:";
            row.Cells.Add(cell8);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "年度:";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "服務類別:";
            row.Cells.Add(cell2);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "職稱:";
            row.Cells.Add(cell5);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "服務單位、團體或活動名稱:";
            row.Cells.Add(cell4);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "日期:";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "------------";
            row.Cells.Add(cell7);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string OorI = "";
            if (rdbO.Checked)
            {
                OorI = "院外";
            }
            if (rdbI.Checked)
            {
                OorI = "院內";
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
                    if (Session["UporIns"] == "Up")
                    {
                        string sqlUpdate = "UPDATE Server_data SET InOutHos = @Hos, Year = @Year, ServiceType = @Type, JobTitle = @Job, ServiceName = @Name, SeminarDate = @Date WHERE ID = @ID";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                        cmdUpdate.Parameters.AddWithValue("@Hos", OorI);
                        cmdUpdate.Parameters.AddWithValue("@Year", txbYear.Value);
                        cmdUpdate.Parameters.AddWithValue("Type", txbType.Value);
                        cmdUpdate.Parameters.AddWithValue("@Job", txbJobTitle.Value);
                        cmdUpdate.Parameters.AddWithValue("@Name", txbName.Value);
                        cmdUpdate.Parameters.AddWithValue("@Date", txbDate.Value);
                        cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                        cmdUpdate.ExecuteNonQuery();
                        PageLoad();
                        System.Windows.Forms.MessageBox.Show("資料已更新");
                        con.Close();
                        Newtable.Visible = false;
                    }
                    if (Session["UporIns"] == "Ins")
                    {
                        string sqlIns = "INSERT INTO Server_data VALUES(@Hos,@Year, @Type, @Job,@Name, @Date,@UID )";
                        SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                        cmdIns.Parameters.AddWithValue("@Hos", OorI);
                        cmdIns.Parameters.AddWithValue("@Year", txbYear.Value);
                        cmdIns.Parameters.AddWithValue("@Type", txbType.Value);
                        cmdIns.Parameters.AddWithValue("@Job", txbJobTitle.Value);
                        cmdIns.Parameters.AddWithValue("@Name", txbName.Value);
                        cmdIns.Parameters.AddWithValue("@Date", txbDate.Value);
                        cmdIns.Parameters.AddWithValue("@UID", "2");
                        cmdIns.ExecuteNonQuery();
                        System.Windows.Forms.MessageBox.Show("資料已新增");
                        PageLoad();
                        con.Close();
                        Newtable.Visible = false;
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("您的權限不足");
            }

        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnrestar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            txbDate.Value = "";
            rdbI.Checked = false;
            rdbO.Checked = false;
            txbJobTitle.Value = "";
            txbName.Value = "";
            txbType.Value = "";
            txbYear.Value = "";
            
        }
        protected void btnrestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            rdbI.Checked = false;
            rdbO.Checked = false;
            txbName.Value = "";
            txbType.Value = "";
            txbDate.Value = "";
            txbYear.Value = "";

        }
    }
}