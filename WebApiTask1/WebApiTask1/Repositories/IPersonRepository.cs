using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        Person Read(string name);
        Person Update(int id, Person person);
        StatusCodeResult Delete(int id);
    }
}
