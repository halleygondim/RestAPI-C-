using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using RestAPI.Models.Context;
using System.Linq;

namespace RestAPI.Repositories
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly OracleContext _context;

        // Declaração de um dataset genérico
        private DbSet<User> dataset;
 

        public UserRepositoryImpl(OracleContext context)
        {
            _context = context;
            dataset = _context.Set<User>();
        }

        public User FindByLogin(string login)
        {

            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
