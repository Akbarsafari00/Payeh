using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Payeh.Options;
using Payeh.Utilities.Middlewares;
using Payeh.Utilities.Services;
using Payeh.Utilities.Services.Logger;
using Payeh.Utilities.Services.Translations;

namespace Payeh
{
    public static class NetCoreExtensions
    {
        public static IServiceCollection AddPayeh(this IServiceCollection services, IConfiguration configuration)
        {
            var payehOptions = new PayehOptions();
            configuration.GetSection("Payeh").Bind(payehOptions);

            services.AddSingleton<PayehOptions>(payehOptions);

            if (payehOptions.Cors is {Enabled: true})
            {
                services.AddCors();
            }
            
            if (payehOptions.Swagger is {Enabled: true})
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(payehOptions.Swagger.SwaggerDoc.Name, new OpenApiInfo {Title = payehOptions.Swagger.SwaggerDoc.Title, Version = payehOptions.Swagger.SwaggerDoc.Version});

                    if (payehOptions.Authentication is {Enabled:true})
                    {
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = "Please insert JWT with Bearer into field",
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey
                        });
                        
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                System.Array.Empty<string>()
                            }
                        });
                    }
                    
                   
                });
            }
            
            if (payehOptions.Authorization is {Enabled: true})
            {
                services.AddAuthorization();
            }
            
            if (payehOptions.Authentication is {Enabled: true})
            {
                services.AddAuthentication(c =>
                    {
                        c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        var key = Encoding.ASCII.GetBytes(payehOptions.Authentication.Jwt.SecretKey);
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = true,
                            ValidIssuer = payehOptions.Authentication.Jwt.Issuer,
                            ValidateAudience = true,
                            ValidAudience = payehOptions.Authentication.Jwt.Audience,
                            RequireExpirationTime = false,
                            ValidateLifetime = true
                        };
                    });
            }
            
            services.AddServices(payehOptions);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services,
            PayehOptions payehOptions)
        {
            if (payehOptions.Services.Translator != null)
            {
                switch (payehOptions.Services.Translator.Type.ToLower())
                {
                    case "google":
                        services.AddTransient<ITranslator, GoogleTranslator>();
                        break;
                    default:
                        services.AddTransient<ITranslator, GoogleTranslator>();
                        break;
                }
            }

            if (payehOptions.Services.Logger != null)
            {
                switch (payehOptions.Services.Logger.Type.ToLower())
                {
                    default:
                        services.AddTransient<ILogger, Logger>();
                        break;
                }
            }

            services.AddTransient<IPayehService, PayehService>();
            return services;
        }

        public static IApplicationBuilder UsePayeh(this IApplicationBuilder app, IConfiguration configuration)
        {
            var payehOptions = new PayehOptions();
            configuration.GetSection("Payeh").Bind(payehOptions);

            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            if (payehOptions.Authorization is {Enabled: true})
            {
                app.UseAuthorization();
            }
            
            if (payehOptions.Authentication is {Enabled: true})
            {
                app.UseAuthentication();
            }
            
            if (payehOptions.Cors is {Enabled: true})
            {
                app.UseCors(
                    options => options
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials()
                );
            }
            
            if (payehOptions.Swagger is {Enabled: true})
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint(payehOptions.Swagger.SwaggerDoc.Url, payehOptions.Swagger.SwaggerDoc.Name));
            }

            
            return app;
        }
    }
}