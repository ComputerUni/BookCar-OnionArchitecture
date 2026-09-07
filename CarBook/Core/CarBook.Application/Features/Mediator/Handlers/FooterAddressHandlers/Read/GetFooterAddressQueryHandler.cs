using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.FooterAddressId,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email
            }).ToList();
        }
    }
}
