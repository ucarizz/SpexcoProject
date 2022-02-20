﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spexco.Services.Abstract;
using Spexco.Shared.Utilities.Result.ComplexTypes;

namespace Spexco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetList(int currentPage = 1, int pageSize = 5)
        {
            var result = _userService.GetAllByPagingAsync(currentPage, pageSize);

            if (result.Result.ResultStatus == ResultStatus.Success)
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