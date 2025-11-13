using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Infrastructure;
using FuelManagement.DataLayer.Entities.User;
using System.Collections.Generic;

namespace FuelManagement.Core.Services.Interface
{
    public interface IUserService : IRepository<long, User>
    {
        User GetUserByUserName(string userName);
        User GetUserByNationalCode(string nationalCode);
        List<UserViewModel> GetUsersVm(string fullName);
        PaginatedList<UserViewModel> GetUsersVmPaged(string fullName, int pageIndex, int pageSize);
        User AddUser(Profile profile);
        void UpdateUser(User user);
        void DeleteUser(int id, string userLog);
        RoleToGiveUser GetRoleByUserId(long userId); // اضافه شده
        UserDetailViewModel GetUserProfileBy(string nationalCode);
        UserDetailViewModel GetUserProfileBy(long id);
        UserDetailViewModel GetUserProfileById(int id);
        bool GetExist(string nationalCodeField);
    }
}
