using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using AjaxControlToolkit;

namespace AspControl.FileUploadDemo
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "File Control";
            }

        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            try
            {
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                AsyncFileUpload1.SaveAs(Path.Combine(filePath,AsyncFileUpload1.FileName));

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alertmsg", "alert('file upload')", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (FileUpload1.HasFile)
                {

                    FileUpload1.SaveAs(Path.Combine(filePath, FileUpload1.FileName));
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alertmsg", "alert('file upload')", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}