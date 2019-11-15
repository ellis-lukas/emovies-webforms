using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website
{
    public partial class Order : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetUpOrderPageOnFirstLoad();
            }
        }

        public void SetUpOrderPageOnFirstLoad()
        {
            SetUpOrderPageValidation();
        }

        public void SetUpOrderPageValidation()
        {
            SetUpOrderPageInputValidation();
            SetUpOrderPageValidationSummary(OrderPageValidationSummary);
        }

        public void SetUpOrderPageInputValidation()
        {
            SetUpNameValidation();
            SetUpEmailValidation();
            SetUpCardNumberValidation();
        }

        public void SetUpNameValidation()
        {
            Name.RequiredFieldDisplay = ValidatorDisplay.Dynamic;
            Name.RegularExpressionDisplay = ValidatorDisplay.Dynamic;
            Name.ErrorMsgForRequiredField = "Name is required";
            Name.ErrorMsgForRegularExpression = "Invalid name entered";
            Name.ValidationExpression = @"\s*[\w]+(\.){0,1}((\s+[\w]+(-){0,1}[\w]+)|(\s+[\w]+))*\s*";
            Name.EnableClientScript = true;
        }

        public void SetUpEmailValidation()
        {
            Email.RequiredFieldDisplay = ValidatorDisplay.Dynamic;
            Email.RegularExpressionDisplay = ValidatorDisplay.Dynamic;
            Email.RequiredFieldText = "emailaddressneeeded";
            Email.ErrorMsgForRequiredField = "Email address is required";
            Email.ErrorMsgForRegularExpression = "Invalid email address entered";
            Email.ValidationExpression = @"\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\s*";
            
            Email.EnableClientScript = true;
        }

        public void SetUpCardNumberValidation()
        {
            CardNumber.RequiredFieldDisplay = ValidatorDisplay.Static;
            CardNumber.RegularExpressionDisplay = ValidatorDisplay.Static;
            CardNumber.ErrorMsgForRequiredField = "Card number required";
            CardNumber.ErrorMsgForRegularExpression = "Invalid card number entered";
            CardNumber.ValidationExpression = @"\s*([0-9]\s*){15,19}";
            CardNumber.EnableClientScript = true;
        }

        public void SetUpOrderPageValidationSummary(ValidationSummary orderPageValidationSummary)
        {
            orderPageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            orderPageValidationSummary.ShowMessageBox = false;
            orderPageValidationSummary.ShowSummary = true;
        }

        protected void SubmitOrderClicked(object sender, EventArgs e)
        {
            SaveCustomerInfoToSession();
            SubmitDataToDatabase();
            Response.Redirect("confirmation.aspx");
        }

        private void SaveCustomerInfoToSession()
        {
            Session["CustomerInfo"] = new Customer
            {
                Name = Name.Text,
                Email = Email.Text,
                CardNumber = CardNumber.Text,
                CardType = CardType.Text,
                FuturePromotions = FuturePromotions.Checked
            };
        }

        private void SubmitDataToDatabase()
        {
            DataStagedForDBWrite dataStagedForDBWrite = new DataStager().StageData(Session);
            new DBWriter().WriteToDB(dataStagedForDBWrite);
        }
    }
}