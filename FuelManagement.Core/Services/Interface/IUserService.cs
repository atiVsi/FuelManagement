using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Dtos.UserDto;
//using FuelManagement.Core.Infrastructure;
using FuelManagement.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FuelManagement.Core.Services.Interface
{
    public interface IUserService :IRepository<long,User>
    {
        // گرفتن اطلاعات با نام کاربری
        User GetUserByUserName(string userName);
       
        // گرفتن اطلاعات با کد ملی
        User GetUserByNationalCode(string nationalCode);
        List<UserViewModel> GetUsersVm(string fullName);
        //User AddUser(Profile profile);

        // گرفتن اطلاعات کاربر توسط سرویس cas
        //User GetUserByNationalCodeInCast(string nationalCode);
        
        //به روز رسانی اطلاعات کاربر
        void UpdateUser(User user);

        // حذف کاربر
        void DeleteUser(int id, string userLog);
        //User CheckUpdateUser(Profile user);
        RoleToGiveUser GetRoleByUserId(long userId);
        //UserDetailViewModel GetUserProfileBy(string nationalCode);
        //UserDetailViewModel GetUserProfileBy(long id);
        //UserDetailViewModel GetUserProfileById(int id);
        // حذف کاربر با آیدی 
        // void DeleteDependentById(long id);

        // کاربر وجود دارد یا خیر
        bool GetExist(string nationalCodeField);


        // برای گرفتن لیست کاربران نوشته شده 
        public PaginatedList<UserViewModel> GetUsersVmPaged(string fullName, int pageIndex, int pageSize);
    }
}
