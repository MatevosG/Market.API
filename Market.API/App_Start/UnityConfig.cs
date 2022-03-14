using Market.BL.Contracts;
using Market.BL.Sevices;
using Market.Common.Contract;
using Market.Common.Health;
using Market.Common.Helpers;
using Market.DAL.Contracts;
using Market.DAL.Repositories;
using Unity;

namespace Market.API
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ILogger, SimpleLogger>();

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IAuthorizationService, AuthorizationService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ISellService, SellService>();
            container.RegisterType<IReportService, ReportService>(); 
            container.RegisterType<IHealthCheckProvider, DbHealthCheckProvider>(); 


            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ITransactinRepository, TransactionRepository>();
            container.RegisterType<ITransactionItemRepository, TransactionItemRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITokenRepository, TokenRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            return container;
        }
    }
}