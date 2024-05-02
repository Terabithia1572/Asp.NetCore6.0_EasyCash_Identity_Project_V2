using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DTOLayer.DTOS.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
        //[Required(ErrorMessage ="Ad Kısmı Boş Geçilemez..")]
        //[Display(Name="İsim: ")]
        //[MaxLength(30,ErrorMessage ="İsim Kısmı Maximum 30 karakter olmalıdır")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
} //ad,soyad,username,mail,password,confirmpassword'e ihtiyacımız olacak
