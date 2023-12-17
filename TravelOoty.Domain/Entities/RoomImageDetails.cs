using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class RoomImageDetails: AuditableEntity
    {
        public int Id { get; set; }
        public int  RoomId { get; set; }
        public Rooms Room { get; set; }    
        public string ImageName { get; set; }
        public string ImagePath { get;set; }
       
    }

}
