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
        private Customer Customer;
        private DisplayCustomer DisplayCustomer;
        private readonly IMovieRepository MovieRepository = new MovieDatabaseRepository();
        private decimal Total;

        protected List<Movie> CurrentMovies
        {
            get
            { return MovieRepository.GetMovies(); }
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
            Orders = (List<OrderLine>)Session["MoviesOrdered"];
            Customer = (Customer)Session["CustomerInfo"];
        }

        public void SetPageMemberDisplayVariables()
        {
            DisplayOrders = new ListOfDisplayOrderLineMapper().MapFromListOfOrderLine(Orders);
            DisplayCustomer = new DisplayCustomerMapper().MapFromCustomer(Customer);
            Total = new TotalMapper().MapTotal(DisplayOrders);
        }

        public void PopulatePageWithOrderData()
        {
            LoadCustomerInformationIntoPage();
            LoadOrderTableIntoPage();
        }

        public void LoadCustomerInformationIntoPage()
        {
            CustomerName.Text = DisplayCustomer.Name;
            CustomerEmail.Text = DisplayCustomer.Email;
            CustomerCardNumber.Text = DisplayCustomer.ProtectedCardNumber;
            CustomerCardType.Text = DisplayCustomer.CardType;
            CustomerFuturePromotions.Text = (DisplayCustomer.FuturePromotions == true) ? "Yes" : "No";
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