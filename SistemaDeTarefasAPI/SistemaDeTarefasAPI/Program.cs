
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Refit;
using SistemaDeTarefasAPI.Controllers.Integracao.Refit;
using SistemaDeTarefasAPI.Data;
using SistemaDeTarefasAPI.Integracao;
using SistemaDeTarefasAPI.Integracao.Interfaces;
using SistemaDeTarefasAPI.Repositorios;
using SistemaDeTarefasAPI.Repositorios.Interfaces;
using System.Globalization;
using System.Text;

namespace SistemaDeTarefasAPI
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            string chaveSecreta = "a5ee28f6-fe3a-4342-97a0-7145ab5cf1d0";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDBContex>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))                                              
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRespositorio>();
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Sua_empresa",
                    ValidAudience = "Sua_aplicacao",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
