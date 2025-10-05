﻿using LibraryManagementForSchool.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagementForSchool.Extensions
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection InjectDbContext(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("conn")));
            return services;
        }
    }
}
