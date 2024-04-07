using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspControl.RepeaterControl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            List<Expense> expenses = new List<Expense>
            {
                new Expense { Name = "Expense 1",PerPersonRate=3500, PerPerson = 0 },
                new Expense { Name = "Expense 2",PerPersonRate=4500, PerPerson = 0 },
                new Expense { Name = "Expense 3",PerPersonRate=5500, PerPerson = 0 }
            };

            rptExpenses.DataSource = expenses;
            rptExpenses.DataBind();
        }

        protected void rptExpenses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Expense expense = e.Item.DataItem as Expense;
                TextBox txtPerPerson = e.Item.FindControl("txtPerPerson") as TextBox;
                TextBox txtPerPersonRate = e.Item.FindControl("txtPerPersonRate") as TextBox;
                TextBox txtTotal = e.Item.FindControl("txtTotal") as TextBox;

                if (expense != null && txtPerPerson != null && txtTotal != null)
                {
                    txtPerPerson.Text = expense.PerPerson.ToString();
                    //txtTotal.Text = (expense.PerPerson * 1.0).ToString(); 
                    txtPerPersonRate.Text = expense.PerPersonRate.ToString();// Initial calculation
                    txtTotal.Text = CalculateTotal(expense.PerPerson, expense.PerPersonRate).ToString();
                }
            }
        }

        //protected void txtPerPerson_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtPerPerson = sender as TextBox;
        //    RepeaterItem item = txtPerPerson.NamingContainer as RepeaterItem;
        //    TextBox txtTotal = item.FindControl("txtTotal") as TextBox;

        //    if (txtTotal != null && double.TryParse(txtPerPerson.Text, out double perPerson))
        //    {
        //        txtTotal.Text = (perPerson * 12).ToString(); // Recalculate total
        //        CalculateColumnTotal();
        //    }
        //}

        protected void txtPerPerson_TextChanged(object sender, EventArgs e)
        {
            RecalculateTotals();
        }

        protected void txtPerPersonRate_TextChanged(object sender, EventArgs e)
        {
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            foreach (RepeaterItem item in rptExpenses.Items)
            {
                TextBox txtPerPerson = item.FindControl("txtPerPerson") as TextBox;
                TextBox txtPerPersonRate = item.FindControl("txtPerPersonRate") as TextBox;
                TextBox txtTotal = item.FindControl("txtTotal") as TextBox;

                if (txtPerPerson != null && txtPerPersonRate != null && txtTotal != null)
                {
                    double perPerson = 0;
                    double perPersonRate = 0;

                    if (double.TryParse(txtPerPerson.Text, out perPerson) && double.TryParse(txtPerPersonRate.Text, out perPersonRate))
                    {
                        txtTotal.Text = CalculateTotal(perPerson, perPersonRate).ToString();
                    }
                }
            }
            CalculateColumnTotals(); // Recalculate column totals after individual totals are updated
        }


        private void CalculateColumnTotals()
        {
            double columnTotal = 0;
            double columnTotalPer = 0;

            foreach (RepeaterItem item in rptExpenses.Items)
            {
                TextBox txtTotal = item.FindControl("txtTotal") as TextBox;
                TextBox txtTotalper = item.FindControl("txtPerPerson") as TextBox;
                if (txtTotal != null && double.TryParse(txtTotal.Text, out double total))
                {
                    columnTotal += total;
                    
                }

                if (txtTotalper != null && double.TryParse(txtTotalper.Text, out double total1))
                {
                 
                    columnTotalPer += total1;
                }
            }

            // Find lblColumnTotal control in the repeater's footer
            Label lblColumnTotal = rptExpenses.Controls[rptExpenses.Controls.Count - 1].FindControl("lblColumnTotal") as Label;
            Label lblColumnTotalPer = rptExpenses.Controls[rptExpenses.Controls.Count - 1].FindControl("lblColumnTotalPer") as Label;

            if (lblColumnTotal != null)
            {
                lblColumnTotal.Text = columnTotal.ToString();
                lblColumnTotalPer.Text = columnTotalPer.ToString();
            }
            else
            {
                // Handle error if lblColumnTotal is not found
                // Example: throw new Exception("lblColumnTotal control not found!");
            }
        }


        //private void CalculateColumnTotal()
        //{
        //    double columnTotal = 0;

        //    foreach (RepeaterItem item in rptExpenses.Items)
        //    {
        //        TextBox txtTotal = item.FindControl("txtTotal") as TextBox;
        //        if (txtTotal != null && double.TryParse(txtTotal.Text, out double total))
        //        {
        //            columnTotal += total;
        //        }
        //    }

        //    // Find lblColumnTotal control again if necessary (for safety)
        //    //lblColumnTotal = rptExpenses.Controls[0].Controls[rptExpenses.Controls[0].Controls.Count - 1].FindControl("lblColumnTotal") as Label;

        //    //if (lblColumnTotal != null)
        //    //{
        //    //    lblColumnTotal.Text = columnTotal.ToString();
        //    //}
        //    //else
        //    //{
        //    //    // Handle error if lblColumnTotal is not found
        //    //    // Example: throw new Exception("lblColumnTotal control not found!");
        //    //}
        //}

        private double CalculateTotal(double perPerson, double perPersonRate)
        {
            return perPerson * perPersonRate;
        }
        public class Expense
        {
            public string Name { get; set; }
            public double PerPerson { get; set; }
            public double PerPersonRate { get; set; }
        }
    }
}