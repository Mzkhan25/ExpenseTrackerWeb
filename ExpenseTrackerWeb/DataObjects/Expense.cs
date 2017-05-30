#region
using System;
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.DataObjects
{
    public class Expense : EntityData
    {
        public string UserName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Comment { get; set; }
        public string Receipt { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
    }
}