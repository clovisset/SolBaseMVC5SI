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
	public class CompanyService : ServiceBase<Company>, ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyService(ICompanyRepository companyRepository)
			: base(companyRepository)
		{
			_companyRepository = companyRepository;
		}

	}
	
}
