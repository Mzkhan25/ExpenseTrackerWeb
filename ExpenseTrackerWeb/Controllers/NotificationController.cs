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
    public class NotificationController : TableController<Notification>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Notification>(context, Request);
        }

        // GET tables/Notification
        public IQueryable<Notification> GetAllNotifications()
        {
            return Query();
        }

        // GET tables/Notification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Notification> GetNotification(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Notification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Notification> PatchNotification(string id, Delta<Notification> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Notification
        public async Task<IHttpActionResult> PostNotification(Notification item)
        {
            var current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        // DELETE tables/Notification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotification(string id)
        {
            return DeleteAsync(id);
        }
    }
}