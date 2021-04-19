using System.Security.Claims;

namespace ReactASPCrud.TokenAuthentication
{
    public interface ITokenManager
    {

        bool Auth(string user, string pass);

        string NewToken();

        ClaimsPrincipal VerifyToken(string token);
    }
}
