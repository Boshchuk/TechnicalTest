using System;
using System.Collections.ObjectModel;

namespace TechnicalTest.Repositories.Interfaces
{
    /// <summary>
    /// Common CRUD-like operations 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonRepositoryOperations<T>
    {
        Collection<T> GetAll();

        T Add(T entity);

        T Update(T entity);

        bool Delete(Guid id);
    }
}