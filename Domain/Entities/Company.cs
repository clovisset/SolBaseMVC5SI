using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Domain.Entities
{
	public class Company
	{
		public int CompanyId { get; set; }
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }
		public virtual IEnumerable<Country> Countrys { get; set; }
	}
}
