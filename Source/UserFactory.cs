using Source.Models;

namespace Source
{
    public class UserFactory
    {
        public static User CreateUser(string name, string email)
        {
            return new User
            {
                id = System.Guid.NewGuid().ToString(),
                Name = name,
                Email = email
            };
        }
    }
}
