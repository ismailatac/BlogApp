using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır!");
            


        }
    }
}
