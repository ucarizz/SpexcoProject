using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Spexco.Data.Abstract;
using Spexco.Data.Concrete;
using Spexco.Data.Concrete.EntityFramework.Contexts;
using Spexco.Services.Abstract;
using Spexco.Services.Concrete;

namespace Spexco.Services.Extensions
{
    public static class ServicesCollectionExtencions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            return serviceCollection;
        }
    }
}
