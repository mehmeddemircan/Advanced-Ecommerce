using Advanced_Ecommerce.Entities.Dtos.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Validation.FluentValidation
{
    public class ModelValidator : AbstractValidator<ModelAddDto>
    {

        public ModelValidator()
        {
            RuleFor(x => x.ModelName).MinimumLength(2).WithMessage("Model ismi en az 2 karakter olmalıdır"); 
         
        }
    }
}
