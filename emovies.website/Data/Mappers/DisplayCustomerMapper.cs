using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace emovies.website.Data
{
    public class DisplayCustomerMapper
    {
        public DisplayCustomer MapFromCustomer(Customer customer)
        {
            return new DisplayCustomer
            {
                Name = customer.Name,
                Email = customer.Email,
                ProtectedCardNumber = ProtectedForm(customer.CardNumber),
                CardType = customer.CardType,
                FuturePromotions = customer.FuturePromotions
            };
        }

        private string ProtectedForm(string cardNumber)
        {
            string starredForm = new String('*', cardNumber.Length);
            string firstFourNumbers = cardNumber.Substring(0, 4);
            string protectedForm = firstFourNumbers + starredForm.Substring(4);
            protectedForm = Regex.Replace(protectedForm, ".{4}", "$0 ");
            return protectedForm;
        }
    }
}