using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReactASPCrud.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        public bool Auth(string user, string pass)
        {
            throw new System.NotImplementedException();
        }



        public string NewToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes("prueba pacheco");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Manuel") }),
                Expires = DateTime.UtcNow.AddDays(7), //token expires in 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes("prueba pacheco");

            return tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
        }
    }
}
