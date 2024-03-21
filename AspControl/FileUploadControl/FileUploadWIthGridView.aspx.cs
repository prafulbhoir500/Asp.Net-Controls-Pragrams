using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessObject;
using System.Configuration;
using System.IO;

namespace AspControl.FileUploadControl
{
    public partial class FileUploadWIthGridView : System.Web.UI.Page
    {
        MyEntities DB = new MyEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        public void bindData()
        {
            try
            {
                var data = DB.mAttachments.Where(x => x.IsActive == 1).ToList();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFileName = (Label)e.Row.FindControl("lblFileName");
                HiddenField attachmentTypeID = (HiddenField)e.Row.FindControl("AttachmentTypeID");

                // Set the file name for the label based on the AttachmentID
                int attachmentID = Convert.ToInt32(attachmentTypeID.Value);
                mAttachment obj = DB.mAttachments.FirstOrDefault(x => x.AttachmentID == attachmentID);
                if (obj != null)
                {
                    lblFileName.Text = string.IsNullOrEmpty(obj.TabName) ? "No File Available" : obj.TabName;
                }
            }
        }
        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            // Get the reference to the AsyncFileUpload control
            AjaxControlToolkit.AsyncFileUpload asyncFileUpload = (AjaxControlToolkit.AsyncFileUpload)sender;

            // Find the corresponding Label in the same Repeater item
            Label lblFileName = (Label)asyncFileUpload.Parent.FindControl("lblFileName");

            // Display the file name
            lblFileName.Text = e.FileName;

            //RepeaterItem item = (RepeaterItem)asyncFileUpload.Parent;
            GridViewRow item = (GridViewRow)asyncFileUpload.NamingContainer;

            //string attachmentName = ((Label)item.FindControl("lblAttachmentName")).Text;

            HiddenField attachmentTypeIdHiddenField = (HiddenField)item.FindControl("AttachmentTypeID");
            int attachmentTypeId = Convert.ToInt32(attachmentTypeIdHiddenField.Value);

            // Check if a file was uploaded
            if (asyncFileUpload.HasFile)
            {
                // Get the uploaded file
                HttpPostedFile postedFile = asyncFileUpload.PostedFile;

                // Specify the path where you want to save the file
                //string savePath = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]) + Path.GetFileName(postedFile.FileName);
                string uploadDirectory = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                string fileName = attachmentTypeId + Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(uploadDirectory, fileName);

                // Save the file to the specified path
                //postedFile.SaveAs(savePath);
                postedFile.SaveAs(filePath);

                mAttachment obj = DB.mAttachments.FirstOrDefault(x => x.AttachmentID == attachmentTypeId);
                if (obj != null)
                {

                    obj.TabName = fileName;
                    DB.SaveChanges();
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('File Uploaded...')", true);
                }
                try
                {
                    //UpdatePanel1.Update();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "BindRepeater", "BindRepeater();", true);
                    //bindData();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }

    }
}