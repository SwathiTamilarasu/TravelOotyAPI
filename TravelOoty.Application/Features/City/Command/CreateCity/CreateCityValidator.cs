using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.City.Command.CreateCity
{
    public class CreateCityValidator: AbstractValidator<CreateCityCommand>
    {
        private readonly ICityRepository _cityRepository;
        public CreateCityValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{Name} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("City Name already exist");
        }
        private async Task<bool> EventNameUnique(CreateCityCommand e, CancellationToken cancellationToken)
        {
            return !(await _cityRepository.IsCityNameUnique(e.Name));
        }
    }
}
