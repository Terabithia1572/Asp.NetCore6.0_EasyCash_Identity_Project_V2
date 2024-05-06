using Microsoft.AspNetCore.Identity;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola En Az {length} Karakter Olmalıdır."

			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Lütfen En Az 1 Büyük Harf Giriniz.."
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Lütfen En Az Bir Küçük Harf Giriniz."
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Lütfen En az 1 rakam giriniz."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Lütfen bir sembol giriniz."
			};
		}
		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError()
			{
				Code = "InvalidEmail",
				Description = "Bilinmeyen E-Mail Adresi Girildi."
			};
		}
	}
}
