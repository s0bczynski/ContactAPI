using ContactAPI.Services.ContactService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ContactAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Contact>>> GetAllContacts()
		{
			return await _contactService.GetAllContacts();
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Contact>> GetSingleContact(int id)
		{
			var contact = await _contactService.GetSingleContact(id);
			if(contact == null)
			{
				return NotFound("This contact doesn't exist");
			}
			return Ok(contact);
		}
		[HttpPost]
		public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
		{
			var Contact = await _contactService.AddContact(contact);
			return Ok(contact);
		}
		[HttpPut("id")]
		public async Task<ActionResult<List<Contact>>> UpdateContact(int id, Contact request)
		{
			var contact = await _contactService.UpdateContact(id, request);
			if (contact == null)
			{
				return NotFound("This contact doesn't exist");
			}

			return Ok(contact);
		}
		[HttpDelete("id")]
		public async Task<ActionResult<List<Contact>>> DeleteContact (int id)
		{
			var contact =  await _contactService.DeleteContact(id);
			if (contact == null)
			{
				return NotFound("This contact doesn't exist");
			}
			return Ok(contact);
		}
	}
}
