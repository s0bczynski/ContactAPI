namespace ContactAPI.Services.ContactService
{
	public class ContactService : IContactService
	{
		private static List<Contact> contacts = new List<Contact>
			{
				new Contact { Id = 1, Name = "John", Email = "John@xyz.com", Phone = "760032010" },
				new Contact { Id = 2, Name = "James", Email = "James@xyz.com", Phone = "870234609" }
			};
		public List<Contact> AddContact(Contact contact)
		{
			contacts.Add(contact);
			return contacts;
		}

		public List<Contact> DeleteContact(int id)
		{
			var contact = contacts.Find(x => x.Id == id);
			if (contact == null)
			{
				return null;
			}
			contacts.Remove(contact);
			return contacts;
		}
	

		public List<Contact> GetAllContacts()
		{
			return contacts;
		}

		public Contact GetSingleContact(int id)
		{
			var contact = contacts.Find(x => x.Id == id);
			if (contact == null)
			{
				return null;
			}
			return contact;
		}

		public List<Contact> UpdateContact(int id, Contact request)
		{
			var contact = contacts.Find(x => x.Id == id);
			if (contact == null)
			{
				return null;
			}
			contact.Name = request.Name;
			contact.Email = request.Email;
			contact.Phone = request.Phone;

			return contacts;
		}
	}
}
