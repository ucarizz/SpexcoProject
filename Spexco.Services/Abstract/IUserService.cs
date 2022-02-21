using Spexco.Entities.Dtos;
using Spexco.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> Get(int UserId);
        Task<IDataResult<UserListDto>> GetAll( int currentPage = 1, int pageSize = 5, bool isAscending = false);
    }
 
}
