using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Models;

namespace PartyInvites.Models
{
    public class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        private static int currentId = 0;

        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            response.ID = ++currentId;
            responses.Add(response);
        }
    }
}
