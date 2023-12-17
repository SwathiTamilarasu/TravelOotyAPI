using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory
{
    public class CreateHotelCategoryCommandValidator : AbstractValidator<CreateHotelCategoryCommand>
    {
        private readonly IHotelCategoryRepository _hotelCategoryRepository;
        public CreateHotelCategoryCommandValidator(IHotelCategoryRepository hotelCategoryRepository)
        {
            _hotelCategoryRepository = hotelCategoryRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Hotel Category name already exist");
        }
        private async Task<bool> EventNameUnique(CreateHotelCategoryCommand e, CancellationToken cancellationToken)
        {
            return !(await _hotelCategoryRepository.IsHotelNameUnique(e.Name));
        }
    }
}
