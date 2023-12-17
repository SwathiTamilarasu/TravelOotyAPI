﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType
{
    public class UpdatePropertyTypeCommandValidator: AbstractValidator<UpdatePropertyTypeCommand>
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        public UpdatePropertyTypeCommandValidator(IPropertyTypeRepository propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Property Type name already exist");
        }
        private async Task<bool> EventNameUnique(UpdatePropertyTypeCommand e, CancellationToken cancellationToken)
        {
            return !(await _propertyTypeRepository.IsPropertyTypeNameUnique(e.Name));
        }
    }
}
