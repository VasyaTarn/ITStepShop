using ITStepShop.Data;
using ITStepShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITStepShop.Controllers
{
    [Authorize(Roles = $"{WC.AdminRole}")]
    public class UsageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UsageController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: UsageController
        public ActionResult Index()
        {
            IEnumerable<Usage> usageList = _db.Usages;
            return View(usageList);
        }

        // GET: UsageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsageController/Create
        [HttpPost]
        public ActionResult Create(Usage usage)
        {
            if (ModelState.IsValid)
            {
                _db.Usages.Add(usage);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: UsageController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0) return NotFound();
            var usage = _db.Usages.Find(id);
            if (usage == null) return NotFound();
            return View(usage);
        }

        // POST: UsageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usage usage)
        {
            if (ModelState.IsValid)
            {
                _db.Usages.Update(usage);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usage);
        }

        // GET: UsageController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0) return NotFound();
            var usage = _db.Usages.Find(id);
            if (usage == null) return NotFound();
            return View(usage);
        }

        // POST: UsageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var usage = _db.Usages.Find(id);
            if (usage == null) return NotFound();
            else
            {
                _db.Usages.Remove(usage);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
