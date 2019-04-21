using PartyInvites.Data;
using PartyInvites.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PartyInvitesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any responses.
            if (context.GuestResponses.Any())
            {
                return;   // DB has been seeded
            }

            var responses = new GuestResponse[]
            {
                new GuestResponse {Name = "name1", Email="email1", Phone="phone1", WillAttend=true},
                new GuestResponse {Name = "name2", Email="email2", Phone="phone2", WillAttend=true},
                new GuestResponse {Name = "name3", Email="email3", Phone="phone3", WillAttend=true},
                new GuestResponse {Name = "name4", Email="email4", Phone="phone4", WillAttend=true},
                new GuestResponse {Name = "name5", Email="email5", Phone="phone5", WillAttend=true}
            };
            foreach (GuestResponse r in responses)
            {
                context.GuestResponses.Add(r);
            }
            context.SaveChanges();
        }
    }
}