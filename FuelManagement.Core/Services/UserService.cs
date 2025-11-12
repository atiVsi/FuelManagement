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
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FuelManagement.Core.Services;
public class UserService : RepositoryBase<long, User>, IUserService
{
    private readonly FuelmanagementContext _context;



        public UserService(FuelmanagementContext context) : base(context)
    {
        _context = context;
    }


    // برو سراغ دیتا بیس خودمون و بررسی کن این کدملی وجود داره یا نه اگر بود اطلاعات رو بده
    public User GetUserByUserName(string userName)
    {
        return null;
        //return _context.Users.FirstOrDefault(x => x.UserName == userName);
    }



    public User GetUserByNationalCode(string nationalCode)
    {
        return null;
        // پیدا کردن اطلاعات کاربر توسط کد ملی از دیتا بیس خودمون
        //return _context.Users.FirstOrDefault(x => x.NationalCodeField == nationalCode);

    }
    public List<UserViewModel> GetUsersVm(string fullName)
    {
        //return null;
        IQueryable<User> user = _context.Users;

        if (fullName != null)
        {
            user = user.Where(x => (x.Firstname + " " + x.LastName).Contains(fullName));
        }
        return user.Select(x => new UserViewModel
        {
            Id = x.Id,
            LastName = x.LastName,
            FirstName = x.Firstname,
            NationalCode = x.NationalCodeField,
            RegisteriDate = x.CreationDate,
            RegisteriDate_fa = x.CreationDate.ToShamsi(),
        }).ToList();
    }

    public User AddUser(Profile profile)
    {
        Console.WriteLine("Reached AddUser");
        User user = new User(
            userName: Convert.ToString(profile.userNameField),
            firstname: Convert.ToString(profile.firstNameField),
            lastName: Convert.ToString(profile.lastNameField),
            nationalCodeField: Convert.ToString(profile.nationalCodeField),
            mobilePhoneNumber: Convert.ToString(profile.mobileNumberField)
        );
        //Create(user);
        //SaveChanges();
        _context.Users.Add(user);  // اضافه کردن به DbSet
        _context.SaveChanges();    // ثبت تغییرات در دیتابیس

        return user;
    }

    public void UpdateUser(User user)
    {

        //user.Edit(user.UserName, user.Firstname, user.LastName
        //    , user.NationalCodeField, user.MobilePhoneNumber,user.EditTime, user.UserLog);
        //SaveChanges();
    }
    public void DeleteUser(int id, string userLog)
    {
     
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user != null)
        {
            user.Remove(userLog);
            SaveChanges();
        }
    }
    //public User CheckUpdateUser(Profile user)
    //{
        //return null;

        //var query = _context.Users
        //    .Include(a => a.UserAvatar)
        //    .Where(u => u.NationalCodeField == user.nationalCodeField);


        //var oldUser = query.Select(x => new Profile()
        //{
        //    mobileNumberField = x.MobilePhoneNumber,
        //    nationalCodeField = x.NationalCodeField,
        //    birthDateField = x.BirthDate,
        //    firstNameField = x.Firstname,
        //    postalField = x.PostalCode,
        //    userNameField = x.UserName,
        //    lastNameField = x.LastName,
        //    addressField = x.Address,
        //    emailField = x.Email,
        //    isEmployeeField = x.IsEmployeeField,
        //    PersonalCode = x.PersonalCode,
        //    ProvinceName = x.ProvinceName,
        //    FatherName = x.FatherName,
        //    CreditNumber = x.CreditNumber,
        //    EmployeeDate = x.EmployeeDate,
        //    JobState_1 = x.JobState_1,
        //    Sex = x.Sex,
        //    ContractName = x.ContractName,


        //    avatarField = new AvatarField()
        //    {
        //        smallField = x.UserAvatar.smallField,
        //        largeField = x.UserAvatar.largeField,
        //        mediumField = x.UserAvatar.mediumField,
        //        masterField = x.UserAvatar.masterField,
        //        tinyField = x.UserAvatar.tinyField,
        //    }
        //})
        //    .FirstOrDefault();

        //if (oldUser == null || IsUserDifferent(user, oldUser))
        //{
        //    var newUser = new User(Convert.ToString(user.PersonalCode), user.userNameField,
        //        Convert.ToString(user.firstNameField), user.lastNameField, user.nationalCodeField,
        //        Convert.ToString(user.postalField), user.mobileNumberField, user.emailField,
        //        Convert.ToString(user.addressField), Convert.ToString(user.birthDateField),
        //        user.isEmployeeField, Convert.ToString(user.ProvinceName), Convert.ToString(user.FatherName),
        //        Convert.ToString(user.JobState_1), Convert.ToString(user.CreditNumber), Convert.ToString(user.Sex),
        //        Convert.ToString(user.EmployeeDate), Convert.ToString(user.ContractName), user.sumSalary, user.postName, user.contractBy, user.contractByTitle);

        //    UpdateUser(newUser);

        //    var avatar = new UserAvatar(user.avatarField.tinyField,
        //        user.avatarField.smallField, user.avatarField.mediumField,
        //        user.avatarField.largeField, user.avatarField.masterField, query.First().Id);
        //    _context.UserAvatars.Add(avatar);
        //    SaveChanges();

        //    return newUser;
        //}

        //return query.First();
    //}


    // ایدی کاربر رو بگیر و بهش نقش بده
    public RoleToGiveUser GetRoleByUserId(long userId)
    {
        return null;
        //return _context.Users
        //    .Include(u => u.UserRoles)
        //    .Where(u => u.Id == userId)
        //    .Select(x =>
        //        new RoleToGiveUser
        //        {
        //            UserId = x.Id,
        //            Firstname = x.Firstname,
        //            LastName = x.LastName,
        //            UserName = x.UserName,
        //            PersonalCode = x.PersonalCode,
        //            ProvinceName = x.ProvinceName,
        //            NationalCodeField = x.NationalCodeField,
        //            MobilePhoneNumber = x.MobilePhoneNumber,
        //            UserRoles = x.UserRoles
        //                .Where(u => u.UserId == u.UserId)
        //                .Select(u => u.Role)
        //                .Select(c => c.Id)
        //                .ToList(),
        //        }).FirstOrDefault();
    }
    public UserDetailViewModel GetUserProfileBy(string nationalCode)
    {
        return null;
        //return _context.Users
        //    .Include(x => x.UserAvatar)
        //    // .Include(u => u.Dependents)
        //    .Where(u => u.NationalCodeField == nationalCode || u.PersonalCode == nationalCode)
        //    .Select(x =>
        //    new UserDetailViewModel()
        //    {
        //        UserId = x.Id,
        //        Firstname = x.Firstname,
        //        LastName = x.LastName,
        //        UserName = x.UserName,
        //        PersonalCode = x.PersonalCode,
        //        NationalCodeField = x.NationalCodeField,
        //        BirthDate = x.BirthDate,
        //        FatherName = x.FatherName,
        //        ProvinceName = x.ProvinceName,
        //        MobilePhoneNumber = x.MobilePhoneNumber,
        //        PostalCode = x.PostalCode,
        //        Email = x.Email,
        //        Address = x.Address,
        //        UserAvatar = x.UserAvatar.mediumField,
        //        CreditNumber = x.CreditNumber,
        //        EmployeeDate = x.EmployeeDate,
        //        JobState_1 = x.JobState_1,
        //        Sex = x.Sex,
        //        ContractName = x.ContractName,


        //    }).FirstOrDefault();
    }

    public UserDetailViewModel GetUserProfileBy(long id)
    {
        return null;
        //return _context.Users
        //    .Include(x => x.UserAvatar)
        //    //.Include(u => u.Dependents)
        //    .Where(u => u.Id == id)
        //    .Select(x => new UserDetailViewModel
        //    {
        //        UserId = x.Id,
        //        Firstname = x.Firstname,
        //        LastName = x.LastName,
        //        UserName = x.UserName,
        //        PersonalCode = x.PersonalCode,
        //        NationalCodeField = x.NationalCodeField,
        //        BirthDate = x.BirthDate,
        //        FatherName = x.FatherName,
        //        ProvinceName = x.ProvinceName,
        //        MobilePhoneNumber = x.MobilePhoneNumber,
        //        PostalCode = x.PostalCode,
        //        Email = x.Email,
        //        Address = x.Address,
        //        UserAvatar = x.UserAvatar.mediumField,
        //        CreditNumber = x.CreditNumber,
        //        EmployeeDate = x.EmployeeDate,
        //        JobState_1 = x.JobState_1,
        //        Sex = x.Sex,
        //        ContractName = x.ContractName,


        //    }).FirstOrDefault();
    }


    public UserDetailViewModel GetUserProfileById(int id)
    {
        return null;
        //return _context.Users
        //    .Include(x => x.UserAvatar)
        //    //.Include(u => u.Dependents)
        //    .Where(u => u.Id == id)
        //    .Select(x => new UserDetailViewModel
        //    {
        //        UserId = x.Id,
        //        Firstname = x.Firstname,
        //        LastName = x.LastName,
        //        UserName = x.UserName,
        //        PersonalCode = x.PersonalCode,
        //        NationalCodeField = x.NationalCodeField,
        //        BirthDate = x.BirthDate,
        //        FatherName = x.FatherName,
        //        ProvinceName = x.ProvinceName,
        //        MobilePhoneNumber = x.MobilePhoneNumber,
        //        PostalCode = x.PostalCode,
        //        Email = x.Email,
        //        Address = x.Address,
        //        UserAvatar = x.UserAvatar.mediumField,
        //        CreditNumber = x.CreditNumber,
        //        EmployeeDate = x.EmployeeDate,
        //        JobState_1 = x.JobState_1,
        //        Sex = x.Sex,
        //        ContractName = x.ContractName,


        //    }).FirstOrDefault();
    }


    public bool GetExist(string nationalCodeField)
    {
        return true;
        // کد ملی کاربر رو بگیر و برو تو دیتا بیس بررسی کن
        //return _context.Users.Any(x => x.NationalCodeField == nationalCodeField);
    }



    //برای گرفتن لیست کاربران و دریافت فیلترها
    public PaginatedList<UserViewModel> GetUsersVmPaged(string fullName, int pageIndex, int pageSize)
    {
        //return null;
        var all = GetUsersVm(fullName); // لیست کامل پس از فیلتر
        return PaginatedList<UserViewModel>.Create(all, pageIndex, pageSize);
    }

   
}
