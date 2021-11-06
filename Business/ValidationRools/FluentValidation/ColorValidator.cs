using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using FluentValidation;
using Color = Entities.Concrete.Color;

namespace Business.ValidationRools.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(co => co.ColorName).MinimumLength(2).WithMessage("Renk Adı Minimum 2 Harfli Olmalıdır.");
        }
    }
}
