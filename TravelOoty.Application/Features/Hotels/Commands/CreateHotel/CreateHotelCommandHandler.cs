using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Models.Mail;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.Hotels.Commands.CreateHotel
{
    public  class CreateHotelCommandHandler:IRequestHandler<CreateHotelCommand, CreateHotelCommandResponse>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateHotelCommandHandler> _logger;
        public CreateHotelCommandHandler(IMapper mapper,IHotelRepository hotelRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _emailService = emailService;
        }
        public async Task<CreateHotelCommandResponse> Handle(CreateHotelCommand request,CancellationToken cancellationToken)
        {
            var createHotelCommandResponse = new CreateHotelCommandResponse();

            var validator = new CreateHotelCommandValidator(_hotelRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count>0)
            {
                createHotelCommandResponse.Success = false;
                createHotelCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createHotelCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
               
            }
            if(createHotelCommandResponse.Success)
            {
                var @hotel = _mapper.Map<Hotel>(request);
                @hotel = await _hotelRepository.AddAsync(@hotel);
                createHotelCommandResponse.Hotel = _mapper.Map<CreateHotelDto>(@hotel);
                var email = new Email() { To = "gowthamk91@outlook.com", Body = $"New Hotel {request}", Subject = "New Hotel Added" };
                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Mailing about event {@hotel.Name} failed due to an error with the mail service: {ex.Message}");
                }
            }                     
            return createHotelCommandResponse;
        }

    }
}
