using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class special_research : System.Web.UI.Page
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
            btnrestar.Visible = false;
            rowCount = 1;
            example.Rows.Clear();
            TableFirstRow();
            Newtable.Visible = false;
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Special_reaserch WHERE UID = @UID";
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
                for(int i =1; i <reader.FieldCount -1; i++)
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
            if (reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    string sqlDle = "DELETE FROM Special_reaserch WHERE ID = @ID";
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
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "姓名";
            row.Cells.Add(cell3);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "成果";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "--------------------";
            row.Cells.Add(cell2);
            row.Attributes.Add("class", "table-dark");
            example.Rows.Add(row);

        }

        protected void dataUpdate(object sender, EventArgs e)
        {
            btnrestar.Visible = true;
            btnConfirm.Visible = true;
            btnConfirm.Text = "確認修改";
            Session["UporIns"] = "Up";
            Button btnUpdate = sender as Button;
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Special_reaserch WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID",dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if(reader.Read())
            {
                PK.Value = reader[0].ToString();
                txbName.Value = reader[1].ToString();
                txbWord.Text = reader[2].ToString();
            }
            Newtable.Visible = true;
            reader.Close();
            con.Close();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible= true;
            btnrestar.Visible = true;
            btnConfirm.Text = "確認新增";
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            txbName.Value = "";
            txbWord.Text = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
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

                            string sqlUpdate = "UPDATE Special_reaserch SET ReasercherName=@Name, OtherStatment = @Other WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@Name", txbName.Value);
                            cmdUpdate.Parameters.AddWithValue("@Other", txbWord.Text);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            PageLoad();
                            System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlIns = "INSERT INTO Special_reaserch VALUES( @Name, @Other, @UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@Name", txbName.Value);
                            cmdIns.Parameters.AddWithValue("@Other", txbWord.Text);
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

        protected void btnrestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            txbName.Value = "";
            txbWord.Text = "";
        }
    }
}