
using AutoMapper;
using MVC_DDD.Domain.Entities;
using MVC_DDD.MVC.ViewModels;

namespace MVC_DDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
			Mapper.CreateMap<Company, CompanyViewModel>();
			Mapper.CreateMap<Country, CountryViewModel>();
		}
    }
}