using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.DTOs;
using Application.Helpers;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Interfaces;

public class AuthService: IAuthService
{
    private readonly IUserRepository _repository;
    private readonly AppSettings _appSettings;

    public AuthService(IUserRepository repository,IOptions<AppSettings> appSettings)
    {
        _repository = repository;
        _appSettings = appSettings.Value;
    }

    public string Register(LoginAndRegisterDTO dto)
    {
        try
        {
            _repository.GetUserByUserName(dto.Username);
        }
        catch (KeyNotFoundException e)
        {
            var salt = RandomNumberGenerator.GetBytes(32).ToString();
            var user = new User
            {
                Username = dto.Username,
                Salt = salt,
                Hash = BCrypt.Net.BCrypt.HashPassword(dto.Password + salt)
            };
            _repository.CreateNewUser(user);
            return GenerateToken(user);
        }

        throw new Exception("Username - " + dto.Username + " is already taken");

    }

    public string Login(LoginAndRegisterDTO dto)
    {
        var user = _repository.GetUserByUserName(dto.Username);
        if (BCrypt.Net.BCrypt.Verify(dto.Password+user.Salt,user.Hash))
        {
            return GenerateToken(user);
        }

        throw new Exception("Invalid login");
    }

    private string GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []{new Claim("username",user.Username)}),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}