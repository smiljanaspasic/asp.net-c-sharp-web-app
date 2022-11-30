using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetOne(int Id);

        List<T> GetAll();

        int? Create(T obj);

        void DeleteById(int Id);

        int Update(T obj);
    }
}
