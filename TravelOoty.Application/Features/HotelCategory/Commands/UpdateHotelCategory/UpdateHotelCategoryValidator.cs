using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities;

namespace TravelOoty.Application.Features.HotelCategory.Commands.UpdateHotelCategory
{
    public class UpdateHotelCategoryValidator: AbstractValidator<UpdateHotelCategoryCommand>
    {
        public UpdateHotelCategoryValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
        }
    }
}
