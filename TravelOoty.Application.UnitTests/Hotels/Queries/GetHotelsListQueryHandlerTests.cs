using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using Moq;
using TravelOoty.Domain.Entities;
using TravelOoty.Application.UnitTests.Mocks;
using TravelOoty.Application.Profiles;
using Xunit;
using TravelOoty.Application.Features;
using System.Threading;
using Shouldly;

namespace TravelOoty.Application.UnitTests.Hotels.Queries
{
    public class GetHotelsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRespository<Hotel>> _mockHotelRepository;

        public GetHotelsListQueryHandlerTests()
        {
            _mockHotelRepository = RespositoryMocks.GetHotelRepository();
            var configurationProvider= new MapperConfiguration(cfg=> cfg.AddProfile<MappingProfile>());
            _mapper=configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task GetHotelListTest()
        {
            var handler = new GetHotelsListQueryHandler(_mapper, _mockHotelRepository.Object);
            var result = await handler.Handle(new GetHotelsListQuery(), CancellationToken.None);
           
            result.Count.ShouldBe(1);
        }
    }
}
