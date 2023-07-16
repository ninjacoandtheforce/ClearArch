using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.Abstractions;
using CleanArch.Application.Queries;
using MediatR;

namespace CleanArch.Application.QueryHandlers
{
    public class GetByIdQueryHandler<T> :IRequestHandler<GetByIdQuery<T>, T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GetByIdQueryHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetSingleAsync(request.Id);
        }
    }
}
