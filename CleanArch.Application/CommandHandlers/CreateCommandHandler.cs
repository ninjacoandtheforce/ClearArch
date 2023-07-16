using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.Abstractions;
using CleanArch.Application.Commands;
using MediatR;

namespace CleanArch.Application.CommandHandlers
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : class
    {
        private readonly IRepository<T> _repository;

        public CreateCommandHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            var item = request.Model;
            return await _repository.CreateAsync(item);
        }
    }
}
