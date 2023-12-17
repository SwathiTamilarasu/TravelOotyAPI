using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomCategory.Command.UpdateRoomCategory
{
    public class UpdateRoomCategoryValidator : AbstractValidator<UpdateRoomCategoryCommand>
    {
        public UpdateRoomCategoryValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
        }
    }
}
