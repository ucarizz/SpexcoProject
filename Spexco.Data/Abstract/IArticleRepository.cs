using Spexco.Entities.Concrete;
using Spexco.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
    }
}
