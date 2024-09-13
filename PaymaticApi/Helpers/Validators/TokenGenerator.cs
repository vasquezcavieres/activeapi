using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ActivPayApi.Helpers.Validators
{
    public class TokenGenerator
    {
        public static string GenerateTokenJwt(int rut)
        {
            // appsetting for Token JWT
            var secretKey = "5010FC72935E4ECB83905178F03D488CFAC14596CBD86144EBA90420FCE42E579DA05E14B617194EC9A2";// jWTProfile.SecretKey;
            var audienceToken = "http://www.codebase.cl";// jWTProfile.AudienceToken;
            var issuerToken = "http://www.codebase.cl";// jWTProfile.IssuerToken;
            var expireTime = "30";// jWTProfile.ExpireTime;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, $"{rut}")});

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        public static bool TokenEsValido( JwtSecurityToken securityToken)
        {

            var issuerToken = "http://www.codebase.cl";// jWTProfile.IssuerToken;
            var audienceToken = "http://www.codebase.cl";// jWTProfile.AudienceToken;

            bool esValido = false;
            var issuer = securityToken.Payload.First(pay => pay.Key == "iss").Value.ToString();
            var audience = securityToken.Payload.First(pay => pay.Key == "aud").Value.ToString();
            var expr = Convert.ToInt64(securityToken.Payload.First(pay => pay.Key == "exp").Value.ToString());
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(expr);
            esValido = issuer.Equals(issuerToken) && audience.Equals(audienceToken) && dateTimeOffset.LocalDateTime > DateTime.Now;

            return esValido;
        }
    }
}
