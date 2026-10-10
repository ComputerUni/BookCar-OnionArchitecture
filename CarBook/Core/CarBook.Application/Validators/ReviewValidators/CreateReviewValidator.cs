using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyiniz.");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Veri Girişi Yapınız.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Lütfen Puan Değerini Boş Geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum Değerini Boş Geçmeyiniz.");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen Yorum Değerinde En Az 50 Karakter Kullanınız.");
            RuleFor(x => x.Comment).MaximumLength(509).WithMessage("Lütfen Yorum Değerinde En Fazla 500 Karakter Kullanınız.");
        }
    }
}
