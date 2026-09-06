using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
    public class CreateBannerCommandHandler(IRepository<Banner> _repository)
    {
        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
