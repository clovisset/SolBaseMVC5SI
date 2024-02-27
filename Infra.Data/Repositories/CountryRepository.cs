using MVC_DDD.Domain.Entities;
using MVC_DDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Infra.Data.Repositories
{
	public class CountryRepository : RepositoryBase<Country>, ICountryRepository
	{
	}

}
