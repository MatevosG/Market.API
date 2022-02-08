using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Linq;

namespace Market.BL.Sevices
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUserRepository _userRepository ;
        private ITokenRepository _tokenRepository ;
        public AuthorizationService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }
        public User TryGetUser(User user)
        {
            return _userRepository.Get().FirstOrDefault(x=>string.Equals(x.Name,user.Name)&&string.Equals(x.Password,user.Password));
        }
        public string CreateToken(User user)
        {
            var token =_tokenRepository.Add(new Token
            {
                Tokens = Guid.NewGuid().ToString(),
                UserId = user.Id,
                CreationTime = DateTime.UtcNow,
                ExpirationTime = DateTime.UtcNow.AddHours(5),
                User=user
            });
            return token.Tokens;
        }
    }
}
