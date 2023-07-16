using CleanArch.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : GenericController<Person>
    {
        protected override int GetId(Person entity)
        {
            return entity.Id;
        }

        protected override void SetId(Person entity, int id)
        {
            entity.Id = id;
        }

        protected override void UpdateEntity(Person existingEntity, Person newEntity)
        {
            existingEntity.Name = newEntity.Name;
            existingEntity.Email = newEntity.Email;
        }


        public PersonController(IMediator mediator) : base(mediator)
        {
        }
    }
}
