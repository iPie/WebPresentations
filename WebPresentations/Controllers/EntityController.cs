using System.Web.Mvc;
using WebPresentations.Models;

namespace WebPresentations.Controllers
{
    public abstract class EntityController : Controller
    {
        private PresentationsEntities _entities;

        protected PresentationsEntities Entities
        {
            get { return _entities ?? (_entities = new PresentationsEntities()); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _entities != null)
            {
                _entities.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
