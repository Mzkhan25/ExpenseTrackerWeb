#region
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Http;
using ExpenseTrackerWeb.DataObjects;
using ExpenseTrackerWeb.Models;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using Configuration = ExpenseTrackerWeb.Migrations.Configuration;
#endregion

namespace ExpenseTrackerWeb
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
            var settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
            if (string.IsNullOrEmpty(settings.HostName))
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] {ConfigurationManager.AppSettings["ValidAudience"]},
                    ValidIssuers = new[] {ConfigurationManager.AppSettings["ValidIssuer"]},
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            var todoItems = new List<TodoItem>
            {
                new TodoItem {Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false},
                new TodoItem {Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false}
            };
            foreach (var todoItem in todoItems)
                context.Set<TodoItem>().Add(todoItem);
            base.Seed(context);
        }
    }
}