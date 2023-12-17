using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class PromoCodeRepository: BaseRepository<PromoCode>, IPromoCodeRepository
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> _promoCodeRepository;
        private readonly IMapper _mapper;
        public PromoCodeRepository(TravelOotyDbContext dbContext, IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> promoCodeRepository) : base(dbContext)
        {
            _mapper = mapper;
            _promoCodeRepository = promoCodeRepository;
        }
        public Task<string> IsPromoCodeValidReturnDiscount(string name)
        {
            var matches = _dbContext.PromoCodes.Any(n => n.Name.Equals(name) && n.ExpiryDate>DateTime.Now);
            if (!matches)
            {
                return Task.FromResult("Not Valid");
            }
            else
            {
                return Task.FromResult(_dbContext.PromoCodes.Where(e => e.Name == name).Select(x => x.Discount).FirstOrDefault().ToString());
            }
        }

    }
}
