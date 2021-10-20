using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Models
{
    public class UserViewsModel
    {
        
    }

    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class UserCreateViewModel
    {
        [Required]
        [StringLength(10 /*ErrorMessage = "Kullanıcı Adınız 10 karakterden Fazla Olamaz."*/)]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }

    public class UserLoginViewModel
    {
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(10,MinimumLength = 4)]
        public string Password { get; set; }
    }
}
