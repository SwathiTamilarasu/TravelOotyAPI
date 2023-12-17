using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Entities;
using Xunit;
using Shouldly;
using Moq;
using Microsoft.EntityFrameworkCore;
using TravelOoty.Application.Contracts;

namespace TravelOoty.Persistance.IntegrationTests
{
    public class TravelOotyDbContextTests
    {
        private readonly TravelOotyDbContext _travelOotyDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TravelOotyDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TravelOotyDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _travelOotyDbContext = new TravelOotyDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Hotel() { HotelId = Guid.NewGuid(), Name = "Test hotel" };

            _travelOotyDbContext.Hotels.Add(ev);
            await _travelOotyDbContext.SaveChangesAsync();

            ev.Name.ShouldBe(_loggedInUserId);
        }

    }
}
