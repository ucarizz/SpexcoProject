using Spexco.Entities.Dtos;
using Spexco.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll(int? categoryId, int currentPage=1,int pageSize=5, bool isAscending=false);

    }
}
