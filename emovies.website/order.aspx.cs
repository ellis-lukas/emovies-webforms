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
            Name.ErrorMsgForRequiredField = "Name required";
            Name.ErrorMsgForRegularExpression = "Invalid name entered";
            Name.ValidationExpression = @"\s*[a-zA-Z]+(\.){0,1}((\s+[a-zA-Z]+(-){0,1}[a-zA-Z]+)|(\s+[a-zA-Z]+))*\s*";
            Name.EnableClientScript = true;
        }

        public void SetUpEmailValidation()
        {
            Email.RequiredFieldDisplay = ValidatorDisplay.Dynamic;
            Email.RegularExpressionDisplay = ValidatorDisplay.Dynamic;
            Email.RequiredFieldText = "Email address required";
            Email.ErrorMsgForRequiredField = "Email address is required";
            Email.ErrorMsgForRegularExpression = "Invalid email address entered";
            Email.ValidationExpression = @"\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\s*";
            Email.EnableClientScript = true;
        }

        public void SetUpCardNumberValidation()
        {
            CardNumber.RequiredFieldDisplay = ValidatorDisplay.Dynamic;
            CardNumber.RegularExpressionDisplay = ValidatorDisplay.Dynamic;
            CardNumber.ErrorMsgForRequiredField = "Card number required";
            CardNumber.ErrorMsgForRegularExpression = "Invalid card number entered";
            CardNumber.ValidationExpression = @"\s*([0-9]\s*){15,19}";
            CardNumber.EnableClientScript = true;
        }

        protected void SubmitOrderClicked(object sender, EventArgs e)
        {
            SaveCustomerInfoToSession();
            SubmitDataToDatabase();
            Response.Redirect("confirmation.aspx");
        }

        private void SaveCustomerInfoToSession()
        {
            Customer newCustomer = new Customer
            {
                Name = Name.Text,
                Email = Email.Text,
                CardNumber = CardNumber.Text,
                CardType = CardType.Text,
                FuturePromotions = FuturePromotions.Checked
            };
            Session["CustomerInfo"] = newCustomer;
        }

        private void SubmitDataToDatabase()
        {
            DataStagedForDBWrite dataStagedForDBWrite = new DataStager().StageData(Session);
            new DBWriter().WriteToDB(dataStagedForDBWrite);
        }
    }
}