using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ContactAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private static List<Contact> contacts = new List<Contact>
			{
				new Contact { Id = 1, Name = "John", Email = "John@xyz.com", Phone = "760032010" },
				new Contact { Id = 2, Name = "James", Email = "James@xyz.com", Phone = "870234609" }
			};
		[HttpGet]
		public async Task<ActionResult<List<Contact>>> GetAllContacts()
		{
			return Ok(contacts);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Contact>> GetSingleContact(int id)
		{
			var contact = contacts.Find(x => x.Id == id);
			if(contact == null)
			{
				return NotFound("This contact doesn't exist");
			}
			return Ok(contact);
		}
		[HttpPost]
		public async Task<ActionResult<List<Contact>>> AddContact([FromBody]Contact contact)
		{
			contacts.Add(contact);
			return Ok(contact);
		}
		[HttpPut("id")]
		public async Task<ActionResult<List<Contact>>> UpdateContact(int id, Contact request)
		{
			var contact = contacts.Find(x => x.Id == id);
			if (contact == null)
			{
				return NotFound("This contact doesn't exist");
			}
			contact.Name = request.Name;
			contact.Email = request.Email;
			contact.Phone = request.Phone;

			return Ok(contact);
		}
		[HttpDelete("id")]
		public async Task<ActionResult<List<Contact>>> DeleteContact (int id)
		{
			var contact = contacts.Find(x => x.Id == id);
			if (contact == null)
			{
				return NotFound("This contact doesn't exist");
			}
			contacts.Remove(contact);
			return Ok(contact);
		}
	}
}
