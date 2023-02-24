using Advanced_Ecommerce.Entities.Dtos.Color;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Validation.FluentValidation
{
    public class ColorValidator  : AbstractValidator<ColorAddDto>
    {

        public ColorValidator()
        {
            RuleFor(x => x.ColorName).MinimumLength(2).WithMessage("Renk ismi en az 2 karakter olmalıdır");
            RuleFor(x => x.HexaDecimalCode).Length(7).WithMessage("Gecersiz renk kodu giyildi");
        }
    }
}
