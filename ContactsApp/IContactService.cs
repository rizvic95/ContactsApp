namespace ContactsApp
{
    public interface IContactService
    {
        void ListContacts();
        void CreateContact();
    }

    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private List<Contact> contacts;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
            contacts = _repository.LoadContacts();
        }

        public void ListContacts()
        {
            Console.Clear();
            if (contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"ID: {contact.Id}\nNamn: {contact.FirstName} {contact.LastName}\nEmail: {contact.Email}\nTelefon: {contact.PhoneNumber}\nAdress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}\n");
                }
            }
            else
            {
                Console.WriteLine("Inga kontakter hittades.");
            }

            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        public void CreateContact()
        {
            Console.Clear();
            Contact contact = new Contact();

            Console.Write("Förnamn: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            contact.LastName = Console.ReadLine();

            Console.Write("E-postadress: ");
            contact.Email = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Gatuadress: ");
            contact.StreetAddress = Console.ReadLine();

            Console.Write("Postnummer: ");
            contact.PostalCode = Console.ReadLine();

            Console.Write("Ort: ");
            contact.City = Console.ReadLine();

            contacts.Add(contact);
            _repository.SaveContacts(contacts);
            Console.WriteLine("Kontakt tillagd! Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}