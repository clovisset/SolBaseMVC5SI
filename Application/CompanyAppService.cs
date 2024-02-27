using MVC_DDD.Application.Interface;
using MVC_DDD.Domain.Entities;
using MVC_DDD.Domain.Interfaces.Services;
using MVC_DDD.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Application
{
	public class CompanyAppService : AppServiceBase<Company>, ICompanyAppService
	{
		private readonly ICompanyService _companyService;

		public CompanyAppService(ICompanyService companyService)
			: base(companyService)
		{
			_companyService = companyService;
		}


	}
}
