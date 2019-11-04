using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website.Controls
{
    public partial class UserTextInputControl : System.Web.UI.UserControl
    {
        public string Text
        {
            get { return TextInput.Text; }
            set { TextInput.Text = value; }
        }

        public string CssClass
        {
            set { TextInput.CssClass = value; }
        }

        public Int32 MaxLength
        {
            set { TextInput.MaxLength = value; }
        }

        //public string RegularExpressionText
        //{
        //    set { RegularExpressionValidator.Text = value; }
        //}

        //public ValidatorDisplay RequiredFieldDisplay
        //{
        //    set { RequiredFieldValidator.Display = value; }
        //}

        //public ValidatorDisplay RegularExpressionDisplay
        //{
        //    set { RegularExpressionValidator.Display = value; }
        //}

        //public bool EnabledRequiredField
        //{
        //    set { RequiredFieldValidator.Enabled = value; }
        //}

        //public bool EnabledRegularExpression
        //{
        //    set { RegularExpressionValidator.Enabled = value; }
        //}

        //public string ErrorMsgForRequiredField
        //{
        //    set { RequiredFieldValidator.ErrorMessage = value; }
        //}

        //public string ErrorMsgForRegularExpression
        //{
        //    set { RegularExpressionValidator.ErrorMessage = value; }
        //}

        //public string ValidationExpression
        //{
        //    set { RegularExpressionValidator.ValidationExpression = value; }
        //}

        //public string ValidationGroup
        //{
        //    set
        //    {
        //        RegularExpressionValidator.ValidationGroup = value;
        //        RequiredFieldValidator.ValidationGroup = value;
        //    }
        //}

        //public bool EnableClientScript
        //{
        //    set
        //    {
        //        RegularExpressionValidator.EnableClientScript = value;
        //        RequiredFieldValidator.EnableClientScript = value;
        //    }
        //}
    }
}