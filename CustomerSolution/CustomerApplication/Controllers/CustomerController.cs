using CustomerBL;
using CustomerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomerApplication.Controllers
{
 
    public class CustomerController : Controller
    {
        readonly ICustomerService _service;
        public CustomerController()
        {
            _service = new Provider().GetCustomerService();
        }
        // GET: Customer
       
        public async Task<ActionResult> Index()
        {
            try
            {
                var result = await _service.GetAllCustomers();
                return View(result);
            }
            catch
            {
                throw new Exception();
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: Customer/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                await _service.AddNew(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
