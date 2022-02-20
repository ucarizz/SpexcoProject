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
       // Task<IDataResult<UserUpdateDto>> GetUserUpdateDto(int UserId);
        Task<IDataResult<UserListDto>> GetAll();
        Task<IDataResult<UserListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false);

        Task<IDataResult<UserListDto>> GetAllByNonDeleted();
        Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActive();
       // Task<IDataResult<UserDto>> Add(UserAddDto UserAddDto, string createdByName);
        //Task<IDataResult<UserDto>> Update(UserUpdateDto UserUpdateDto, string modifiedByName);
        Task<IDataResult<UserDto>> Delete(int UserId, string modifiedByName);
        Task<IResult> HardDelete(int UserId);

    }
 
}
