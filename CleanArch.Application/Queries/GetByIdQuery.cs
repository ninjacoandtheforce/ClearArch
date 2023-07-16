using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArch.Application.Queries
{
    public class GetByIdQuery<T> : IRequest<T>
    {
        public object Id { get; set; }

        public GetByIdQuery(object id)
        {
            Id = id;
        }

    }
}
