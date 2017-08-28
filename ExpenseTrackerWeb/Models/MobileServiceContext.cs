#region
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ExpenseTrackerWeb.DataObjects;
using Microsoft.Azure.Mobile.Server.Tables;
#endregion

namespace ExpenseTrackerWeb.Models
{
    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string ConnectionStringName =
                "Data Source=teknita.database.windows.net;Initial Catalog=expensetracker;Integrated Security=False;User ID=devops;Password=Mz@93254;Connect Timeout=1500000;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            ;
        public MobileServiceContext() : base(ConnectionStringName)
        {
            Database.Connection.ConnectionString = ConnectionStringName;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> SubCategories { get; set; }
        public DbSet<SubCategory> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }
}