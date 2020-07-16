using System;
using TechnicalTest.Models;

namespace TechnicalTest.Repositories.Interfaces
{
    public interface IEmployeesRepository : ICommonRepositoryOperations<Employee>
    {
        Employee GetEmployee(Guid id);
    }
}