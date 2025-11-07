using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLTHPT.DAL.Repositories
{
    /// <summary>
    /// Interface cơ bản cho Repository pattern
    /// </summary>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
