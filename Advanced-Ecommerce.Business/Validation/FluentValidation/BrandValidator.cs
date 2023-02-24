using Advanced_Ecommerce.Entities.Dtos.Brand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Validation.FluentValidation
{
    public class BrandValidator : AbstractValidator<BrandAddDto>
    {

        public BrandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Gecersiz uzunlukta bir isim girdiniz tekrar deneyiniz ");
            RuleFor(x => x.Description).Length(1, 50).WithMessage("Açıklama 1 - 50 arasında bir uzunlukta olmalıdır");
            
        }
    }
}
