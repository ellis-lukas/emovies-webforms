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
            //SetUpNameValidation();
            //SetUpEmailValidation();
            //SetUpCardNumberValidation();
        }

        //public void SetUpNameValidation()
        //{
        //    SetUpNamePresenceValidator(NamePresenceValidator);
        //    SetUpNameFormatValidator(NameFormatValidator);
        //}

        //public void SetUpNamePresenceValidator(RequiredFieldValidator namePresenceValidator)
        //{
        //    namePresenceValidator.Display = ValidatorDisplay.None;
        //    namePresenceValidator.ErrorMessage = "Name is required";
        //}

        //public void SetUpNameFormatValidator(RegularExpressionValidator nameFormatValidator)
        //{
        //    nameFormatValidator.Display = ValidatorDisplay.None;
        //    nameFormatValidator.ValidationExpression = "\s*[\w]+(\.){0,1}((\s+[\w]+(-){0,1}[\w]+)|(\s+[\w]+))*\s*";
        //    nameFormatValidator.ErrorMessage = "Invalid name entered";
        //}

        //public void SetUpEmailValidation()
        //{
        //    SetUpEmailPresenceValidator(EmailPresenceValidator);
        //    SetUpEmailFormatValidator(EmailFormatValidator);
        //}

        //public void SetUpEmailPresenceValidator(RequiredFieldValidator emailPresenceValidator)
        //{
        //    emailPresenceValidator.Display = ValidatorDisplay.None;
        //    emailPresenceValidator.ErrorMessage = "Email address is required";
        //}

        //public void SetUpEmailFormatValidator(RegularExpressionValidator emailFormatValidator)
        //{
        //    emailFormatValidator.Display = ValidatorDisplay.None;
        //    emailFormatValidator.ValidationExpression = @"\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\s*";
        //    emailFormatValidator.ErrorMessage = "Invalid email address entered";
        //}

        //public void SetUpCardNumberValidation()
        //{
        //    SetUpCardNumberPresenceValidator(CardNumberPresenceValidator);
        //    SetUpCardNumberFormatValidator(CardNumberFormatValidator);
        //}

        //public void SetUpCardNumberPresenceValidator(RequiredFieldValidator cardNumberPresenceValidator)
        //{
        //    cardNumberPresenceValidator.Display = ValidatorDisplay.None;
        //    cardNumberPresenceValidator.ErrorMessage = "Card number required";
        //}

        //public void SetUpCardNumberFormatValidator (RegularExpressionValidator cardNumberFormatValidator)
        //{
        //    cardNumberFormatValidator.Display = ValidatorDisplay.None;
        //    cardNumberFormatValidator.ValidationExpression = @"\s*([0-9]\s*){15,19}";
        //    cardNumberFormatValidator.ErrorMessage = "Invalid card number entered";
        //}

        public void SetUpOrderPageValidationSummary(ValidationSummary orderPageValidationSummary)
        {
            orderPageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            orderPageValidationSummary.ShowMessageBox = false;
            orderPageValidationSummary.ShowSummary = true;
        }


        protected void SubmitOrderClicked(object sender, EventArgs e)
        {
            Session["Name"] = Name.
            Session["Email"] = Email.Text;
            Session["CardNumber"] = CardNumber.Text;
            Session["CardType"] = CardType.Text;
            Session["FuturePromotions"] = Convert.ToInt32(FuturePromotions.Checked);
            Response.Redirect("confirmation.aspx");
        }
    }
}