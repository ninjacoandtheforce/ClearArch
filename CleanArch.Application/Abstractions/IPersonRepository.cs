using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Abstractions
{
    public interface IPersonRepository
    {
        Task<ICollection<Person>> GetAll();

        Task<Person?> GetPersonById(int personId);

        Task<Person> AddPerson(Person toCreate);

        Task<Person> UpdatePerson(int personId, string name, string email);

        Task DeletePerson(int personId);
    }
}
