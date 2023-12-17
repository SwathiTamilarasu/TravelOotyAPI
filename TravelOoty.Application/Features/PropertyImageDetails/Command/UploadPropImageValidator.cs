using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.PropertyImageDetails.Command
{
    public class UploadPropImageValidator: AbstractValidator<UploadPropImageCommand>
    {
        private readonly IPropertyImageRepository _roomImageRepository;
        public UploadPropImageValidator(IPropertyImageRepository roomImageRepository)
        {
            _roomImageRepository = roomImageRepository;
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Image name already exist");
        }
        private async Task<bool> EventNameUnique(UploadPropImageCommand e, CancellationToken cancellationToken)
        {
            return !(await _roomImageRepository.IsPropertyImageNameUnique(e.ImageName));
        }
    }
}
