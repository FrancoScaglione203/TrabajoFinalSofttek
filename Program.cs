using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using TrabajoFinalSofttek.DataAccess;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Helpers;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var AllowSpecificOrigins = "";
            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorizacion JWT",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type= ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[]{ }
                    }
                });

            });


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("name=defaultConnection");
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();
            builder.Services.AddScoped<DolarCotizacion>();
            builder.Services.AddScoped<Historial>();


            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "1");
                });

                option.AddPolicy("AdminConsultor", policy =>

                {
                    policy.RequireClaim(ClaimTypes.Role, "1", "2");
                });
            });


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(AllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}