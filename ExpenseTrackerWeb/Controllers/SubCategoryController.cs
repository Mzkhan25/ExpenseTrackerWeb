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
    public class SubCategoryController : TableController<SubCategory>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SubCategory>(context, Request);
        }

        // GET tables/SubCategory
        public IQueryable<SubCategory> GetAllSubCategories()
        {
            return Query();
        }

        // GET tables/SubCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SubCategory> GetSubCategory(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SubCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SubCategory> PatchSubCategory(string id, Delta<SubCategory> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/SubCategory
        public async Task<IHttpActionResult> PostSubCategory(SubCategory item)
        {
            var current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        // DELETE tables/SubCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSubCategory(string id)
        {
            return DeleteAsync(id);
        }
    }
}