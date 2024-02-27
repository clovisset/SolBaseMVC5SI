using MVC_DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Infra.Data.EntityConfig
{
	public class CompanyConfiguration : EntityTypeConfiguration<Company>
	{
		public CompanyConfiguration()
		{
			HasKey(c => c.CompanyId);

			Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(150);

		}
	}
}
