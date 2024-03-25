using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessObject;

namespace AspControl.FileUploadControl
{
    public partial class AjaxFileUpload : System.Web.UI.Page
    {
        MyEntities DB = new MyEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                LoadDropdownOptions();
            }
        }

        public void bindData()
        {
            try
            {
                var data = DB.mAttachments.Where(x => x.IsActive == 1).ToList();
                rptAttachment.DataSource = data;
                rptAttachment.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        [System.Web.Services.WebMethod]
        public static string BindRepeaterOnUpload()
        {
            try
            {

                return "Success"; // Return a success message
            }
            catch (Exception ex)
            {
                return ex.Message; // Return the error message in case of failure
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
                    UpdatePanel1.Update();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "BindRepeater", "BindRepeater();", true);
                    //bindData();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }

        #region selected index change
        [WebMethod]
        public static bool CheckCondition(string selectedValue)
        {
            bool condition = false;

            try
            {
                // Establish connection to the database
                //using (SqlConnection connection = new SqlConnection("YourConnectionString"))
                //{
                //    // Open the connection
                //    connection.Open();

                //    // Construct your SQL query based on the selected value
                //    string query = "SELECT YourConditionColumn FROM YourTable WHERE YourDropdownColumn = @SelectedValue";

                //    // Create a command
                //    using (SqlCommand command = new SqlCommand(query, connection))
                //    {
                //        // Add parameters to prevent SQL injection
                //        command.Parameters.AddWithValue("@SelectedValue", selectedValue);

                //        // Execute the query
                //        object result = command.ExecuteScalar();

                //        // Check the condition (you might need to adjust this based on your database schema)
                //        if (result != null && result != DBNull.Value)
                //        {
                //            condition = Convert.ToBoolean(result);
                //        }
                //    }
                //}
                object result;
                if (@selectedValue == "4")
                {

                    result = 1;
                }
                else
                {
                    result = 0;
                }
                condition = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
            }

            return condition;
        }

        // Method to load dropdown options
        private void LoadDropdownOptions()
        {
            // Populate dropdown from database, etc.
            // Example:
            ddl.Items.Add(new ListItem("Select", "0"));
            ddl.Items.Add(new ListItem("Option 1", "1"));
            ddl.Items.Add(new ListItem("Option 2", "2"));
            ddl.Items.Add(new ListItem("Option 3", "3"));
            ddl.Items.Add(new ListItem("Other", "4"));
        }
        #endregion
    }
}