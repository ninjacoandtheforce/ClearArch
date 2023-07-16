using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArch.Application.Queries;
using CleanArch.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IMediator _mediator;
        private static List<TEntity> entities = new List<TEntity>();
        public GenericController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            //var queryType = typeof(GetByIdQuery<>).MakeGenericType(typeof(TEntity));
            var getPerson = new GetByIdQuery<Person>(id);
             var person = await _mediator.Send(getPerson);
            return Ok(person);

            /*var entity = entities.FirstOrDefault(e => GetId(e) == id);
            if (entity == null)
                return NotFound();

            return Ok(entity);*/

        }

        [HttpPost]
        public ActionResult<TEntity> Post(TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid entity data.");

            SetId(entity, entities.Count + 1);
            entities.Add(entity);

            return CreatedAtAction(nameof(Get), new { id = GetId(entity) }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid entity data.");

            var existingEntity = entities.FirstOrDefault(e => GetId(e) == id);
            if (existingEntity == null)
                return NotFound();

            UpdateEntity(existingEntity, entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = entities.FirstOrDefault(e => GetId(e) == id);
            if (entity == null)
                return NotFound();

            entities.Remove(entity);

            return NoContent();
        }

        protected virtual int GetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        protected virtual void SetId(TEntity entity, int id)
        {
            throw new NotImplementedException();
        }

        protected virtual void UpdateEntity(TEntity existingEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
