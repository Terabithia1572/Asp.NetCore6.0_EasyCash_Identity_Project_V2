using EasyCashIdentityProject.DTOLayer.DTOS.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez..");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Kısmı Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Kısmı Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Kısmı Boş Geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Kısmı Boş Geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen En Fazla 30 Karakter Girişi Yapınız..");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız..");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalarınız Eşleşmiyor..");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz..");

        }
    }
}
