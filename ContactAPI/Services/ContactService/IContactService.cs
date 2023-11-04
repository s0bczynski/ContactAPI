	namespace ContactAPI.Services.ContactService
{
	public interface IContactService
	{
		Task<List<Contact>> GetAllContacts();
		Task<Contact> GetSingleContact(int id);
		Task<List<Contact>> AddContact(Contact contact);
		Task<List<Contact>> UpdateContact(int id, Contact request);
		Task<List<Contact>> DeleteContact(int id);

	}
}
