using Entities.Entidades;
using Infrastructure.Configuracoes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPIS.Token;

namespace WebAPIS.Configuracoes
{
    public static class IdentityConfig
    {
        public static void IncluirConfiguracaoIdentityServico(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDefaultIdentity<UsuarioAplicacao>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ContextoBase>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Teste.Security.Bearer",
                        ValidAudience = "Teste.Security.Bearer",
                        IssuerSigningKey = JwtChaveSeguranca.Criar("Secret_Key-12345678")
                    };

                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
