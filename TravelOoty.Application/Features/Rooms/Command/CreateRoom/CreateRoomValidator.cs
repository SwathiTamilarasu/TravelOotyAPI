using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Rooms.Command.CreateRoom
{
    public class CreateRoomValidator: AbstractValidator<CreateRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        public CreateRoomValidator(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Room name already exist");
        }
        private async Task<bool> EventNameUnique(CreateRoomCommand e, CancellationToken cancellationToken)
        {
            return !(await _roomRepository.IsRoomNameUnique(e.Name));
        }
    }
}
