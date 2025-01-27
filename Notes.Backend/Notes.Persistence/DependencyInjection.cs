﻿using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());

            return services;
        }
    }
}
