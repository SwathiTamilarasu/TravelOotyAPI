using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentDetails>, IPaymentRepository
    {
        public PaymentRepository(TravelOotyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
