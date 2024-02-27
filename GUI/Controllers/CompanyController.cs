using AutoMapper;
using MVC_DDD.Application.Interface;
using MVC_DDD.Domain.Entities;
using MVC_DDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DDD.MVC.Controllers
{
	public class CompanyController : Controller
	{
		private readonly ICompanyAppService _companyApp;

		public CompanyController(ICompanyAppService companyApp)
		{
			_companyApp = companyApp;
		}

		// GET: Company
		public ActionResult Index()
		{
			var companyViewModel = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyViewModel>>(_companyApp.GetAll());
			return View(companyViewModel);
		}



		// GET: Company/Details/5
		public ActionResult Details(int id)
		{
			var company = _companyApp.GetById(id);
			var companyViewModel = Mapper.Map<Company, CompanyViewModel>(company);

			return View(companyViewModel);
		}

		// GET: Company/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Company/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CompanyViewModel company)
		{
			if (ModelState.IsValid)
			{
				var companyDomain = Mapper.Map<CompanyViewModel, Company>(company);
				_companyApp.Add(companyDomain);

				return RedirectToAction("Index");
			}

			return View(company);
		}

		// GET: Company/Edit/5
		public ActionResult Edit(int id)
		{
			var company = _companyApp.GetById(id);
			var companyViewModel = Mapper.Map<Company, CompanyViewModel>(company);

			return View(companyViewModel);
		}

		// POST: Company/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CompanyViewModel company)
		{
			if (ModelState.IsValid)
			{
				var companyDomain = Mapper.Map<CompanyViewModel, Company>(company);
				_companyApp.Update(companyDomain);

				return RedirectToAction("Index");
			}

			return View(company);
		}

		// GET: Company/Delete/5
		public ActionResult Delete(int id)
		{
			var company = _companyApp.GetById(id);
			var companyViewModel = Mapper.Map<Company, CompanyViewModel>(company);

			return View(companyViewModel);
		}

		// POST: Company/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var company = _companyApp.GetById(id);
			_companyApp.Remove(company);

			return RedirectToAction("Index");
		}
	}
}