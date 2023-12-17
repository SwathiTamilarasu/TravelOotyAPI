using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandValidator:AbstractValidator<CreateHotelCommand>
    {
        private readonly IHotelRepository _hotelRepository;
        public CreateHotelCommandValidator(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
            RuleFor(n => n.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(n => n).MustAsync(EventNameUnique).WithMessage("Hotel name already exist");
        }
        private async Task<bool> EventNameUnique(CreateHotelCommand e,CancellationToken cancellationToken)
        {
            return !(await _hotelRepository.IsHotelNameUnique(e.Name));
        }
    }
}
