using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class MemoryRepository:IRepository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        private static int currentId = 0;

        public IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public void AddResponse(GuestResponse response)
        {
            response.ID = ++currentId;
            responses.Add(response);
        }

    }
}
