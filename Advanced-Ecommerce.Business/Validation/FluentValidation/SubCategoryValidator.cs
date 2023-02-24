using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Validation.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategoryAddDto>
    {

        public SubCategoryValidator()
        {
            RuleFor(x => x.SubCategoryName).MinimumLength(2).WithMessage("SubCategory isim en az 2 karakter olmalıdir");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Herhangi bir category belirtin lütfen "); 
        }
    }
}
