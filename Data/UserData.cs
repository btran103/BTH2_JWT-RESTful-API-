using JwtApi.Models;

namespace JwtApi.Data
{
    public static class UserData
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                IdUser = 1,
                UserName = "admin",
                Password = "123456",
                Token = ""
            },

            new User
            {
                IdUser = 2,
                UserName = "user",
                Password = "123456",
                Token = ""
            }
        };
    }
}