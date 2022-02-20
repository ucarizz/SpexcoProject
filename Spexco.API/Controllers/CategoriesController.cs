﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spexco.Entities.Concrete;
using Spexco.Services.Abstract;
using Spexco.Shared.Utilities.Result.ComplexTypes;
using Spexco.Shared.Utilities.Result.Concrete;

namespace Spexco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList(int currentPage = 1, int pageSize = 5)
        {
            var result = _categoryService.GetAllByPagingAsync( currentPage, pageSize);

            if (result.Result.ResultStatus == ResultStatus.Success )
            {
                return Ok(result.Result.Data);
            }
            else
            {
                return BadRequest(result.Result.Message);
            }
        }
    }
}