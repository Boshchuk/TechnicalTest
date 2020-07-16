using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechnicalTest.Models;
using TechnicalTest.Repositories.Interfaces;

namespace TechnicalTest.Repositories
{
    public class EmployeesInMemoryRepository : IEmployeesRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public Collection<Employee> GetAll()
        {
            return new Collection<Employee>(_employees);
        }

        public Employee Add(Employee entity)
        {
            entity.Id = Guid.NewGuid();
            _employees.Add(entity);
            return entity;
        }

        public Employee Update(Employee entity)
        {
            var firstOrDefault = _employees.FirstOrDefault(a => a.Id == entity.Id);

            if (firstOrDefault == null)
            {
                return null;
            }

            firstOrDefault.Name = entity.Name;
            firstOrDefault.LastName = entity.LastName;
            firstOrDefault.IsMediaInteractivaEmployee = entity.IsMediaInteractivaEmployee;

            return firstOrDefault;
        }

        public bool Delete(Guid id)
        {
            var firstOrDefault = _employees.FirstOrDefault(a => a.Id == id);

            if (firstOrDefault != null)
            {
                _employees.Remove(firstOrDefault);
                return true;
            }

            return false;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.FirstOrDefault(a => a.Id == id);
        }
    }
}