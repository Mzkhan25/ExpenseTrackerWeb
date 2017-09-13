using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ExpenseTrackerWeb.DataObjects
{
    public static class EmailHelper
    {
        public static async System.Threading.Tasks.Task SendEmailAsync(Expense expense)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SendGridApi");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("devops@teknita.com", "[IT STage] Expense Tracker"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("devops@teknita.com", "devops"),
                new EmailAddress("mbajwa@watg.com", "Muhammad Bajwa")
            };
            msg.AddTos(recipients);

            msg.SetSubject("New Expense Made");

            msg.AddContent(MimeType.Text, "New expense made by " + expense.UserName + "\r\n" + "Expense: " + expense.Amount);
            var response = await client.SendEmailAsync(msg);

        }

    }
}