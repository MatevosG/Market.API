using System.Web.Http;
using Unity.WebApi;

namespace Market.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            #region New Unity Dependecy logic 
            GlobalConfiguration.Configuration.DependencyResolver  = new UnityDependencyResolver(UnityConfig.RegisterComponents());
            #endregion

            #region Old Autofac dependency logic
            //var builder = new ContainerBuilder();

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<CategoryService>().As<ICategoryService>();
            //builder.RegisterType<SellService>().As<ISellService>();
            //builder.RegisterType<ReportService>().As<IReportService>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<SimpleLogger>().As<ILogger>();
            //builder.RegisterType<TransactionRepository>().As<ITransactinRepository>();
            //builder.RegisterType<ProductRepository>().As<IProductRepository>(); 
            //builder.RegisterType<TransactionItemRepository>().As<ITransactionItemRepository>(); 
            //builder.RegisterType<UserRepository>().As<IUserRepository>(); 
            //builder.RegisterType<UserService>().As<IUserService>(); 
            //builder.RegisterType<TokenRepository>().As<ITokenRepository>();
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            //builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();

            //var continer = builder.Build();

            //var resolver = new AutofacWebApiDependencyResolver(continer);

            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
            #endregion
        }
    }
}
