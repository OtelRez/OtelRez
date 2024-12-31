using OtelRez.DAL.DbContexts;
using OtelRez.DAL.Repositories.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.DAL.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Kullanici GetUserByEmail(string email)
        {
            return _context.Kullanicilar.FirstOrDefault(u => u.Mail == email);
        }
    }
}
