using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website
{
    public partial class Confirmation : Page
    {
        public static CustomerInformation VisitorInformation;
        public static List<MovieOrder> Orders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Setup_Confirmation_Page_On_First_Load();
            }
        }

        public void Setup_Confirmation_Page_On_First_Load()
        {
            Set_Page_Culture_To_British();
            Set_Page_Member_Variables();
            Populate_Page_With_Order_Data();
        }

        public static void Set_Page_Culture_To_British()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        public void Set_Page_Member_Variables()
        {
            VisitorInformation = new CustomerInformation(Session);
            Orders = (List<MovieOrder>)Session["Orders"];
        }

        public void Populate_Page_With_Order_Data()
        {
            Load_Customer_Information_Into_Page();
            Load_Order_Table_Into_Page();
        }

        public void Load_Customer_Information_Into_Page()
        {
            CustomerName.Text = VisitorInformation.Name;
            CustomerEmail.Text = VisitorInformation.Email;
            CustomerCardNumber.Text = VisitorInformation.CardNumberStarred;
            CustomerCardType.Text = VisitorInformation.CardType;
            CustomerFuturePromotions.Text = VisitorInformation.FuturePromotions;
        }

        public void Load_Order_Table_Into_Page()
        {
            Load_Orders_Into_Order_Table();
            Load_Order_Total_Into_Order_Table();
        }

        public void Load_Orders_Into_Order_Table()
        {
            RepeaterConfirmation.DataSource = Orders;
            RepeaterConfirmation.DataBind();
        }

        public void Load_Order_Total_Into_Order_Table()
        {
            decimal total = Orders.Total();
            TotalValue.Text = string.Format("{0:c}", total);
        }
    }
}