using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebPresentations.DatabaseEntities;
using WebPresentations.Models;

namespace WebPresentations.Controllers
{
    public abstract class EntityController : Controller
    {
        private DatabaseContext _entities;

        protected DatabaseContext Entities
        {
            get { return _entities ?? (_entities = new DatabaseContext()); }
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
