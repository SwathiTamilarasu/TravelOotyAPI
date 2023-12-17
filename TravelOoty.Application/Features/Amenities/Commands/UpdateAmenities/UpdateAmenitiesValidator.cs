using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities
{
    public class UpdateAmenitiesValidator: AbstractValidator<UpdateAmenitiesCommand>
    {
       
        public UpdateAmenitiesValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
        }
        
    }
}
