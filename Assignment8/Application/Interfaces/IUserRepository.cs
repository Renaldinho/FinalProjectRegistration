using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public User GetUserByUserName(string username);

    public User CreateNewUser(User user);
}