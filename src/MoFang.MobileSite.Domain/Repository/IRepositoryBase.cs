using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using MoFang.MobileSite.Domain.Entity;

namespace MoFang.MobileSite.Domain.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {

    }
}