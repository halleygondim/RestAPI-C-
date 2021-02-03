using RestAPI.Models.Data.DTO;

namespace RestAPI.Services
{
    public interface ILoginBusiness
    {
         object FindByLogin(UserDTO user);
    }
}
