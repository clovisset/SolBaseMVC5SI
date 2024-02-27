using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DDD.MVC.ViewModels
{
	public class CountryViewModel
	{
		[Key]
		public int CountryId { get; set; }

		[Required(ErrorMessage = "Preencha o campo Nome")]
		[MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Name { get; set; }

		public int CompanyId { get; set; }

		public virtual CompanyViewModel Company { get; set; }
	}
}