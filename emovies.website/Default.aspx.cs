using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace emovies.website
{
    public partial class Default : Page
    {
        public List<Movie> CurrentMovies { get
            { return new MovieRepository().GetMovies(); }
        }

        public List<Movie> CurrentMoviesInRenderOrder { get 
            { return CurrentMovies; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetupBrowsePageOnFirstLoad();
            }
        }

        public void SetupBrowsePageOnFirstLoad()
        {
            SetPageCultureToBritish();
            LoadMoviesIntoPage();
            SetUpBrowsePageValidation();
        }

        public void SetPageCultureToBritish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        public void LoadMoviesIntoPage()
        {
            RepeaterBrowse.DataSource = CurrentMoviesInRenderOrder;
            RepeaterBrowse.DataBind();
        }

        public void SetUpBrowsePageValidation()
        {
            SetUpBrowsePageInputValidation();
            SetUpBrowsePageValidationSummary(BrowsePageValidationSummary);
        }

        public void SetUpBrowsePageInputValidation()
        {
            SetUpNonZeroValidation();
            SetUpSelectionUpdatedValidation();
        }

        public void SetUpNonZeroValidation()
        {
            SetUpNonZeroValidator(NonZeroValidator);
        }

        public void SetUpNonZeroValidator(CustomValidator nonZeroValidator)
        {
            nonZeroValidator.Display = ValidatorDisplay.None;
            nonZeroValidator.ErrorMessage = "No movies selected";
        }

        public void SetUpSelectionUpdatedValidation()
        {
            SetUpSelectionUpdatedValidator(SelectionUpdatedValidator);
        }

        public void SetUpSelectionUpdatedValidator(CustomValidator selectionUpdatedValidator)
        {
            selectionUpdatedValidator.Display = ValidatorDisplay.None;
            selectionUpdatedValidator.ErrorMessage = "Selection not updated";
        }

        public void SetUpBrowsePageValidationSummary(ValidationSummary browsePageValidationSummary)
        {
            browsePageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            browsePageValidationSummary.ShowMessageBox = false;
            browsePageValidationSummary.ShowSummary = true; 
        }

        protected void Order_Now_Clicked(object sender, EventArgs e)
        {
            SaveOrderToSession();
            Response.Redirect("order.aspx");
        }

        public void SaveOrderToSession()
        {
            RepeaterItemCollection returnedMovieTable = RepeaterBrowse.Items;
            List<int> quantityList = new QuantityReader(returnedMovieTable).GetQuantityList();
            List<MovieOrder> moviesOrdered = new ListOfMovieOrderGenerator(quantityList, CurrentMoviesInRenderOrder).GenerateMovieOrders();
            Session["MoviesOrdered"] = moviesOrdered;
        }
    }
}