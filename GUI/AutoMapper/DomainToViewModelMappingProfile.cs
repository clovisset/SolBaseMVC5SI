
using AutoMapper;
using MVC_DDD.Domain.Entities;
using MVC_DDD.MVC.ViewModels;

namespace MVC_DDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
			Mapper.CreateMap<CompanyViewModel, Company>();
			Mapper.CreateMap<CountryViewModel, Country>();
		}
    }
}