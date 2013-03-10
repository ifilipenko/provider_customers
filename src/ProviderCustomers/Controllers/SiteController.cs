using System.Data;
using System.Linq;
using System.Web.Mvc;
using ProviderCustomers.Models;
using ProviderCustomers.Models.Domain;

namespace ProviderCustomers.Controllers
{
    public class SiteController : Controller
    {
        private readonly ProviderCustomersContext _db = new ProviderCustomersContext();

        public ActionResult Index()
        {
            return View(_db.Sites.Include("Plan").ToList());
        }

        public ActionResult Create()
        {
            SetSiteEditTitle(isNew: true);
            ViewBag.Plans = GetHostingPlans();
            return View("CreateOrEdit");
        }
        
        public ActionResult Edit(long id = 0)
        {
            var site = _db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            SetSiteEditTitle(isNew: false);
            ViewBag.Plans = GetHostingPlans();
            return View("CreateOrEdit", new EditSiteViewModel(site));
        }

        [HttpPost]
        public ActionResult Save(EditSiteViewModel model)
        {
            ModelState.Remove("Id");
            var hostingPlans = _db.HostingPlans.ToList();
            if (ModelState.IsValid)
            {
                if (model.IsNew)
                {
                    var site = new Site();
                    model.SaveSite(site, hostingPlans);
                    _db.Sites.Add(site);
                }
                else
                {
                    var site = _db.Sites.Find(model.Id);
                    if (site == null)
                    {
                        ModelState.AddModelError("", "Site is not exists");
                        return Edit(model.Id);
                    }
                    model.SaveSite(site, hostingPlans);
                    _db.Entry(site).State = EntityState.Modified;
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetSiteEditTitle(model.IsNew);
            ViewBag.Plans = GetHostingPlans();
            return View("CreateOrEdit", model);
        }

        public ActionResult Delete(long id = 0)
        {
            var site = _db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            var site = _db.Sites.Find(id);
            _db.Sites.Remove(site);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        private void SetSiteEditTitle(bool isNew)
        {
            ViewBag.Title = isNew ? "Create new site" : "Edit site";
        }

        private HostingPlanViewModel[] GetHostingPlans()
        {
            var plans = _db.HostingPlans.ToList();
            var empty = new[] {new HostingPlanViewModel(null, "Not specified")};
            return empty.Concat(plans.OrderBy(p => p.Name)
                                     .Select(p => new HostingPlanViewModel(p)))
                        .ToArray();
        }
    }
}