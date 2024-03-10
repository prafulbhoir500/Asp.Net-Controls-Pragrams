using BusinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AspControl.FileUpload
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

                // Check if the FileUpload control is not null and has a file
                if (fileUpload != null && fileUpload.PostedFile != null && fileUpload.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                        string uploadDirectory = Server.MapPath("~/Uploads/");
                        string filePath = Path.Combine(uploadDirectory, fileName);

                        // Save the file to the server
                        fileUpload.PostedFile.SaveAs(filePath);

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

    }
}