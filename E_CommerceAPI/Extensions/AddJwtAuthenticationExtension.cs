using E_Commerce.Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.Presentation.Extensions
{
    public static class AddJwtAuthenticationExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JWT").Get<JwtOptions>();
            service.AddSingleton(jwtOptions);

            service.AddAuthentication(options =>
            {
                // assign all this shceme to jwt default Scheme 
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.SigningKey)
                    )
                };
            });
        }
    }
}
