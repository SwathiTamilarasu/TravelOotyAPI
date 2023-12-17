using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Amenities.Commands.CreateAmenities
{
    public class CreateAmenitiesCommandValidator: AbstractValidator<CreateAmenitiesCommand>
    {
        private readonly IAmenitiesRepository _amenitiesRepository;
        public CreateAmenitiesCommandValidator(IAmenitiesRepository propertyTypeRepository)
        {
            _amenitiesRepository = propertyTypeRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Amenities name already exist");
        }
        private async Task<bool> EventNameUnique(CreateAmenitiesCommand e, CancellationToken cancellationToken)
        {
            return !(await _amenitiesRepository.IsPropertyTypeNameUnique(e.Name));
        }
    }
}
