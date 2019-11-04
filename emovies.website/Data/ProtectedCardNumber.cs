using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace emovies.website.Data
{
    public class ProtectedCardNumber
    {
        public string SafeFormat { get; set; }

        private string Serialise (string cardNumber)
        {
            string starredForm = new String('*', cardNumber.Length);
            string firstFourNumbers = cardNumber.Substring(0, 4);
            string serialisedForm = firstFourNumbers + starredForm.Substring(4);
            serialisedForm = Regex.Replace(serialisedForm, ".{4}", "$0 ");
            return serialisedForm;
        }

        public ProtectedCardNumber(string cardNumber) {
            this.SafeFormat = Serialise(cardNumber);
        }
    }
}