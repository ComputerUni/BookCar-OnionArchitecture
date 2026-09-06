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
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository)
    {
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.Title = command.Title;
            value.VideoUrl = command.VideoUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
