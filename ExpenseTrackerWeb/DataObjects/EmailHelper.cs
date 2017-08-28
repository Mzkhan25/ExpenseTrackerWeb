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

            msg.SetFrom(new EmailAddress("devops@teknita.com", "SendGrid DX Team"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("devops@teknita.com", "Jeff Smith")
            };
            msg.AddTos(recipients);

            msg.SetSubject("Testing the SendGrid C# Library");

            msg.AddContent(MimeType.Text, "New expense made by " + expense.UserName + "\r\n" + "Expense: " + expense.Amount);
            var response = await client.SendEmailAsync(msg);

        }

    }
}