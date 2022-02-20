using AutoMapper;
using Spexco.Data.Abstract;
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
    public class UserManager : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;


        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<UserDto>> Get(int UserId)
        {
            throw new NotImplementedException();
        }


        public async Task<IDataResult<UserListDto>> GetAll(int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize>20 ? 20:pageSize;

            var users = await _unitOfWork.Users.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles);
            
            var sortedUsers = isAscending ?
                users.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() :
                users.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                {
                    Users = users,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = users.Count,
                    isAscending= isAscending,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<UserListDto>(ResultStatus.Error, "Kategori bulunamadı.", null);
        }
    }
}
