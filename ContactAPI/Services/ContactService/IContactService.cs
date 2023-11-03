	namespace ContactAPI.Services.ContactService
{
	public interface IContactService
	{
		List<Contact> GetAllContacts();
		Contact GetSingleContact(int id);
		List<Contact> AddContact(Contact contact);
		List<Contact> UpdateContact(int id, Contact request);
		List<Contact> DeleteContact(int id);

	}
}
