using System;
using System.Collections.Generic;
using System.Linq;
using CustomServer.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CustomServer.Data
{
    public class Seed
    {
        private const string Path = "Data/UserSeedData.json";

        public static void SeedUsers(UserManager<User> userManager){
            if(!userManager.Users.Any()){
                var userData = System.IO.File.ReadAllText(Path);
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach(var user in users){
                    userManager.CreateAsync(user,"password").Wait();
                    // byte[] passwordHash, passwordSalt;
                    // CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    // user.passwordHash = passwordHash;
                    // user.passwordSalt = passwordSalt;
                    // user.email = user.email.ToLower();
                    // user.userLevel = 1;
                    // user.date = DateTime.UtcNow;
                    // context.Users.Add(user);

                }
                //context.SaveChanges();
            }
        }
        
        private static  void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }

}