using Moq;
using PartyInvites.Models;
using PartyInvites.Controllers;
using Xunit;
using System.Linq;

namespace PartyInvites.Tests
{
    public class PartyInvitesTests
    {
        [Fact]
        public void Can_Shows_Correct_Response_Details()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Responses).Returns((new GuestResponse[] {
                new GuestResponse {ID = 1, Name = "name1", Email="email1", Phone="phone1", WillAttend=true},
                new GuestResponse {ID = 2, Name = "name2", Email="email2", Phone="phone2", WillAttend=true},
                new GuestResponse {ID = 3, Name = "name3", Email="email3", Phone="phone3", WillAttend=true},
                new GuestResponse {ID = 4, Name = "name4", Email="email4", Phone="phone4", WillAttend=true},
                new GuestResponse {ID = 5, Name = "name5", Email="email5", Phone="phone5", WillAttend=true}
            }).AsQueryable<GuestResponse>());
            HomeController controller = new HomeController(mock.Object);
            // Act
            GuestResponse result = controller.ShowResponseDetails(2).ViewData.Model as GuestResponse;
            // Assert
            Assert.Equal("name2", result.Name);
        }
    }
}
