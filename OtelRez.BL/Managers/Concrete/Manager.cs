using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.Repositories.Concrete;
using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Managers.Concrete
{
    public class Manager<T> : Repository<T>, IManager<T> where T : BaseEntity
    {
    }
}
