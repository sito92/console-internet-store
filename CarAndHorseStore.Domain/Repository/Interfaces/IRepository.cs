using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Add(T element);

        void Delete(T element);

        void SaveChanges();

        void Open();
    }
}
