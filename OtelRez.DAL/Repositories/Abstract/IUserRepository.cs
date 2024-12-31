using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.DAL.Repositories.Abstract
{
    public interface IUserRepository
    {
        Kullanici GetUserByEmail(string email);
    }
}
