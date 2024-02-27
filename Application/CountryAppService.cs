using MVC_DDD.Application.Interface;
using MVC_DDD.Domain.Entities;
using MVC_DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Application
{
	public class CountryAppService : AppServiceBase<Country>, ICountryAppService
	{
		private readonly ICountryService _countryService;

		public CountryAppService(ICountryService countryService)
			: base(countryService)
		{
			_countryService = countryService;
		}


	}
}
