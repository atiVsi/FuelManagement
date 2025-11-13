using FuelManagement.Core.Convertors;
using FuelManagement.Core.Dtos.Pagination;
using FuelManagement.Core.Dtos.UserDto;
using FuelManagement.Core.Infrastructure;
using FuelManagement.Core.Services.Interface;
using FuelManagement.DataLayer.Context;
using FuelManagement.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelManagement.Core.Services
{
    public class UserService : RepositoryBase<long, User>, IUserService
    {
        private readonly FuelmanagementContext _context;

        public UserService(FuelmanagementContext context) : base(context)
        {
            _context = context;
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public User GetUserByNationalCode(string nationalCode)
        {
            return _context.Users.FirstOrDefault(x => x.NationalCodeField == nationalCode);
        }

        public List<UserViewModel> GetUsersVm(string fullName)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(fullName))
            {
                query = query.Where(x => (x.Firstname + " " + x.LastName).Contains(fullName));
            }

            return query.Select(x => new UserViewModel
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.Firstname,
                NationalCode = x.NationalCodeField,
                RegisteriDate = x.CreationDate,
                RegisteriDate_fa = x.CreationDate.ToShamsi(),
            }).ToList();
        }

        public PaginatedList<UserViewModel> GetUsersVmPaged(string fullName, int pageIndex, int pageSize)
        {
            var all = GetUsersVm(fullName);
            return PaginatedList<UserViewModel>.Create(all, pageIndex, pageSize);
        }

        public User AddUser(Profile profile)
        {
            var user = new User(
                userName: profile.userNameField,
                firstname: profile.firstNameField,
                lastName: profile.lastNameField,
                nationalCodeField: profile.nationalCodeField,
                mobilePhoneNumber: profile.mobileNumberField
            );

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id, string userLog)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Remove(userLog);
                _context.SaveChanges();
            }
        }

        public RoleToGiveUser GetRoleByUserId(long userId)
        {
            var user = _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new RoleToGiveUser
                {
                    UserId = u.Id,
                    Firstname = u.Firstname,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    NationalCodeField = u.NationalCodeField,
                    MobilePhoneNumber = u.MobilePhoneNumber,
                    //UserRoles = u.UserRoles.Select(ur => ur.RoleId).ToList()
                }).FirstOrDefault();

            return user;
        }

        public UserDetailViewModel GetUserProfileBy(string nationalCode)
        {
            return _context.Users
                .Where(u => u.NationalCodeField == nationalCode )
                .Select(u => new UserDetailViewModel
                {
                    UserId = u.Id,
                    Firstname = u.Firstname,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    NationalCodeField = u.NationalCodeField
                }).FirstOrDefault();
        }

        public UserDetailViewModel GetUserProfileBy(long id) => GetUserProfileById((int)id);

        public UserDetailViewModel GetUserProfileById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDetailViewModel
                {
                    UserId = u.Id,
                    Firstname = u.Firstname,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    NationalCodeField = u.NationalCodeField,
                    MobilePhoneNumber = u.MobilePhoneNumber,
                }).FirstOrDefault();
        }

        public bool GetExist(string nationalCodeField)
        {
            return _context.Users.Any(x => x.NationalCodeField == nationalCodeField);
        }
    }
}
