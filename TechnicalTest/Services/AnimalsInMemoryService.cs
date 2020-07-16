using System;
using System.Collections.Generic;
using TechnicalTest.Models;
using TechnicalTest.Repositories;
using TechnicalTest.Repositories.Interfaces;
using TechnicalTest.Services.Interfaces;

namespace TechnicalTest.Services
{
    public class AnimalsInMemoryService : IAnimalsService
    {
        private readonly IAnimalsRepository _animalsRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public AnimalsInMemoryService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;

            // strong in-memory implementation
            _animalsRepository = new AnimalsInMemoryRepository();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animalsRepository.GetAll();
        }

        public Animal AddAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal));
            }
 
            var result = _animalsRepository.Add(animal);

            if (result?.Owner != null)
            {
                var id = result.Owner.Id;

                var employee = _employeesRepository.GetEmployee(id);

                if (employee == null)
                {
                    // TODO: need inform on UI, that is not possible assign to this employee
                }

                if (employee != null)
                {
                    employee.Animals ??= new List<Animal>();
                    employee.Animals.Add(animal);
                }
            }

            return result == null ? null : animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal));
            }

            var animalToUpdate = _animalsRepository.Update(animal);

            return animalToUpdate == null ? null : animal;
        }

        public bool DeleteAnimal(Guid id)
        {
            return _animalsRepository.Delete(id);
        }
    }
}