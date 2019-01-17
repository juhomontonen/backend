using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersondbContext _context;

        public PersonRepository(PersondbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public StatusCodeResult Delete(int id)
        {
            var deletedPerson = Read(id);
            _context.Remove(deletedPerson);
            _context.SaveChanges();
            return new OkResult();
        }

        public List<Person> Read()
        {
            // SELECT * FROM PERSON;
            return _context.Person
                .Include(p => p.Phone)
                .ToList();

            // TODO...
            // return _context.Person.FromSql("Select Person.Name From Person").ToList();
        }

        public Person Read(int id)
        {
            // SELECT * FROM PERSON WHERE ID=[id];
            return _context.Person
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);
        }

        public Person Read(string name)
        {
            // SELECT * FROM PERSON WHERE NAME=[name];
            return _context.Person
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Name == name);
        }

        public Person Update(int id, Person person)
        {
            var savedPerson = Read(id);
            if (savedPerson == null)
            {
                throw new Exception("Person not found");
            }
            else
            {
                _context.Update(person);
                _context.SaveChanges();
                return person;
            }
        }
    }
}
