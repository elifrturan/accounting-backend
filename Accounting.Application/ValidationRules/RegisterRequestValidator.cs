using Accounting.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.ValidationRules
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();

            RuleFor(x => x.FullName).NotEmpty();

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .Matches("[A-Za-z]").WithMessage("En az 1 harf içermeli.")
                .Matches("[0-9]").WithMessage("En az 1 sayı içermeli.")
                .Matches("[^a-zA-Z0-9]").WithMessage("En az 1 sembol içermeli");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor.");

            RuleFor(x => x.AcceptTerms).Equal(true).WithMessage("Kullanım koşulları kabul edilmelidir.");
        }
    }
}
