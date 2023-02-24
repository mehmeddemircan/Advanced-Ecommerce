using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Validation.FluentValidation
{
    public class CategoryValidator  : AbstractValidator<CategoryAddDto>
    {

        public CategoryValidator()
        {

            RuleFor(x=>x.CategoryName).MinimumLength(2).WithMessage("Isım en az 2 karakter olmalı");

            
        }
    }
}
