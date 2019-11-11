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
        public static List<MovieOrder> Orders;

        public List<Movie> CurrentMovies
        {
            get
            { return new MovieRepository().GetMovies(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetupConfirmationPageOnFirstLoad();
                TransferDataToDatabase();
            }
        }

        public void SetupConfirmationPageOnFirstLoad()
        {
            SetPageCultureToBritish();
            SetPageMemberVariables();
            PopulatePageWithOrderData();
        }

        public static void SetPageCultureToBritish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        public void SetPageMemberVariables()
        {
            Orders = (List<MovieOrder>)Session["MoviesOrdered"];
        }

        public void PopulatePageWithOrderData()
        {
            LoadCustomerInformationIntoPage();
            LoadOrderTableIntoPage();
        }

        public void LoadCustomerInformationIntoPage()
        {
            CustomerName.Text = (string)Session["Name"];
            CustomerEmail.Text = (string)Session["Email"];
            CustomerCardNumber.Text = (string)Session["CardNumber"];
            CustomerCardType.Text = (string)Session["CardType"];
            CustomerFuturePromotions.Text = ((bool)Session["FuturePromotions"] == true) ? "Yes" : "No";
        }

        public void LoadOrderTableIntoPage()
        {
            LoadOrdersIntoOrderTable();
            LoadOrderTotalIntoOrderTable();
        }

        public void LoadOrdersIntoOrderTable()
        {
            RepeaterConfirmation.DataSource = Orders;
            RepeaterConfirmation.DataBind();
        }

        public void LoadOrderTotalIntoOrderTable()
        {
            decimal total = Orders.Total();
            TotalValue.Text = string.Format("{0:c}", total);
        }

        private void TransferDataToDatabase()
        {
            DataStagedForDBWrite dataStagedForDBWrite = DataStager.StageData(Session);
            DBWriter.WriteToDB(dataStagedForDBWrite);
        }
    }
}