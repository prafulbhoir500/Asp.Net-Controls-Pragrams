using AjaxControlToolkit;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspControl.FileUploadControl
{
    public partial class FileUploadInRepeaterControl : System.Web.UI.Page
    {
        MyEntities DB = new MyEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

         private void bindData()
        {
            try
            {
                var data = DB.mAttachments.Where(x => x.IsActive == 1).ToList();
                rptAttachment.DataSource = data;
                rptAttachment.DataBind();

                rptAttachment1.DataSource = data;
                rptAttachment1.DataBind();

                rptAttachment2.DataSource = data;
                rptAttachment2.DataBind();

            }
            catch
            {
            }
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptAttachment1.Items)
            {
                // Find the FileUpload control within the repeater item
                FileUpload fileUpload = (FileUpload)item.FindControl("FileUpload1");
                HiddenField ID = (HiddenField)item.FindControl("AttachmentTypeID");

                // Check if the FileUpload control is not null and has a file
                if (fileUpload != null && fileUpload.HasFile)
                {
                    try
                    {
                        string uploadDirectory = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);
                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }
                        string fileName = ID.Value+Path.GetFileName(fileUpload.FileName);
                        string filePath = Path.Combine(uploadDirectory, fileName);

                        // Save the file to the server
                        fileUpload.SaveAs(filePath);

                        // Optionally, you can store the file path in a database or perform other actions
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception appropriately, such as logging or displaying an error message
                        Response.Write("Error: " + ex.Message);
                    }
                }
                else
                {
                    Response.Write("Please select a file to upload.");
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

            RepeaterItem item = (RepeaterItem)asyncFileUpload.Parent;

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

                string fileName = attachmentTypeId+Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(uploadDirectory, fileName);

                // Save the file to the specified path
                //postedFile.SaveAs(savePath);
                postedFile.SaveAs(filePath);

                mAttachment obj = DB.mAttachments.FirstOrDefault(x => x.AttachmentID == attachmentTypeId);
                if (obj != null)
                {

                    obj.TabName = fileName;
                    DB.SaveChanges();
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('File Uploaded...')", true);
                }
            }
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            // Get the reference to the Button control that triggered the event
            Button btnUpload = (Button)sender;

            // Find the RepeaterItem container
            RepeaterItem item = (RepeaterItem)btnUpload.NamingContainer;

            // Find the FileUpload control within the RepeaterItem
            FileUpload fileUpload = (FileUpload)item.FindControl("FileUpload1");
            HiddenField ID = (HiddenField)item.FindControl("AttachmentTypeID");


            // Check if a file was uploaded
            if (fileUpload.HasFile)
            {
                // Specify the path where you want to save the file
                //string savePath = Server.MapPath("~/Uploads/") + Path.GetFileName(fileUpload.FileName);
                string uploadDirectory = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                string fileName = ID.Value+Path.GetFileName(fileUpload.FileName);
                string savePath = Path.Combine(uploadDirectory, fileName);

                // Save the file to the specified path
                fileUpload.SaveAs(savePath);
            }
        }


        //protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        //{
        //    AsyncFileUpload asyncFileUpload = (AsyncFileUpload)sender;
        //    RepeaterItem item = (RepeaterItem)asyncFileUpload.Parent;
        //    string attachmentName = ((Label)item.FindControl("lblAttachmentName")).Text;

        //    if (asyncFileUpload.HasFile && asyncFileUpload.PostedFile.ContentLength > 0)
        //    {
        //        // Save the uploaded file
        //        string fileName = Path.GetFileName(asyncFileUpload.FileName);
        //        string filePath = Server.MapPath("~/uploads/") + fileName;
        //        asyncFileUpload.SaveAs(filePath);

        //        // Here you can save the file path to the database if needed
        //        // Example: UpdateAttachmentFilePath(attachmentName, filePath);
        //    }
        //    else
        //    {
        //        // Invalid file
        //        // Handle the error or provide feedback to the user
        //    }
        //}

        //protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        //{
        //    AsyncFileUpload asyncFileUpload = (AsyncFileUpload)sender;
        //    RepeaterItem item = (RepeaterItem)asyncFileUpload.Parent;
        //    string attachmentName = ((Label)item.FindControl("lblAttachmentName")).Text;

        //    // Save the uploaded file
        //    if (asyncFileUpload.HasFile)
        //    {
        //        string fileName = Path.GetFileName(asyncFileUpload.FileName);
        //        string filePath = Server.MapPath(ConfigurationManager.AppSettings["StorageFilePath"]);
        //        asyncFileUpload.SaveAs(filePath);

        //        // Here you can save the file path to the database if needed
        //        // Example: UpdateAttachmentFilePath(attachmentName, filePath);
        //    }
        //}
    }
}