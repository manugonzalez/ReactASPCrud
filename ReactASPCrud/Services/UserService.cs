using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReactASPCrud.Helpers;
using ReactASPCrud.Models;
using ReactASPCrud.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ReactASPCrud.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// App settings
        /// [Injected]
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Generic repository.
        /// [Injected]
        /// </summary>
        private IGenericRepository<User> repository;

        //Injection configuration
        public UserService(IOptions<AppSettings> appSettings, IGenericRepository<User> repository)
        {
            this._appSettings = appSettings.Value;
            this.repository = repository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = this.repository.GetAll().SingleOrDefault(x => x.Name == model.Username);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public void Delete(User obj) => this.repository.Delete(obj);

        public IEnumerable<User> GetAll() => this.repository.GetAll();

        public User GetById(int id) => this.repository.GetById(id);

        public User Insert(User obj) => this.repository.Insert(obj);

        public void Update(int id, User obj) => this.repository.Update(obj);

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
