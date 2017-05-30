#region
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.DataObjects
{
    public class Notification : EntityData
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}