using System.Collections.Generic;
using RestAPI.Models.Data.Converters;
using RestAPI.Models;
using RestAPI.Models.Data.DTO;
using System.Linq;

namespace RestAPI.Models.Data.Converters
{
    public class UserConverter : IParser<UserDTO, User>, IParser<User, UserDTO>
    {
        public User Parse(UserDTO origin)
        {
            if (origin == null) return new User();
            return new User
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public UserDTO Parse(User origin)
        {
            if (origin == null) return new UserDTO();
            return new UserDTO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<User> ParseList(List<UserDTO> origin)
        {
            if (origin == null) return new List<User>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserDTO> ParseList(List<User> origin)
        {
            if (origin == null) return new List<UserDTO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
