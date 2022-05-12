using System;
using System.Collections.Generic;
using System.Linq;
using Users.Data.Facade;
using Users.Models;

namespace Users.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(UserContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Charlotte Majka", Email = "charlotte@majka.dk"},
                new User { Id = 2, Name = "Kim Christensen", Email = "kim@christensen.dk"},
                new User { Id = 3, Name = "René Jørgensen", Email = "rene@erdenbedste.dk"},
                new User { Id = 4, Name = "Elon Musk", Email = "elon@musk.com"},
                new User { Id = 5, Name = "Bill Gates", Email = "billgates@apple.com"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
