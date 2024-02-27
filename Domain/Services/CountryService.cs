using MVC_DDD.Domain.Entities;
using MVC_DDD.Domain.Interfaces.Repositories;
using MVC_DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Domain.Services
{
	public class CountryService : ServiceBase<Country>, ICountryService
	{
		private readonly ICountryRepository _countryRepository;

		public CountryService(ICountryRepository countryRepository)
			: base(countryRepository)
		{
			_countryRepository = countryRepository;
		}
	}
}
