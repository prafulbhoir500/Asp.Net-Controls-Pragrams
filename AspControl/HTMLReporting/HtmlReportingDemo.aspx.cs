using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace AspControl.HTMLReporting
{
    public partial class HtmlReportingDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            
                // Sample data (you can replace this with your actual data source)
                var employees = new[]
                {
                new { Name = "John Doe", Age = 30, Department = "IT" },
                new { Name = "Jane Smith", Age = 35, Department = "HR" },
                new { Name = "Bob Johnson", Age = 40, Department = "Finance" }
            };

                // Generate table rows
                StringBuilder tableRows = new StringBuilder();
                foreach (var employee in employees)
                {
                    tableRows.Append("<tr>");
                    tableRows.Append($"<td>{employee.Name}</td>");
                    tableRows.Append($"<td>{employee.Age}</td>");
                    tableRows.Append($"<td>{employee.Department}</td>");
                    tableRows.Append("</tr>");
                }

                // Read HTML template file
                string htmlContent = File.ReadAllText(Server.MapPath("~/HTMLReporting/Template.html"));

                // Replace table rows placeholder with generated table rows
                htmlContent = htmlContent.Replace("[TableRows]", tableRows.ToString());

                // Convert HTML to PDF
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument pdfDocument = converter.ConvertHtmlString(htmlContent);

                // Save PDF to memory stream
                MemoryStream outputStream = new MemoryStream();
                pdfDocument.Save(outputStream);
                pdfDocument.Close();

                // Prompt the user to download the PDF
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=EmployeeInformation.pdf");
                Response.BinaryWrite(outputStream.ToArray());
                Response.End();
            
        }

        protected void btnViewReportbasic_Click(object sender, EventArgs e)
        {
            // Set dynamic values
            string name = "Praful Bhoir";
            int age = 30;

            // Read HTML template file
            string htmlContent = File.ReadAllText(Server.MapPath("~/HTMLReporting/TemplateBasic.html"));

            // Replace placeholders with actual values
            htmlContent = htmlContent.Replace("[Name]", name);
            htmlContent = htmlContent.Replace("[Age]", age.ToString());

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument pdfDocument = converter.ConvertHtmlString(htmlContent);

            // Save PDF to memory stream
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream);
            pdfDocument.Close();

            // Prompt the user to download the PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=MyDocument.pdf");
            Response.BinaryWrite(outputStream.ToArray());
            Response.End();
        }

        protected void btnViewReportWithPageSize_Click(object sender, EventArgs e)
        {
            // Sample data (you can replace this with your actual data source)
            var employees = new[]
            {
            new { Name = "John Doe", Age = 30, Department = "IT" },
            new { Name = "Jane Smith", Age = 35, Department = "HR" },
            new { Name = "Bob Johnson", Age = 40, Department = "Finance" }
        };

            // Generate table rows
            StringBuilder tableRows = new StringBuilder();
            foreach (var employee in employees)
            {
                tableRows.Append("<tr>");
                tableRows.Append($"<td>{employee.Name}</td>");
                tableRows.Append($"<td>{employee.Age}</td>");
                tableRows.Append($"<td>{employee.Department}</td>");
                tableRows.Append("</tr>");
            }

            // Read HTML template file
            string htmlContent = File.ReadAllText(Server.MapPath("~/Template.html"));

            // Replace table rows placeholder with generated table rows
            htmlContent = htmlContent.Replace("[TableRows]", tableRows.ToString());

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();

            // Create a new PDF document
            PdfDocument pdfDocument = converter.ConvertHtmlString(htmlContent);

            // Set the page size (in points)
            //pdfDocument.Options.PdfPageSize = PdfPageSize.A4;
            //pdfDocument.Pages[0].PageSize = PdfPageSize.A4;
            converter.Options.PdfPageSize = PdfPageSize.A4;

            // Save PDF to memory stream
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream);
            pdfDocument.Close();

            // Prompt the user to download the PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=EmployeeInformation.pdf");
            Response.BinaryWrite(outputStream.ToArray());
            Response.End();
        }

        protected void btnViewReportInvoice_Click(object sender, EventArgs e)
        {
            // Read HTML template file
            string htmlContent = File.ReadAllText(Server.MapPath("~/HTMLReporting/TemplateInvoice.html"));

            // Sample dynamic values (replace with your actual data)
            string clientName = "Praful Bhoir";
            DateTime currentDate = DateTime.Now;
            string productDescription1 = "Product A";
            int quantity1 = 2;
            decimal unitPrice1 = 50.00m;
            decimal total1 = quantity1 * unitPrice1;
            string productDescription2 = "Product B";
            int quantity2 = 1;
            decimal unitPrice2 = 75.00m;
            decimal total2 = quantity2 * unitPrice2;
            decimal grandTotal = total1 + total2;

            // Replace placeholders in the HTML content with actual values
            htmlContent = htmlContent.Replace("[ClientName]", clientName);
            htmlContent = htmlContent.Replace("[CurrentDate]", currentDate.ToString("MMMM dd, yyyy"));
            htmlContent = htmlContent.Replace("[ProductDescription1]", productDescription1);
            htmlContent = htmlContent.Replace("[Quantity1]", quantity1.ToString());
            htmlContent = htmlContent.Replace("[UnitPrice1]", unitPrice1.ToString("C"));
            htmlContent = htmlContent.Replace("[Total1]", total1.ToString("C"));
            htmlContent = htmlContent.Replace("[ProductDescription2]", productDescription2);
            htmlContent = htmlContent.Replace("[Quantity2]", quantity2.ToString());
            htmlContent = htmlContent.Replace("[UnitPrice2]", unitPrice2.ToString("C"));
            htmlContent = htmlContent.Replace("[Total2]", total2.ToString("C"));
            htmlContent = htmlContent.Replace("[GrandTotal]", grandTotal.ToString("C"));

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();

            // Convert HTML string to PDF document
            PdfDocument pdfDocument = converter.ConvertHtmlString(htmlContent);

            // Save PDF to disk
            //pdfDocument.Save(Server.MapPath("~/Quotation.pdf"));

            // Save PDF to memory stream
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream);
            pdfDocument.Close();

            // Close the PDF document
            pdfDocument.Close();

            // Redirect to the generated PDF file
            //Response.Redirect("~/Quotation.pdf");
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Invoice.pdf");
            Response.BinaryWrite(outputStream.ToArray());
            Response.End();
        }
    }
}