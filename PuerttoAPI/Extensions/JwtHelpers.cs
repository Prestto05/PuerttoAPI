using Core.Puertto.DTOs.Security;
using System.Runtime.Caching;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace PuerttoAPI.Extensions
{
    public static class JwtHelpers
    {
        private static MemoryCache cache;

        public static UserToken GetTokenkey(UserToken token, JwtSettings jwtSettings)
        {
            var UserToken = new UserToken();
            if (token == null) throw new ArgumentException(nameof(token));
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            Guid Id = Guid.Empty;
            DateTime expireTime = DateTime.UtcNow.AddDays(1);
            UserToken.Validaty = expireTime.TimeOfDay;
            var JWToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer,
                audience:
                jwtSettings.ValidAudience,
                claims: GetClaims(token, out Id),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(expireTime).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            UserToken.Token = $"bearer {new JwtSecurityTokenHandler().WriteToken(JWToken)}";
            UserToken.Email = token.Email;
            UserToken.id_usuario = token.id_usuario;
            UserToken.Rol = token.Rol;
            UserToken.GuidId = Id;
            UserToken.ExpiredTime = DateTime.UtcNow.AddDays(3);
            cache.Add(UserToken.Token, key, DateTimeOffset.MaxValue);
            return UserToken;
        }

        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[] {
                new Claim("Id", userAccounts.id_usuario.ToString()),



            new Claim(ClaimTypes.Name, userAccounts.Email),
                    new Claim("Email", userAccounts.EmailId),
                    new Claim(ClaimTypes.NameIdentifier, userAccounts.id_usuario.ToString()),
                    new Claim(ClaimTypes.Email, userAccounts.EmailId),
                    new Claim(ClaimTypes.Role, userAccounts.Rol.ToString()),
                    new Claim("NameIdentifier", Id.ToString()),
                    new Claim("Expiration", DateTime.UtcNow.AddDays(3).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };
            return claims;
        }

        public static void AddJWTTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            var bindJwtSettings = new JwtSettings();
            Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
            Services.AddSingleton(bindJwtSettings);

            Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                    ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:Key")))
                };

            });

        }
    }
}
