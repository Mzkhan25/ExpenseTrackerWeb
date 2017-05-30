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
    public class CompanyController : TableController<Company>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Company>(context, Request);
        }

        // GET tables/Company
        public IQueryable<Company> GetAllCompanies()
        {
            return Query();
        }

        // GET tables/Company/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Company> GetCompany(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Company/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Company> PatchCompany(string id, Delta<Company> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Company
        public async Task<IHttpActionResult> PostCompany(Company item)
        {
            var current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        // DELETE tables/Company/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCompany(string id)
        {
            return DeleteAsync(id);
        }
    }
}