using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarMember_server.Helpers;

public static class JwtDecoder
{
    public static string RemoveBearer(string jwt)
    {
        return jwt.Split(' ')[1];
    }

    public static string GetId(string jwt)
    {
        return new JwtSecurityTokenHandler().ReadJwtToken(RemoveBearer(jwt)).Subject;
    }
    public static string GetRole(string jwt)
    {
        var token = new JwtSecurityTokenHandler().ReadJwtToken(RemoveBearer(jwt));

        foreach (var item in token.Claims)
        {
            switch (item.Type)
            {
                case ClaimTypes.Role:
                    return item.Value;
                    break;                 
            }
        }

        return "Echec...";

    }
}
