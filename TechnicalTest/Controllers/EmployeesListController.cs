﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.Repositories.Interfaces;

namespace TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeesRepository.GetAll();
        }

        [HttpPost]
        public IActionResult Post(Employee animal)
        {
            if (animal == null)
            {
                return new BadRequestResult();
            }
 
            var result = _employeesRepository.Add(animal);

            if (result == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(animal);
        }

        [HttpPut]
        public IActionResult Put(Employee animal)
        {
            if (animal == null)
            {
                return new BadRequestResult();
            }

            var employee = _employeesRepository.Update(animal);

            if (employee == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(animal);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var found = _employeesRepository.Delete(id);

            if (!found)
            {
                return new NotFoundResult();
            }

            return new OkResult();
        }
    }
}