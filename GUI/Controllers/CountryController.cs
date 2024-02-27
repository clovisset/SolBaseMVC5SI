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
	public class CountryController : Controller
	{
		// GET: Country
		private readonly ICountryAppService _countryApp;
		private readonly ICompanyAppService _companyApp;

		public CountryController(ICountryAppService countryApp, ICompanyAppService companyApp)
		{
			_countryApp = countryApp;
			_companyApp = companyApp;
		}

		// GET: country
		public ActionResult Index()
		{
			var countryViewModel = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(_countryApp.GetAll());

			return View(countryViewModel);
		}

		// GET: country/Details/5
		public ActionResult Details(int id)
		{
			var country = _countryApp.GetById(id);
			var countryViewModel = Mapper.Map<Country, CountryViewModel>(country);

			return View(countryViewModel);
		}

		// GET: country/Create
		public ActionResult Create()
		{
			ViewBag.CompanyId = new SelectList(_companyApp.GetAll(), "CompanyId", "Name");
			return View();
		}

		// POST: country/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CountryViewModel country)
		{
			if (ModelState.IsValid)
			{
				var countryDomain = Mapper.Map<CountryViewModel, Country>(country);
				_countryApp.Add(countryDomain);

				return RedirectToAction("Index");
			}

			ViewBag.CompanyId = new SelectList(_companyApp.GetAll(), "CompanyId", "Name", country.CompanyId);
			return View(country);
		}

		// GET: country/Edit/5
		public ActionResult Edit(int id)
		{
			var country = _countryApp.GetById(id);
			var countryViewModel = Mapper.Map<Country, CountryViewModel>(country);

			ViewBag.CompanyId = new SelectList(_companyApp.GetAll(), "CompanyId", "Name", countryViewModel.CompanyId);

			return View(countryViewModel);
		}

		// POST: country/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CountryViewModel country)
		{
			if (ModelState.IsValid)
			{
				var countryDomain = Mapper.Map<CountryViewModel, Country>(country);
				_countryApp.Update(countryDomain);

				return RedirectToAction("Index");
			}

			ViewBag.CompanyId = new SelectList(_companyApp.GetAll(), "CompanyId", "Name", country.CompanyId);
			return View(country);
		}

		// GET: country/Delete/5
		public ActionResult Delete(int id)
		{
			var country = _countryApp.GetById(id);
			var countryViewModel = Mapper.Map<Country, CountryViewModel>(country);

			return View(countryViewModel);
		}

		// POST: country/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var country = _countryApp.GetById(id);
			_countryApp.Remove(country);

			return RedirectToAction("Index");
		}
	}
}