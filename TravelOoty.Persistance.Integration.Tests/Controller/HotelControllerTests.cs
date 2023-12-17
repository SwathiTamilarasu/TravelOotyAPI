using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features;
using TravelOoty.Persistance.Integration.Tests.Base;
using Xunit;

namespace TravelOoty.API.Integration.Tests.Controller
{
    public class HotelControllerTests: IClassFixture<CustomWebApplicationFactory<Startup>> 
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public HotelControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/category/all");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HotelsListVM>>(responseString);
            Assert.IsType<List<HotelsListVM>>(result);
            Assert.NotEmpty(result);
        }
    }
}
