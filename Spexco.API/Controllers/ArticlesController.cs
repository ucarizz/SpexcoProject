using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spexco.Services.Abstract;
using Spexco.Shared.Utilities.Result.ComplexTypes;
using System.Threading.Tasks;

namespace Spexco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("getall")]
        public IActionResult GetList(int currentPage=1,int pageSize=5,bool isAscending=false)
        {
            var result =  _articleService.GetAll(null,currentPage,pageSize, isAscending);

            if (result.Result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Result.Message);
            }
        }
    }
}
