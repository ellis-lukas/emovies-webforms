using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website
{
    public partial class Confirmation : Page
    {
        private List<OrderLine> OrderLines;
        private Customer CustomerInfo;
        private DisplayCustomer DisplayCustomerInfo;
        private decimal Total;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                SetupConfirmationPageOnFirstLoad();
            }
        }

        private void SetupConfirmationPageOnFirstLoad()
        {
            SetPageCultureToBritish();
            SetPageMemberVariables();
            PopulatePageWithOrderData();
        }

        private void SetPageCultureToBritish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        private void SetPageMemberVariables()
        {
            SetPageMemberBusinessVariables();
            SetPageMemberDisplayVariables();
        }

        private void SetPageMemberBusinessVariables()
        {
            CustomerInfo = (Customer)Session["CustomerInfo"];
            OrderLines = (List<OrderLine>)Session["MoviesOrdered"];
        }

        private void SetPageMemberDisplayVariables()
        {
            DisplayCustomerInfo = new DisplayCustomerMapper().MapFromCustomer(CustomerInfo);
            Total = OrderLines.Total();
        }

        private void PopulatePageWithOrderData()
        {
            LoadCustomerInformationIntoPage(DisplayCustomerInfo);
            LoadOrderTableIntoPage();
        }

        private void LoadCustomerInformationIntoPage(DisplayCustomer displayCustomer)
        {
            Name.Text = displayCustomer.Name;
            Email.Text = displayCustomer.Email;
            CardNumber.Text = displayCustomer.ProtectedCardNumber;
            CardType.Text = displayCustomer.CardType;
            FuturePromotions.Text = (displayCustomer.FuturePromotions == true) ? "Yes" : "No";
        }

        private void LoadOrderTableIntoPage()
        {
            LoadDisplayOrdersIntoOrderTable();
            LoadTotalIntoOrderTable();
        }

        private void LoadDisplayOrdersIntoOrderTable()
        {
            RepeaterConfirmation.DataSource = OrderLines;
            RepeaterConfirmation.DataBind();
        }

        private void LoadTotalIntoOrderTable()
        {
            TotalValue.Text = string.Format("{0:c}", Total);
        }
    }
}