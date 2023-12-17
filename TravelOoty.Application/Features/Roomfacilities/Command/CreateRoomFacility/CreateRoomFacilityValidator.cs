using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility
{
    public class CreateRoomFacilityValidator: AbstractValidator<CreateRoomFacilityCommand>
    {
        private readonly IRoomFacilityRepository _roomFacilityRepository;
        public CreateRoomFacilityValidator(IRoomFacilityRepository roomFacilityRepository)
        {
            _roomFacilityRepository = roomFacilityRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Hotel Category name already exist");
        }
        private async Task<bool> EventNameUnique(CreateRoomFacilityCommand e, CancellationToken cancellationToken)
        {
            return !(await _roomFacilityRepository.IsRoomFacilityNameUnique(e.Name));
        }
    }
}
