using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable//?IDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categorires { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
