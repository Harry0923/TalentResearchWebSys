using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class book : System.Web.UI.Page
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
            if (reader.Read())
            {
                if (reader[0].ToString().Trim() == "User")
                {
                    reader.Close();
                    string deleteStr = "DELETE Professional_book WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(deleteStr, con);
                    cmd.Parameters.AddWithValue("@ID", dbID);
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
            string YorN = "";
            Session["UporIns"] = "Up";
            Button btnUpdate = (Button)sender;
            //取得資料庫裡資料表的PK(ID)存到dbID變數裡，btnDelete.ID.Substring(9)為那筆資料的編號
            dbID = Session[btnUpdate.ID.Substring(9)].ToString();
            PK.Visible = false;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Professional_book WHERE ID = @ID";
            SqlCommand cmdUpdate = new SqlCommand(sqlSle, con);
            cmdUpdate.Parameters.AddWithValue("@ID", dbID);
            IDataReader reader = cmdUpdate.ExecuteReader();
            if (reader.Read())
            {
                PK.Value = reader[0].ToString().Trim();
                Name.Value = reader[1].ToString().Trim();
                AuthorName.Value = reader[2].ToString().Trim();
                YearOfPublication.Value = reader[3].ToString().Trim();
                BookTitle.Value = reader[4].ToString().Trim();
                ISBNNum.Value = reader[5].ToString().Trim();
                PublishingHouse.Value = reader[6].ToString().Trim();
                YorN = reader[7].ToString().Trim();
            }
            Newtable.Visible = true;
            if (YorN == "Y")
            {
                rdbReviewY.Checked = true;
            }
            if (YorN == "N")
            {
                rdbReviewN.Checked = true;
            }
            reader.Close();
            con.Close();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Newtable.Visible = true;
            AuthorName.Value = "";
            YearOfPublication.Value = "";
            BookTitle.Value = "";
            ISBNNum.Value = "";
            PublishingHouse.Value = "";
            rdbReviewN.Checked = false;
            rdbReviewY.Checked = false;
            Name.Value = "";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session["UporIns"] = "Ins";
            Newtable.Visible = true;
            PK.Visible = false;
            btnConfirm.Visible = true;
            btnRestar.Visible = true;
            btnConfirm.Text = "確認新增";
            AuthorName.Value = "";
            YearOfPublication.Value = "";
            BookTitle.Value = "";
            ISBNNum.Value = "";
            PublishingHouse.Value = "";
            rdbReviewY.Checked = false;
            rdbReviewN.Checked = false;
            Name.Value = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            PK.Visible = false;
            string isPreview = "";
            if (rdbReviewY.Checked)
                isPreview = "Y";
            if (rdbReviewN.Checked)
                isPreview = "N";
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
                            string sqlUpdate = "UPDATE Professional_book SET ResearcherName = @RName, AuthorName = @AuthorName, YearOfPublication = @YearOfPublication," +
                                "BookTitle = @BookTitle, ISBNNum = @ISBNNum, PublishingHouse = @PublishingHouse, YorNReview = @YorNReview WHERE ID = @ID";
                            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                            cmdUpdate.Parameters.AddWithValue("@RName", Name.Value);
                            cmdUpdate.Parameters.AddWithValue("@AuthorName", AuthorName.Value);
                            cmdUpdate.Parameters.AddWithValue("@YearOfPublication", YearOfPublication.Value);
                            cmdUpdate.Parameters.AddWithValue("@BookTitle", BookTitle.Value);
                            cmdUpdate.Parameters.AddWithValue("@ISBNNum", ISBNNum.Value);
                            cmdUpdate.Parameters.AddWithValue("@PublishingHouse", PublishingHouse.Value);
                            cmdUpdate.Parameters.AddWithValue("@YorNReview", isPreview);
                            cmdUpdate.Parameters.AddWithValue("@ID", PK.Value);
                            cmdUpdate.ExecuteNonQuery();
                            showTableData();
                            if (cmdUpdate.ExecuteNonQuery() > 0)
                                System.Windows.Forms.MessageBox.Show("資料已更新");
                            con.Close();
                            Newtable.Visible = false;
                        }
                        if (Session["UporIns"] == "Ins")
                        {
                            string sqlIns = "INSERT INTO Professional_book VALUES(@Name,@AuthorName, @YearOfPublication, @BookTitle, @ISBNNum, @PublishingHouse, @YorNReview, @UID)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@Name", Name.Value);
                            cmdIns.Parameters.AddWithValue("@AuthorName", AuthorName.Value);
                            cmdIns.Parameters.AddWithValue("@YearOfPublication", YearOfPublication.Value);
                            cmdIns.Parameters.AddWithValue("@BookTitle", BookTitle.Value);
                            cmdIns.Parameters.AddWithValue("@ISBNNum", ISBNNum.Value);
                            cmdIns.Parameters.AddWithValue("@PublishingHouse", PublishingHouse.Value);
                            cmdIns.Parameters.AddWithValue("@YorNReview", isPreview);
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
            string queryStr = "SELECT * FROM Professional_book WHERE UID = @UID";
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
                    cell.InnerText = reader[i].ToString();
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
            HtmlTableCell cell8 = new HtmlTableCell();
            cell8.InnerText = "姓名";
            row.Cells.Add(cell8);
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerText = "年度";
            row.Cells.Add(cell1);
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.InnerText = "作者";
            row.Cells.Add(cell2);
            HtmlTableCell cell3 = new HtmlTableCell();
            cell3.InnerText = "專書名稱";
            row.Cells.Add(cell3);
            HtmlTableCell cell4 = new HtmlTableCell();
            cell4.InnerText = "ISBN(國際標準書號)";
            row.Cells.Add(cell4);
            HtmlTableCell cell5 = new HtmlTableCell();
            cell5.InnerText = "出版社";
            row.Cells.Add(cell5);
            HtmlTableCell cell6 = new HtmlTableCell();
            cell6.InnerText = "是否經過審查";
            row.Cells.Add(cell6);
            HtmlTableCell cell7 = new HtmlTableCell();
            cell7.InnerText = "----";
            row.Cells.Add(cell7);
            row.Attributes.Add("class", "table-dark");
            tableData.Rows.Add(row);
        }
    }
}