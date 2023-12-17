using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory
{
    public class CreateRoomCategoryCommandValidator: AbstractValidator<CreateRoomCategoryCommand>
    {
        private readonly IRoomCategoryRepository _roomCategoryRepository;
        public CreateRoomCategoryCommandValidator(IRoomCategoryRepository hotelCategoryRepository)
        {
            _roomCategoryRepository = hotelCategoryRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Hotel Category name already exist");
        }
        private async Task<bool> EventNameUnique(CreateRoomCategoryCommand e, CancellationToken cancellationToken)
        {
            return !(await _roomCategoryRepository.IsNameUnique(e.Name));
        }
    }
}
