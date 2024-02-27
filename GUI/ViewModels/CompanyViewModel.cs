using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DDD.MVC.ViewModels
{
	public class CompanyViewModel
	{
		[Key]
		public int CompanyId { get; set; }

		[Required(ErrorMessage = "Preencha o campo Nome")]
		[MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
		public string Name { get; set; }

		public virtual IEnumerable<CountryViewModel> Countrys { get; set; }
	}
}