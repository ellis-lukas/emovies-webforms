using System.Web.SessionState;

namespace emovies.website.Data
{
    public class CustomerInformationMapper
    {
        public CustomerInformation MapFromSession(HttpSessionState sessionState)
        {
            return new CustomerInformation
            {
                Name = (string)sessionState["Name"],
                Email = (string)sessionState["Email"],
            };
        }
    }
}