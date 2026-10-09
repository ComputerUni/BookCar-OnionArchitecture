using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand : IRequest
    {
        public UpdateCarFeatureAvailableChangeToFalseCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
