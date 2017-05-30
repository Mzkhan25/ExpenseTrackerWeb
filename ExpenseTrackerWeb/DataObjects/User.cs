#region
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.DataObjects
{
    public class User : EntityData
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Company { get; set; }
        public int CompanyId { get; set; }
    }
}