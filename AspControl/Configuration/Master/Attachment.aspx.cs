using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;

namespace AspControl.Configuration.Master
{
    public partial class Attachment : System.Web.UI.Page
    {

        MyEntities DB = new MyEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                mAttachment newAttachment = new mAttachment();
                newAttachment.TabName=txtTabName.Text.Trim();
                newAttachment.AttachmentName = txtAttachmentName.Text.Trim();
                newAttachment.IsActive = Convert.ToByte(chkIsActive.Checked);
                newAttachment.CreatedBy = 1;
                newAttachment.CreatedOn=DateTime.Now;

                DB.mAttachments.Add(newAttachment);
                DB.SaveChanges();
            }
            catch(Exception ex)
            { 
            }
        }
    }
}