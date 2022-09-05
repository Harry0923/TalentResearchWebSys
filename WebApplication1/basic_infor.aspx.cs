using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : Page
    {
        string conStr = "Data Source=DESKTOP-API2RQR\\MSSQLSERVER_2019;Initial Catalog=Talent-research;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            PageLoad();
        }
        private void PageLoad()
        {
            string RY = "";
            string Pro = "";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sqlSle = "SELECT * FROM Basic_Empolyee WHERE UID = @UID";
            SqlCommand cmd = new SqlCommand(sqlSle, con);
            cmd.Parameters.AddWithValue("@UID", "2");
            IDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                txbID.Value = reader[1].ToString().Trim();
                txbCname.Value = reader[2].ToString().Trim();
                txbEname.Value = reader[3].ToString().Trim();
                txbESname.Value = reader[4].ToString().Trim();
                txbCountry.Value = reader[5].ToString().Trim();
                txbBorn.Value = reader[6].ToString().Substring(0,9).Trim();
                txbAddr.Value = reader[7].ToString().Trim();
                txbPb.Value = reader[8].ToString().Trim();
                txbPr.Value = reader[9].ToString().Trim();
                txbFax.Value = reader[10].ToString().Trim();
                txbEUnit.Value = reader[11].ToString().Trim();
                txbCUint.Value = reader[12].ToString().Trim();
                txbJobTitle.Value = reader[13].ToString().Trim();
                txbArri.Value = reader[14].ToString().Substring(0,9).Trim();
                RY = reader[15].ToString().Trim();
                txbEmail.Value = reader[16].ToString().Trim();
                Pro = reader[17].ToString().Trim();
            }
            if (RY == "5年以上")
            {
                rdb5.Checked = true;
            }
            if (RY == "4年")
            {
                rdb4.Checked = true;
            }
            if (RY == "3年")
            {
                rdb3.Checked = true;
            }
            if (Pro == "專任")
            {
                rdbPro.Checked = true;
            }
            if (Pro == "合(特)聘")
            {
                rdbSpe.Checked = true;

            }
            if (Pro == "兼任")
            {
                rdbBoth.Checked = true;
            }
            reader.Close();
            con.Close();
            
        }

        protected void btnFix_Click(object sender, EventArgs e)
        {
            
            string NowTime = DateTime.Now.ToString();
            string RY = "";
            string FullTime = "";
            if (rdb5.Checked)
                RY = "5年以上";
            if (rdb4.Checked)
                RY = "4年";
            if (rdb3.Checked)
                RY = "3年";
            if (rbd2.Checked)
                RY = "2年";
            if (rdbPro.Checked)
                FullTime = "專任";
            if (rdbSpe.Checked)
                FullTime = "合(特)聘";
            if (rdbBoth.Checked)
                FullTime = "兼任";
            if (rdbOth.Checked)
                FullTime = txbOth.Value;
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
                        string sqlUpdate = "UPDATE Basic_Empolyee SET ID = @ID, Cname = @Cname, Ename = @Ename, SEname = @SEname, Country = @Country," +
              "BornDate = @Born, Addr = @Addr, PhonePb = @Pb, PhonePr = @Pr, Faxnum = @Fax, SecondaryUnitE = @EUnit, SecondaryUnitC = @CUnit," +
              "JobTitle = @JobTitle, ArrivalDate = @Arri, ResearchY = @RY, Email = @Email, FullTime = @FullTime, DataUpdateDate = @DUP WHERE UID = @UID";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                        cmdUpdate.Parameters.AddWithValue("@ID", txbID.Value);
                        cmdUpdate.Parameters.AddWithValue("@Cname", txbCname.Value);
                        cmdUpdate.Parameters.AddWithValue("@Ename", txbEname.Value);
                        cmdUpdate.Parameters.AddWithValue("@SEname", txbESname.Value);
                        cmdUpdate.Parameters.AddWithValue("@Country", txbCountry.Value);
                        cmdUpdate.Parameters.AddWithValue("@Born", txbBorn.Value);
                        cmdUpdate.Parameters.AddWithValue("@Addr", txbAddr.Value);
                        cmdUpdate.Parameters.AddWithValue("@Pb", txbPb.Value);
                        cmdUpdate.Parameters.AddWithValue("@Pr", txbPr.Value);
                        cmdUpdate.Parameters.AddWithValue("@Fax", txbFax.Value);
                        cmdUpdate.Parameters.AddWithValue("@EUnit", txbEUnit.Value);
                        cmdUpdate.Parameters.AddWithValue("@CUnit", txbCUint.Value);
                        cmdUpdate.Parameters.AddWithValue("@JobTitle", txbJobTitle.Value);
                        cmdUpdate.Parameters.AddWithValue("@Arri", txbArri.Value);
                        cmdUpdate.Parameters.AddWithValue("@RY", RY);
                        cmdUpdate.Parameters.AddWithValue("@Email", txbEmail.Value);
                        cmdUpdate.Parameters.AddWithValue("@FullTime", FullTime);
                        cmdUpdate.Parameters.AddWithValue("@DUP", NowTime.Substring(0, 9));
                        cmdUpdate.Parameters.AddWithValue("@UID", "2");
                        cmdUpdate.ExecuteNonQuery();
                        System.Windows.Forms.MessageBox.Show("基本資料已修改");
                        PageLoad();
                        con.Close();
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
    }
}