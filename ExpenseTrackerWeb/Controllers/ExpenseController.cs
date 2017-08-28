#region
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using ExpenseTrackerWeb.DataObjects;
using ExpenseTrackerWeb.Models;
using Microsoft.Azure.Mobile.Server;
#endregion

namespace ExpenseTrackerWeb.Controllers
{
    public class ExpenseController : TableController<Expense>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Expense>(context, Request);
        }

        // GET tables/Expense
        public IQueryable<Expense> GetAllExpenses()
        {
            return Query();
        }

        // GET tables/Expense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Expense> GetExpense(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Expense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Expense> PatchExpense(string id, Delta<Expense> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Expense
        public async Task<IHttpActionResult> PostExpense(Expense item)
        {
            var current = await InsertAsync(item);
            EmailHelper.SendEmailAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        // DELETE tables/Expense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteExpense(string id)
        {
            return DeleteAsync(id);
        }
    }
}