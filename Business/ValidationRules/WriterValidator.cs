using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az iki karakter girişi yapın!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla elli karakter girişi yapın!");

        }
    }
}
