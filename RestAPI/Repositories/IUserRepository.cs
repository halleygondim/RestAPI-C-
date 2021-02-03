using RestAPI.Models;
using System.Collections.Generic;

namespace RestAPI.Repositories
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
