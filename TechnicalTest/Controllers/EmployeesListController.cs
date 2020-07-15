using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    [ApiController]
    [Route("employees-list")]
    public class EmployeesListController
    {
        [HttpGet]
        public IEnumerable<EmployeeListItem> Get()
        {
            var item1 = new EmployeeListItem
            {
                Name = "First Name 1",
                LastName = "Last Name 1",
                IsMediaInteractivaEmployee = true,
                Animals = new List<string>{"Cat 1", "Dog 1"}
            };

            var item2 = new EmployeeListItem
            {
                Name = "First Name 2",
                LastName = "Last Name 2",
                IsMediaInteractivaEmployee = true,
                Animals = new List<string>{"Fish 1", "Bird 1"}
            };

            return new List<EmployeeListItem> {item1, item2};
        }
    }

    [ApiController]
    [Route("animals-list")]
    public class AnimalsListController
    {
        [HttpGet]
        public IEnumerable<AnimalListItem> Get()
        {
            var cat = new AnimalListItem()
            {
                Name = "Tom The Cat",
                OwnerDisplayName = "Owner1"
            };

            var dog = new AnimalListItem
            {
                Name = "Scybi",
                OwnerDisplayName = "Shaggy Hair"
            };

            return new List<AnimalListItem> {cat, dog};
        }
    }
}