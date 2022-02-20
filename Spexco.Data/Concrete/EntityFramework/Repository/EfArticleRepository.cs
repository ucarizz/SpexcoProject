using Microsoft.EntityFrameworkCore;
using Spexco.Data.Abstract;
using Spexco.Entities.Concrete;
using Spexco.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Data.Concrete.EntityFramework.Repository
{
    public class EfArticleRepository : EFEntityRepositoryBase<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {

        }
    }
}
