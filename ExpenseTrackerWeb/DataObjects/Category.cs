#region
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.DataObjects
{
    public class Category : EntityData
    {
        public string Name { get; set; }
        public string SubCategoryId { get; set; }
    }
}