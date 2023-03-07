using Application.Test.Theory;
using ApplicationServices.DTOs.Models;
using ApplicationServices.DTOs.ViewModels;
using ApplicationServices.Services.Contract;
using Moq;
using WebApplicationApi.Controllers;
using Xunit;

namespace Application.Test.ControllerTests
{
    public class UserControllerTest
    {
        private readonly Mock<IUserApplicationServices> _userApplicationService;
        private UserController _userController;
        public UserControllerTest() 
        { 
            _userApplicationService= new Mock<IUserApplicationServices>();
            _userController = new UserController(_userApplicationService.Object);
        }

        [Fact]
        public async Task Get_User_Tests_Async()
        {
            //Arrange
            IEnumerable<UserViewModel> users = new List<UserViewModel>
            {
                new UserViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Gmail = "test@gmail.com",
                    Phone = 000,
                    Position = "test",
                    TypeContact= "test",
                    User = "test",
                    UserName= "test",

                }
            };
            _userApplicationService.Setup(c => c.GetUserAsync(It.IsAny<UserFilters>())).ReturnsAsync(users);

            //Act
            var result = await  _userController.GetUserAsync(new UserFilters());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(users.Count(), users.Count());

        }

        [Theory]
        [ClassData(typeof(TheoryCreateUser))]
        public async Task Post_User_Tests_Async(UserModel model, string response)
        {
            //Arrange
            
            _userApplicationService.Setup(c => c.PostUserAsync(It.IsAny<UserModel>())).ReturnsAsync(response);

            //Act
            var result = await _userController.PostUserAsync(model);

            //Assert
            try
            {
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, response);
            }
            

        }

        [Fact]
        public async Task ById_User_Tests_Async()
        {
            //Arrange
            UserViewModel users = new UserViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Gmail = "test@gmail.com",
                Phone = 000,
                Position = "test",
                TypeContact = "test",
                User = "test",
                UserName = "test",

            };
            
            _userApplicationService.Setup(c => c.GetByIdUserAsync(It.IsAny<string>())).ReturnsAsync(users);

            //Act
            var result = await _userController.GetByIdUserAsync("test");

            //Assert
            Assert.NotNull(result);
        }
    }
}
