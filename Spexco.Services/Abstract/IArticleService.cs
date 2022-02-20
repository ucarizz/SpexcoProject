﻿using Spexco.Entities.Dtos;
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
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage=1,int pageSize=5, bool isAscending=false);
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);

        //Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);
        //Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        //Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);

    }
}