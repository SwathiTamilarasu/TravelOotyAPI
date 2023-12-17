using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.UnitTests.Mocks
{
    public static class RespositoryMocks
    {
        public static Mock<IAsyncRespository<Hotel>> GetHotelRepository()
        {
            var concertGuid = Guid.Parse("{12345678-ABCD-12AB-98AD-ABCDF1234512}");
            var hotels = new List<Hotel>{
                new Hotel{HotelId = concertGuid, Name="Gowtham"}
            };
            var mockHotelRepository= new Mock<IAsyncRespository<Hotel>>();
            mockHotelRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(hotels);
            mockHotelRepository.Setup(repo => repo.AddAsync(It.IsAny<Hotel>())).ReturnsAsync(
                (Hotel hotel) => {
                 hotels.Add(hotel);
                return hotel;
                });
            return mockHotelRepository;
        }
    }
}
