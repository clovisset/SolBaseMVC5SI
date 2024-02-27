using MVC_DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DDD.Infra.Data.EntityConfig
{
	public class CountryConfiguration : EntityTypeConfiguration<Country>
	{
		public CountryConfiguration()
		{
			HasKey(c => c.CountryId);

			Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(150);

			HasRequired(c => c.Company)
				.WithMany()
				.HasForeignKey(c => c.CompanyId);
		}
	}
}
