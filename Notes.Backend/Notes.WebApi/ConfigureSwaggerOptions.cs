using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace Notes.WebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Notes API {apiVersion}",
                        Description = "A simple example ASP Net Core Web API. Professional way",
                        TermsOfService = new Uri("https://www.youtube.com/playlist?list=PLEtg-LdqEKXbpq4RtUp1hxZ6ByGjnvQs4"),
                        Contact = new OpenApiContact
                        {
                            Name = "My Pet Web Api project",
                            Email = "severin1975list@gmail.com",
                            Url = new Uri("https://github.com/Stanislav-003?tab=repositories")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "My Telegram Channel",
                            Url = new Uri("https://t.me/stanislaf1")
                        }
                    });

                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization token"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                           Reference = new OpenApiReference
                           {
                             Type = ReferenceType.SecurityScheme,
                              Id = $"AuthToken {apiVersion}"
                           }
                        },
                       new string[] { }
                    }
                });

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name : null);
            }
        }
    }
}
