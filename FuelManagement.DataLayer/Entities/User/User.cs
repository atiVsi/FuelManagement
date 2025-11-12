using System;
using System.ComponentModel.DataAnnotations;

namespace FuelManagement.DataLayer.Entities.User
{
    public class User : EntityBase
    {
        [Display(Name = "نام کاربری")]
        [Required, MaxLength(200), MinLength(3)]
        public string UserName { get; private set; }

        [Display(Name = "نام")]
        [MaxLength(200), MinLength(3)]
        public string Firstname { get; private set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200), MinLength(3)]
        public string LastName { get; private set; }

        [Display(Name = "کدملی")]
        [Required, MaxLength(10), MinLength(10)]
        public string NationalCodeField { get; private set; }

        [Display(Name = "شماره همراه")]
        [Required, MaxLength(13), MinLength(13)]
        public string MobilePhoneNumber { get; private set; }

        [Display(Name = "زمان تغییر")]
        public DateTime? EditTime { get; private set; }

        public User(string userName, string firstname, string lastName, string nationalCodeField, string mobilePhoneNumber)
        {
            UserName = userName;
            Firstname = firstname;
            LastName = lastName;
            NationalCodeField = nationalCodeField;
            MobilePhoneNumber = mobilePhoneNumber;
        }

        public void Edit(string userName, string firstname, string lastName, string nationalCodeField, string mobilePhoneNumber, string userLog)
        {
            UserName = userName;
            Firstname = firstname;
            LastName = lastName;
            NationalCodeField = nationalCodeField;
            MobilePhoneNumber = mobilePhoneNumber;
            EditTime = DateTime.Now;
            UserLog = userLog;
        }

        public void UpdateUserLog(string userLog)
        {
            EditTime = DateTime.Now;
            UserLog = userLog;
        }

        public void Remove(string userLog)
        {
            IsDelete = true;
            EditTime = DateTime.Now;
            UserLog = userLog;
        }
    }
}
