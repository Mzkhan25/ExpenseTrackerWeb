#region
using System;
using System.Drawing;
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.DataObjects
{
    public class Expense : EntityData
    {
        public string UserName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public float Amount { get; set; }
        public string Comment { get; set; }
        public string Receipt { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public bool Credit { get; set; }

        public DateTime Date { get; set; }
        public Byte[] UploadedImage { get; set; }
    }
}