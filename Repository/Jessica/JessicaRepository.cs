
using JessicaFacturacion.Data;
using JessicaFacturacion.Utils.Passwords;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace JessicaFacturacion.Repository.Jessica
{
    public class JessicaRepository(AppDbContext context) : IJessicaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> Login(Models.Jessica jessica)
        {
            
            var jessicas =  await _context.jessicas.FirstOrDefaultAsync(j => j.Email == jessica.Email);
            if (jessicas == null) { return false; }
            var passwordHasher = new PasswordHasher<object>();
            var passwordManager = new PasswordManager(passwordHasher);
            return passwordManager.VerifyHashedPassword(jessicas.Password, jessica.Password);
        }
    }
}
