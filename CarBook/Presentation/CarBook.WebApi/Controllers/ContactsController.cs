using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(CreateContactCommandHandler _createContactCommandHandler, UpdateContactCommandHandler _updateContactCommandHandler, RemoveContactCommandHandler _removeContactCommandHandler, GetContactQueryHandler _getContactQueryHandler, GetContactByIdQueryHandler _getContactByIdQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            await _createContactCommandHandler.Handle(createContactCommand);
            return Ok("İletişim Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim Bilgisi Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateContactCommand updateContactCommand)
        {
            await _updateContactCommandHandler.Handle(updateContactCommand);
            return Ok("İletişim Bilgisi Başarıyla Güncellendi");
        }

    }
}
