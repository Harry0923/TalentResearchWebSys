using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication1
{
    public partial class test2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {


            HttpContext.Current.Response.Buffer = true;
            //清空頁面輸出流
            HttpContext.Current.Response.Clear();
            //設置輸出流的HTTP字符集
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=研究人才研究表現指數(RPI)統計表_國科會.doc");
            //關閉控件的視圖狀態，如果仍然爲true,RenderControl將啓用頁的跟蹤功能，存儲與控件有關的跟蹤信息
            this.EnableViewState = false;
            //將要下載的頁面輸出到HtmlWriter
            System.IO.StringWriter writer = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);
            this.RenderControl(htmlWriter);
            //提取要輸出的內容
            string pageHtml = writer.ToString();
            //int startIndex = pageHtml.IndexOf("<div style=\"margin: 0 auto;\" id=\"mainContent\">");
            //int endIndex = pageHtml.LastIndexOf("</div>");
            //int lenth = endIndex - startIndex;
            //pageHtml = pageHtml.Substring(startIndex, lenth);
            //輸出
            HttpContext.Current.Response.Write(pageHtml.ToString());
            HttpContext.Current.Response.End();
        }

    }
}