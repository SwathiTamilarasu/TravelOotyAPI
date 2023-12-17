using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Command.UpdateRoom
{
    public class UpdateRoomValidator:AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{RoomName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{RoomName} must not exceed 150 characters.");
        }

    }
}
