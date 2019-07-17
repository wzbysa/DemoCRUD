using System;
using System.Collections.Generic;
using System.Linq;
using DEMOCRUD.Models.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DEMOCRUD.Models {
    public static class DBinitialize {
        public static void INIT (IServiceProvider serviceProvider) 
        {
            var context = new NorthwindContext(
                serviceProvider.GetRequiredService<DbContextOptions<NorthwindContext>>()
            );
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }            
        } 
              
    }

}