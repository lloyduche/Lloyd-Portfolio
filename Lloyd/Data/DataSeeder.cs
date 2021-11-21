using Lloyd.Data.Context;
using Lloyd.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloyd.Data
{
    public class DataSeeder
    {
        private const string adminPassword = "Admin@2021";
        public static async Task Seed (IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<LloydDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();

            }

            if (context.Users.Any())
            {
                return;
            }
            else
            {

                //seed AppUser

                var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();



                if (!userManager.Users.Any())
                {
                    var roles = new string[] { "Admin", "User" };
                    foreach (var role in roles)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(role);
                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }


                    StreamReader userToRead = new StreamReader("../Lloyd/Data/JsonFile/Data.json");
                    var userData = await userToRead.ReadToEndAsync();


                    // deserilization of Json object
                    var userInfo = JsonConvert.DeserializeObject<List<AppUser>>(userData);
                    foreach (var user in userInfo)
                    {
                        await userManager.CreateAsync(user,adminPassword);
                        await userManager.AddToRoleAsync(user, roles[0]);
                    }
                    await context.SaveChangesAsync();
                }
            }

        }
        
    }
}
