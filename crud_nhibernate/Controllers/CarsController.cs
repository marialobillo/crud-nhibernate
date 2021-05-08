using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using crud_nhibernate.Models;


namespace crud_nhibernate.Controllers
{
    public class CarsController : Controller
    {
        private readonly ISession _session;

        public CarsController(ISession session)
        {
            _session = session;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _session.Query<Car>().ToListAsync());
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

        [HttpGet]
        public async Task<IActionResult> Update(int carId)
        {
            return View(await _session.GetAsync<Car>(carId));   
        }

        [HttpPost]
        public async Task<IActionResult> Update(int carId, Car car)
        {
            if (carId != car.CarId)
                return NotFound();

            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveOrUpdateAsync(car);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(car);
        }
    }
}
