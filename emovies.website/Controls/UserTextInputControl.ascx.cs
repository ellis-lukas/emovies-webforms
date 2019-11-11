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
        public string LabelText
        {
            get { return InputLabel.Text; }
            set { InputLabel.Text = value; }
        }

        public string Text
        {
            get { return TextInput.Text; }
            set { TextInput.Text = value; }
        }

        public Int32 MaxLength
        {
            set { TextInput.MaxLength = value; }
        }

        public ValidatorDisplay RequiredFieldDisplay
        {
            set { RequiredFieldValidator.Display = value; }
        }

        public ValidatorDisplay RegularExpressionDisplay
        {
            set { RegularExpressionValidator.Display = value; }
        }

        public string ErrorMsgForRequiredField
        {
            set { RequiredFieldValidator.ErrorMessage = value; }
        }

        public string ErrorMsgForRegularExpression
        {
            set { RegularExpressionValidator.ErrorMessage = value; }
        }

        public string ValidationExpression
        {
            set { RegularExpressionValidator.ValidationExpression = value; }
        }

        public string ValidationGroup
        {
            set
            {
                RegularExpressionValidator.ValidationGroup = value;
                RequiredFieldValidator.ValidationGroup = value;
            }
        }

        public bool EnableClientScript
        {
            set
            {
                RegularExpressionValidator.EnableClientScript = value;
                RequiredFieldValidator.EnableClientScript = value;
            }
        }
    }
}