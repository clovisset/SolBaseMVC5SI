using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC_DDD.Application.Interface;
using MVC_DDD.Application;
using MVC_DDD.Domain.Interfaces.Repositories;
using MVC_DDD.Domain.Interfaces.Services;
using MVC_DDD.Domain.Services;
using MVC_DDD.Infra.Data.Repositories;
using MVC_DDD.MVC.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace MVC_DDD.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
			container.Register<ICompanyAppService, CompanyAppService>(Lifestyle.Scoped);
			container.Register<ICountryAppService, CountryAppService>(Lifestyle.Scoped);

			container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
			container.Register<ICompanyService, CompanyService>(Lifestyle.Scoped);
			container.Register<ICountryService, CountryService>(Lifestyle.Scoped);

			container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);
			container.Register<ICountryRepository, CountryRepository>(Lifestyle.Scoped);

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			//  Container.Register(typeof(ILogger<>), typeof(LoggingAdapter<>));

		}
	}
}
