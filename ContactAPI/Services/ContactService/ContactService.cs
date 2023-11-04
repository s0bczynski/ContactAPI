using ContactAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Services.ContactService
{
	public class ContactService : IContactService
	{
		private readonly DataContext _context;
		public ContactService(DataContext context)
		{
			_context = context;
		}

		public DataContext Context { get; }

		public async Task<List<Contact>>? AddContact(Contact contact)
		{
			_context.Contacts.Add(contact);
			await _context.SaveChangesAsync();
			return await _context.Contacts.ToListAsync();
		}

		public async Task<List<Contact>>? DeleteContact(int id)
		{
			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return null;
			}
			_context.Contacts.Remove(contact);
			await _context.SaveChangesAsync();
			return await _context.Contacts.ToListAsync();
		}
	

		public async Task<List<Contact>>? GetAllContacts()
		{
			var entry = await _context.Contacts.ToListAsync();
			return entry;
		}

		public async Task<Contact>? GetSingleContact(int id)
		{
			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return null;
			}
			return contact;
		}

		public async Task<List<Contact>>? UpdateContact(int id, Contact request)
		{
			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return null;
			}
			contact.Name = request.Name;
			contact.Email = request.Email;
			contact.Phone = request.Phone;

			await _context.SaveChangesAsync();

			return await _context.Contacts.ToListAsync();
		}
	}
}
