using System.Text.Json;

namespace ContactsApp
{
    public interface IContactRepository
    {
        List<Contact> LoadContacts();
        void SaveContacts(List<Contact> contacts);
    }

    public class ContactRepository : IContactRepository
    {
        private const string FileName = "contacts.json";
        private string testFileName;

        public ContactRepository()
        {
        }

        public ContactRepository(string testFileName)
        {
            this.testFileName = testFileName;
        }

        public List<Contact> LoadContacts()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            }
            return new List<Contact>();
        }

        public void SaveContacts(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }
    }
}