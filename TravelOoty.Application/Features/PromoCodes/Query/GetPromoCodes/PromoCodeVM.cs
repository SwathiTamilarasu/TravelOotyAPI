using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes
{
    public class PromoCodeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Discount { get; set; }
    }
}
