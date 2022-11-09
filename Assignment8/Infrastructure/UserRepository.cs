using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class UserRepository: IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public User GetUserByUserName(string username)
    {
        return _context.Users.FirstOrDefault(user => user.Username == username) ?? throw new KeyNotFoundException("No user found with following username - "+ username );
    }

    public User CreateNewUser(User user)
    {
        var createdUser = _context.Users.Add(user).Entity;
        _context.SaveChanges();
        return createdUser;

    }
}