using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Property.Command.CreateProperty
{
    public class CreatePropertyValidator: AbstractValidator<CreatePropertyCommand>
    {
        private readonly IPropertyRepository _propertyRepository;
        public CreatePropertyValidator(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            RuleFor(n => n.PropertierName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Hotel Category name already exist");
        }
        private async Task<bool> EventNameUnique(CreatePropertyCommand e, CancellationToken cancellationToken)
        {
            return !(await _propertyRepository.IsPropertyNameUnique(e.PropertierName));
        }
    }
}
