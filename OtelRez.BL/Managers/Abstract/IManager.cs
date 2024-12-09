using OtelRez.DAL.Repositories.Abstract;
using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Managers.Abstract
{
    public interface IManager<T> : IRepository<T> where T : BaseEntity
    {
    }
}
