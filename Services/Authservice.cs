
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BookApi.Interfaces;
using BookApi.Model;
using Microsoft.IdentityModel.Tokens;
using ServiceStack;
using ServiceStack.Auth;

namespace BookApi.Services
{
    public class Authservice : IAuthservice
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepo;
        public Authservice(IConfiguration configuration, IUserRepository userRepo)
        {
            _configuration = configuration;
            _userRepo = userRepo;
        }

        public async Task<User> Authenticate(User user)
        {
            var filterParameters = new Dictionary<string, object>()
              {
                {nameof(User.UserName),user.UserName},
                {nameof(User.UserPassword),user.UserPassword}
              };

            var response = await _userRepo.QueryCollectionAsync(user, filterParameters);
            return response.FirstOrDefault();
        }

        public string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                        _configuration["Jwt:Audience"],
                                        null,
                                        expires: DateTime.Now.AddMinutes(60),
                                        signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> CreateNewUser(User user)
        {
            var response = await _userRepo.Add(user);
            return response;
        }
    }
}