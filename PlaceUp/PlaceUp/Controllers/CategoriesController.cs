using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlaceUp.Context;
using PlaceUp.Models;
using PlaceUp.Context.CategoryRepository;

namespace PlaceUp.Controllers
{
    [RoutePrefix("Categories")]
    public class CategoriesController : Controller
    {
        ICategoryRepository catRep;

        public CategoriesController(ICategoryRepository catRepository)
        {
            catRep = catRepository;
        }

        [Route("GetAll")]
        public async Task<ActionResult> Index()
        {
            return View(await catRep.GetAll());
        }

        [Route("Details/{id}")]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!await catRep.IsExist(id))
            {
                return HttpNotFound();
            }
            return View(await catRep.GetByGuid(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    await catRep.Add(category);
                    return RedirectToAction("Index");
                }

                return View(category);
            }

            return View(category);
        }

        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!await catRep.IsExist(id))
            {
                return HttpNotFound();
            }

            return View(await catRep.GetByGuid(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                await catRep.Edit(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
