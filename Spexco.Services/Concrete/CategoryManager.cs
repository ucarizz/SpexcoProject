using AutoMapper;
using Spexco.Data.Abstract;
using Spexco.Entities.Concrete;
using Spexco.Entities.Dtos;
using Spexco.Services.Abstract;
using Spexco.Shared.Utilities.Result.Abstract;
using Spexco.Shared.Utilities.Result.ComplexTypes;
using Spexco.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
   

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categorires.GetAsync(c => c.Id == categoryId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Kategori bulunamadı.", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "Kategori bulunamadı."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll( int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var categories =  await _unitOfWork.Categorires.GetAllAsync(a => a.IsActive && !a.IsDeleted);
  
            var sortedCategories = isAscending ? 
                categories.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() : 
                categories.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
            {
                Categories = sortedCategories,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = categories.Count,
                isAscending = isAscending,
                ResultStatus = ResultStatus.Success

            });
        }
      
    }
}
