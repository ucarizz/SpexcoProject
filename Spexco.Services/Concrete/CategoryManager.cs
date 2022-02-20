﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        //{
        //    var category = _mapper.Map<Category>(categoryAddDto);
        //    category.CreatedByName = createdByName;
        //    category.ModifiedByName = createdByName;
        //    var addedCategory = await _unitOfWork.Categorires.AddASync(category);
        //    //await _unitOfWork.Categorires.AddASync(new Category
        //    //{
        //    //    Name = categoryAddDto.Name,
        //    //    Description = categoryAddDto.Description,
        //    //    Note = categoryAddDto.Note,
        //    //    IsActive = categoryAddDto.IsActive,
        //    //    CreatedByName = createdByName,
        //    //    CreatedDate = DateTime.Now,
        //    //    ModifiedByName = createdByName,
        //    //    ModifiedDate = DateTime.Now,
        //    //    IsDeleted = false
        //    //});

        //    await _unitOfWork.SaveAsync();
        //    return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.", new CategoryDto
        //    {
        //        Category = addedCategory,
        //        ResultStatus = ResultStatus.Success,
        //        Message = $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir."
        //    });
        //}

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categorires.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {

                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await _unitOfWork.Categorires.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, $"{deletedCategory.Name} adlı kategori başarıyla güncellenmiştir.", new CategoryDto
                {

                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedCategory.Name} adlı kategori başarıyla güncellenmiştir."

                });

            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Success,
                Message = $"Böyle bir kategori bulunamadı."

            });
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

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categorires.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori bulunamadı.", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Kategori bulunamadı."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categorires.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kategori bulunamadı."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categorires.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByPagingAsync( int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var categories =  await _unitOfWork.Categorires.GetAllAsync(a => a.IsActive && !a.IsDeleted);

            var sortedCategories = isAscending ? categories.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() : categories.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
            {
                Categories = sortedCategories,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = categories.Count,
            });
        }

        //public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId)
        //{
        //    var result = await _unitOfWork.Categorires.AnyAsync(c => c.Id == categoryId);
        //    if (result)
        //    {
        //        var category = await _unitOfWork.Categorires.GetAsync(c => c.Id == categoryId);
        //        var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
        //        return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
        //    }
        //    else
        //    {
        //        return new DataResult<CategoryUpdateDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);

        //    }
        //}

        public async Task<IResult> HardDelete(int categoryId)
        {

            var category = await _unitOfWork.Categorires.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {

                await _unitOfWork.Categorires.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla veritabanından silinmiştir.");

            }
            return new Result(ResultStatus.Error, "Kategori bulunamadı.");
        }

        //public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        //{
        //    var oldCategory = await _unitOfWork.Categorires.GetAsync(c => c.Id == categoryUpdateDto.Id);
        //    var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
        //    category.ModifiedByName = modifiedByName;

        //    var updatedCategory = await _unitOfWork.Categorires.UpdateAsync(category);
        //    await _unitOfWork.SaveAsync();
        //    return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.", new CategoryDto
        //    {
        //        Category = updatedCategory,
        //        ResultStatus = ResultStatus.Success,
        //        Message = $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir."

        //    });
        //}
    }
}
