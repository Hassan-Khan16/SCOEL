using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bartersystemoel.Controllers
{
    public class HomeController : Controller
    {
        // bartersystemEntities
        bartersystemEntities _context = new bartersystemEntities();
        public ActionResult Index()
        {
            var listofData = _context.customers.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(customer model)
        {
            _context.customers.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        	[HttpGet]  
public ActionResult Edit(int id)
	{               
	    var data = _context.customers.Where(x => x.ID == id).FirstOrDefault();  
	    return View(data);  
	}  
	[HttpPost]  
	public ActionResult Edit(customer Model)
	{  
    var data = _context.customers.Where(x => x.ID == Model.ID).FirstOrDefault();  
	    if (data != null)  
	    {  
	        data.city = Model.city;        
                data.name = Model.name;  
	        data.points = Model.points;  
	        _context.SaveChanges();  
	    }  
  
    return RedirectToAction("index");  
	}
        public ActionResult Detail(int id)
        {
            var data = _context.customers.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.customers.Where(x => x.ID == id).FirstOrDefault();
            _context.customers.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }



    }
}
