using System;
using System.Threading.Tasks;
using CustomServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomServer.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context){
            _context=context;
        }
        public async Task<User> Login(string email, string password)
        {
           // var user =await _context.Users.FirstOrDefaultAsync(x => x.email==email);
           
        //    if(user==null){
                
        //         return null;
        //    }
        //    if(!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt)){
                
        //         return null;
        //    }

           //return user;
           return null;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0; i<computedHash.Length; i++){
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
        
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            // user.passwordHash = passwordHash;
            // user.passwordSalt = passwordSalt;
            // user.userLevel = 1;
            user.date = DateTime.UtcNow;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            // if(await _context.Users.AnyAsync(x => x.email==email))
            //     return true;
            return false;
        }
    }
}