using Spexco.Entities.Concrete;
using Spexco.Entities.Dtos;
using Spexco.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll( int currentPage = 1, int pageSize = 5, bool isAscending = false);
    }
}
