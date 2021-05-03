using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crud_nhibernate.Models;
using NHibernate;

namespace crud_nhibernate.Controllers
{
    public class CarsController : Controller
    {
        private readonly ISession _session;

        public CarsController(ISession session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveAsync(car);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Create));
                }
            }

            return View(car);
        }
    }
}
