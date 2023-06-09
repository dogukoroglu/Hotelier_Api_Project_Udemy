using FluentValidation;
using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.GuestDto;

namespace HotelierProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapınız.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapınız.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş geçilemez.")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapınız.");
        }
    }
}
