using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı kısmı boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriği boş geçilemez!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog görseli boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az iki karakter girişi yapın!");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("En fazla elli karakter girişi yapın!");


        }
    }
}
