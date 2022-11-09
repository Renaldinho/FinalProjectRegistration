using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthService
{
    public string Register(LoginAndRegisterDTO dto);
    public string Login(LoginAndRegisterDTO dto);
}
    