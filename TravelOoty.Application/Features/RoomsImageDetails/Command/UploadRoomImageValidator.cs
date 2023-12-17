using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.RoomsImageDetails.Command
{
    internal class UploadRoomImageValidator: AbstractValidator<UploadRoomImageCommand>
    {
        private readonly IRoomImageRepository _roomImageRepository;
        public UploadRoomImageValidator(IRoomImageRepository roomImageRepository)
        {
            _roomImageRepository = roomImageRepository;
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Image name already exist");
        }
        private async Task<bool> EventNameUnique(UploadRoomImageCommand e, CancellationToken cancellationToken)
        {
            return !(await _roomImageRepository.IsRoomImageNameUnique(e.ImageName));
        }
    }
}
