using AjaxControlToolkit;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AspControl.FileUploadControl
{
    public partial class FormWithFileUpload : System.Web.UI.Page
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
                var data = (from attachmentType in DB.mAttachmentTypes
                            join documents in DB.UserDocuments
                            on attachmentType.AttachmentTypeID equals documents.AttachmentTypeID into gj
                            from subAttachment in gj.DefaultIfEmpty()
                            select new
                            {
                                AttachmentTypeID = attachmentType.AttachmentTypeID,
                                UserType = attachmentType.UserType,
                                AttachmentID = attachmentType.AttachmentID,
                                AttachmentName = attachmentType.mAttachment.AttachmentName,
                                TabName = attachmentType.TabName,
                                IsActive = attachmentType.IsActive,
                                AttachmentPath = subAttachment.FilePath,
                               
                                // Include additional fields from the Attachment entity if needed
                                // AttachmentName = subAttachment.Name,
                                // ...
                            }).ToList();
                rptAttachment.DataSource = data;
                rptAttachment.DataBind();

                
            }
            catch
            {
            }
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            // Get the reference to the AsyncFileUpload control
            AjaxControlToolkit.AsyncFileUpload asyncFileUpload = (AjaxControlToolkit.AsyncFileUpload)sender;


            RepeaterItem item = (RepeaterItem)asyncFileUpload.Parent;

            LinkButton btnFile = (LinkButton)item.FindControl("btnFile");

            // Set the visibility of the "View" button to true
            btnFile.Visible = true;

            //string attachmentName = ((Label)item.FindControl("lblAttachmentName")).Text;

            HiddenField attachmentTypeIdHiddenField = (HiddenField)item.FindControl("AttachmentTypeID");
            string attachmentTypeId = attachmentTypeIdHiddenField.Value;

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

                UserDocument newDocument = new UserDocument();

                newDocument.FilePath = filePath;
                newDocument.AttachmentTypeID = Convert.ToInt32(attachmentTypeId);
                newDocument.IsActive = 1;
                newDocument.CreatedBy = 1;
                newDocument.UploadDate =DateTime.Now;
                newDocument.DocumentName = "";
                newDocument.CreatedOn=DateTime.Now;
                DB.UserDocuments.Add(newDocument);
                DB.SaveChanges();
            }
        }
    }
}