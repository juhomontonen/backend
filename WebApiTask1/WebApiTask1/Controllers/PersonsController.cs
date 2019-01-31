using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask1.Models;
using WebApiTask1.Repositories;
using WebApiTask1.Services;

namespace WebApiTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        public PersonsController(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAllPersons()
        {
            //var persons = new List<Person>
            //{
            //    new Person ("James", 55),
            //    new Person ("Lisa", 35)
            //};

            var persons = _personService.Read();
            return new JsonResult(persons);
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personService.Read(id);
            return new JsonResult(person);
        }

        // POST api/persons
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personService.Create(person);
            return new JsonResult(newPerson);
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, Person person)
        {
            var updatedPerson = _personService.Update(id, person);
            return new JsonResult(updatedPerson);
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _personService.Delete(id);
        }

        //[HttpGet("{name}")]
        //public ActionResult<Person> Get(string name)
        //{
        //    var personName = _personRepository.Read(name);
        //    return new JsonResult(person);
        //}
    }
}