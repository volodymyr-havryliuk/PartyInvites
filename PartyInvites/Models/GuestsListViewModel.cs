using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestsListViewModel
    {
        public IEnumerable<GuestResponse> GuestResponses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
