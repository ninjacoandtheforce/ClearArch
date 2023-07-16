using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class CreateCommand<T> : IRequest<T> where T : class
    {
        public T Model { get; set; }

        public CreateCommand(T model)
        {
            Model = model;
        }
    }
}
