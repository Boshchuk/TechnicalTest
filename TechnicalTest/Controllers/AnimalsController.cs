using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.Services.Interfaces;

namespace TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController
    {
        private readonly IAnimalsService _animalsService;

        public AnimalsController(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return _animalsService.GetAnimals();
        }

        [HttpPost]
        public IActionResult Post(Animal animal)
        {
            if (animal == null)
            {
                return new BadRequestResult();
            }
 
            var result = _animalsService.AddAnimal(animal);

            if (result == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(animal);
        }

        [HttpPut]
        public IActionResult Put(Animal animal)
        {
            if (animal == null)
            {
                return new BadRequestResult();
            }

            var animalToUpdate = _animalsService.UpdateAnimal(animal);

            if (animalToUpdate == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(animal);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var found = _animalsService.DeleteAnimal(id);

            if (!found)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }
    }
}