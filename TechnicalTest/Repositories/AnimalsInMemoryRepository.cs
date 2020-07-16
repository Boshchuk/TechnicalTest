using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechnicalTest.Models;
using TechnicalTest.Repositories.Interfaces;

namespace TechnicalTest.Repositories
{
    public class AnimalsInMemoryRepository : IAnimalsRepository
    {
        private readonly List<Animal> _animals = new List<Animal>();

        public Collection<Animal> GetAll()
        {
            return new Collection<Animal>(_animals);
        }

        public Animal Add(Animal entity)
        {
            entity.Id = Guid.NewGuid();
            _animals.Add(entity);
            return entity;
        }

        public Animal Update(Animal entity)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == entity.Id);

            if (animalToUpdate == null)
            {
                return null;
            }

            animalToUpdate.Type = entity.Type;
            animalToUpdate.Name = entity.Name;
            animalToUpdate.Owner = entity.Owner;

            return animalToUpdate;
        }

        public bool Delete(Guid id)
        {
            var animalToDelete = _animals.FirstOrDefault(a => a.Id == id);

            if (animalToDelete != null)
            {
                _animals.Remove(animalToDelete);
                return true;
            }

            return false;
        }
    }
}