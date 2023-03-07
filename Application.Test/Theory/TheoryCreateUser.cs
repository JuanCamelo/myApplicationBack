using ApplicationServices.DTOs.Models;
using Xunit;

namespace Application.Test.Theory
{
    public class TheoryCreateUser : TheoryData<UserModel, string>
    {
        public TheoryCreateUser() 
        {
            Add(new UserModel
            {
                Gmail = "test",
                Phone = 0,
                Position = "test",
                TypeContact = "tets",
                User = "test",
                UserName = "testName"
            }, "Succesfull!");
        }
    }
}
