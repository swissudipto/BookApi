
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BookApi.Interfaces;
using BookApi.Model;
using Microsoft.IdentityModel.Tokens;
using ServiceStack;

namespace BookApi.Services
{
    public class Authservice : IAuthservice
    {
        private readonly IConfiguration _configuration;
        public Authservice(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> Authenticate(User user)
        {
            if (user.UserName == "string" && user.userPassword == "string")
            {
                return new User { UserName = user.UserName, userPassword = user.userPassword, UserEmail = "sbose562@gmail.com" };
            }
            return null;
        }

        public string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                        _configuration["Jwt:Audience"],
                                        null,
                                        expires: DateTime.Now.AddMinutes(1),
                                        signingCredentials: credentials);
            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}