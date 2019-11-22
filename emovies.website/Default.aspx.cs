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
        private readonly MovieRepository movieRepository = MovieRepository.GetInstance();
        private List<Movie> CurrentMovies { get
            { return movieRepository.GetMovies(); }
        }

        private List<Movie> CurrentMoviesInRenderOrder { get 
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
            BrowsePageRepeater.DataSource = CurrentMoviesInRenderOrder;
            BrowsePageRepeater.DataBind();
        }

        public void SetUpBrowsePageValidation()
        {
            SetUpBrowsePageInputValidators();
            SetUpBrowsePageInputServerValidation();
            SetUpBrowsePageValidationSummary(BrowsePageValidationSummary);
        }

        public void SetUpBrowsePageInputValidators()
        {
            SetUpNonZeroValidator(NonZeroValidator);
            SetUpNonNegativeValidator(NonNegativeValidator);
            SetUpRangeValidator(RangeValidator);
        }

        public void SetUpNonZeroValidator(CustomValidator nonZeroValidator)
        {
            nonZeroValidator.Display = ValidatorDisplay.None;
            nonZeroValidator.ErrorMessage = "No movies selected";
            nonZeroValidator.EnableClientScript = true;
        }

        public void SetUpNonNegativeValidator(CustomValidator nonNegativeValidator)
        {
            nonNegativeValidator.Display = ValidatorDisplay.None;
            nonNegativeValidator.ErrorMessage = "Cannot have negative quantity";
            nonNegativeValidator.EnableClientScript = true;
        }

        public void SetUpRangeValidator(CustomValidator rangeValidator)
        {
            rangeValidator.Display = ValidatorDisplay.None;
            rangeValidator.ErrorMessage = "Quantity Above 254 Limit!";
            rangeValidator.EnableClientScript = true;
        }

        public void SetUpBrowsePageInputServerValidation()
        {
            
        }

        public void SetUpBrowsePageValidationSummary(ValidationSummary browsePageValidationSummary)
        {
            browsePageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            browsePageValidationSummary.ShowMessageBox = false;
            browsePageValidationSummary.ShowSummary = true;
            browsePageValidationSummary.EnableClientScript = true;
        }

        protected void OrderNowClicked(object sender, EventArgs e)
        {
            SaveOrderToSession();
            Response.Redirect("order.aspx");
        }

        public void SaveOrderToSession()
        {
            RepeaterItemCollection returnedMovieTable = BrowsePageRepeater.Items;
            List<int> quantityList = new QuantityReader(returnedMovieTable).GetQuantityList();
            List<OrderLine> moviesOrdered = new ListOfOrderLineGenerator(quantityList, CurrentMoviesInRenderOrder).GenerateMovieOrders();
            Session["MoviesOrdered"] = moviesOrdered;
        }
    }
}