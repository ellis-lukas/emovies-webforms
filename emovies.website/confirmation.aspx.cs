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
        private List<OrderLine> Orders;
        protected List<DisplayOrderLine> DisplayOrders;
        private Customer CustomerInfo;
        private DisplayCustomer DisplayCustomerInfo;
        private readonly MovieRepository movieRepository = MovieRepository.GetInstance();
        private decimal Total;

        protected List<Movie> CurrentMovies
        {
            get
            { return movieRepository.GetMovies(); }
        }

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

        private static void SetPageCultureToBritish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        public void SetPageMemberVariables()
        {
            SetPageMemberBusinessVariables();
            SetPageMemberDisplayVariables();
        }

        public void SetPageMemberBusinessVariables()
        {
            CustomerInfo = (Customer)Session["CustomerInfo"];
            Orders = (List<OrderLine>)Session["MoviesOrdered"];
        }

        public void SetPageMemberDisplayVariables()
        {
            DisplayOrders = new ListOfDisplayOrderLineMapper().MapFromListOfOrderLine(Orders);
            DisplayCustomerInfo = new DisplayCustomerMapper().MapFromCustomer(CustomerInfo);
            Total = new TotalMapper().MapTotal(DisplayOrders);
        }

        public void PopulatePageWithOrderData()
        {
            LoadCustomerInformationIntoPage();
            LoadOrderTableIntoPage();
        }

        public void LoadCustomerInformationIntoPage()
        {
            CustomerName.Text = DisplayCustomerInfo.Name;
            CustomerEmail.Text = DisplayCustomerInfo.Email;
            CustomerCardNumber.Text = DisplayCustomerInfo.ProtectedCardNumber;
            CustomerCardType.Text = DisplayCustomerInfo.CardType;
            CustomerFuturePromotions.Text = (CustomerInfo.FuturePromotions == true) ? "Yes" : "No";
        }

        public void LoadOrderTableIntoPage()
        {
            LoadDisplayOrdersIntoOrderTable();
            LoadTotalIntoOrderTable();
        }

        public void LoadDisplayOrdersIntoOrderTable()
        {
            RepeaterConfirmation.DataSource = DisplayOrders;
            RepeaterConfirmation.DataBind();
        }

        public void LoadTotalIntoOrderTable()
        {
            TotalValue.Text = string.Format("{0:c}", Total);
        }
    }
}