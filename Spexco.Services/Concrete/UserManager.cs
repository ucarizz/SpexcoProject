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
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IDataResult<UserDto>> Delete(int UserId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UserDto>> Get(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UserListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UserListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<UserListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var users = await _unitOfWork.Users.GetAllAsync(null,c => !c.IsDeleted && c.IsActive, c => c.Articles);
            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                {
                    Users = users,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<UserListDto>(ResultStatus.Error, "Kategori bulunamadı.", null);
        }

        public Task<IResult> HardDelete(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
