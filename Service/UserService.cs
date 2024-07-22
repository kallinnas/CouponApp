using CouponSystem.Data;
using CouponSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CouponApp.Service
{
    public class UserService
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context) { _context = context; }

        public async Task CreateUserAsync(string email, string password, int role)
        {
            User user = new User(email, password, role);

            if (role == 1)
            {
                _context.Customers.Add((Customer)user.Client);
            }
            else
            {
                _context.Companies.Add((Company)user.Client);
            }        

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserSPAsync(string email, string password, int role)
        {
            var sql = "EXEC InsertUser_SP @Email, @Password, @Role";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Role", role));
        }

    }
}
