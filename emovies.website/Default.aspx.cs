using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        private RepeaterItemCollection returnedMovieTable;
        private List<int> quantityList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetupBrowsePageOnFirstLoad();
            }
        }

        private void SetupBrowsePageOnFirstLoad()
        {
            SetPageCultureToBritish();
            LoadMoviesIntoPage();
            SetUpBrowsePageValidation();
        }

        private void SetPageCultureToBritish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        private void LoadMoviesIntoPage()
        {
            BrowsePageRepeater.DataSource = CurrentMoviesInRenderOrder;
            BrowsePageRepeater.DataBind();
        }

        private void SetUpBrowsePageValidation()
        {
            SetUpBrowsePageInputValidators();
            SetUpBrowsePageValidationSummary(BrowsePageValidationSummary);
        }

        private void SetUpBrowsePageInputValidators()
        {
            SetUpNonZeroValidator(NotZerosValidator);
            SetUpNonNegativeValidator(NoNegativesValidator);
            SetUpRangeValidator(RangeValidator);
            SetUpFormatValidator(FormatValidator);
        }

        private void SetUpNonZeroValidator(CustomValidator nonZeroValidator)
        {
            nonZeroValidator.Display = ValidatorDisplay.None;
            nonZeroValidator.ErrorMessage = "No movies selected";
            nonZeroValidator.EnableClientScript = true;
        }

        private void SetUpNonNegativeValidator(CustomValidator nonNegativeValidator)
        {
            nonNegativeValidator.Display = ValidatorDisplay.None;
            nonNegativeValidator.ErrorMessage = "Cannot have negative quantity";
            nonNegativeValidator.EnableClientScript = true;
        }

        private void SetUpRangeValidator(CustomValidator rangeValidator)
        {
            rangeValidator.Display = ValidatorDisplay.None;
            rangeValidator.ErrorMessage = "Quantity Outside Permitted Range!";
            rangeValidator.EnableClientScript = true;
        }

        private void SetUpFormatValidator(CustomValidator formatValidator)
        {
            formatValidator.Display = ValidatorDisplay.None;
            formatValidator.ErrorMessage = "Inputs Of Incorrect Format";
            formatValidator.EnableClientScript = true;
        }

        private void SetUpBrowsePageValidationSummary(ValidationSummary browsePageValidationSummary)
        {
            browsePageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            browsePageValidationSummary.ShowMessageBox = false;
            browsePageValidationSummary.ShowSummary = true;
            browsePageValidationSummary.EnableClientScript = true;
        }

        protected void OrderNowClicked(object sender, EventArgs e)
        {
            returnedMovieTable = BrowsePageRepeater.Items;

            Validate();

            if (Page.IsValid)
            {
                quantityList = new QuantityReader(returnedMovieTable).GetQuantityList();
                SaveOrderToSession();
                Response.Redirect("order.aspx");
            }
        }

        private void SaveOrderToSession()
        {
            List<OrderLine> moviesOrdered = new ListOfOrderLineGenerator(quantityList, CurrentMoviesInRenderOrder).GenerateOrderLines();
            Session["MoviesOrdered"] = moviesOrdered;
        }

        protected void ServerValidateFormat(object source, ServerValidateEventArgs args)
        {
            try
            {
                List<int> quantityListTest = new QuantityReader(returnedMovieTable).GetQuantityList();
                args.IsValid = true;
            }
            catch
            {
                args.IsValid = false;
            }

        }

        protected void ServerValidateNotZeros(object source, ServerValidateEventArgs args)
        {
            try
            {
                List<int> quantityListTest = new QuantityReader(returnedMovieTable).GetQuantityList();
                try
                {
                    bool quantityListAllZeros = quantityListTest.ContainsAllZeros();
                    args.IsValid = !quantityListAllZeros;
                }
                catch
                {
                    args.IsValid = false;
                }
            }
            catch
            {
            }
        }

        protected void ServerValidateNoNegatives(object source, ServerValidateEventArgs args)
        {
            try
            {
                List<int> quantityListTest = new QuantityReader(returnedMovieTable).GetQuantityList();
                try
                {
                    bool quantityListContainsNegatives = quantityListTest.ContainsNegativeValues();
                    args.IsValid = !quantityListContainsNegatives;
                }
                catch
                {
                    args.IsValid = false;
                }
            }
            catch
            {

            }
        }

        protected void ServerValidateInRange(object source, ServerValidateEventArgs args)
        {
            try
            {
                List<int> quantityListTest = new QuantityReader(returnedMovieTable).GetQuantityList();
                try
                {
                    bool quantityListOutOfRange = quantityListTest.IntegersOutOfRange(254);
                    args.IsValid = !quantityListOutOfRange;
                }
                catch
                {
                    args.IsValid = false;
                }
            }
            catch
            {

            }
        }
    }
}