using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
	public class HomeController : Controller
	{
		Assignment2Entities _context = new Assignment2Entities();
		public ActionResult Index()
		{
			var listofData= _context.Students.ToList();
			return View(listofData);
		}
		[HttpGet]
		public ActionResult Create() 
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Student model)
		{
			_context.Students.Add(model);
			_context.SaveChanges();
			ViewBag.Message = "Data insert succesfuly";
			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var data = _context.Students.Where(x => x.id == id).FirstOrDefault();
			return View(data);
		}
		[HttpPost]
		public ActionResult Edit(Student Model)
		{
			var data = _context.Students.Where(x => x.id == Model.id).FirstOrDefault();
			if (data != null)
			{
				data.name = Model.name;
				data.age = Model.age;
			
				_context.SaveChanges();
			}
			return RedirectToAction("index");
		}
		public ActionResult Detail(int id)
		{
			var data = _context.Students.Where(x => x.id == id).FirstOrDefault();
			return View(data);
		}
		public ActionResult Delete(int id) 
		{
			var data = _context.Students.Where(x => x.id == id).FirstOrDefault();
			_context.Students.Remove(data);
			_context.SaveChanges();
			ViewBag.Message = "Record Delete succesful";
			return RedirectToAction("index");
		}
	}
}