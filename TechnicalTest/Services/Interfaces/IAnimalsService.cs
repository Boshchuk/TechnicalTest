using System;
using System.Collections.Generic;
using TechnicalTest.Models;

namespace TechnicalTest.Services.Interfaces
{
    public interface IAnimalsService
    {
        IEnumerable<Animal> GetAnimals();

        Animal AddAnimal(Animal animal);

        Animal UpdateAnimal(Animal animal);

        bool DeleteAnimal(Guid id);
    }
}