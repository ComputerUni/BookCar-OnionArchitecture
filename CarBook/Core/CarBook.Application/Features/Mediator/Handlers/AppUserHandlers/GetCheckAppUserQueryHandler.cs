using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler(IAppUserRepository _repository) : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _repository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if(user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.Username;
                values.Role = (await _repository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId))?.AppRole.AppRoleName;
                values.Id = user.AppUserId;
            }
            return values;
        }
    }
}
