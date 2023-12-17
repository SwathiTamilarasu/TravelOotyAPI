using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility
{
    public class UpdateRoomFacilityValidator: AbstractValidator<UpdateRoomFacilityCommand>
    {
        public UpdateRoomFacilityValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
        }
    }
}
