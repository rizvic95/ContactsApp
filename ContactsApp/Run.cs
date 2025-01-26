using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Run
    {
        public void Start()
        {
            Console.WriteLine($"Arbetskatalog: {Directory.GetCurrentDirectory()}");


            IContactRepository repository = new ContactRepository();
            IContactService contactService = new ContactService(repository);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine("|||||||||     Kontaktlista       ||||||||||||||||");
                Console.WriteLine("|||||||||  1. Visa kontakter     ||||||||||||||||");
                Console.WriteLine("|||||||||  2. Skapa ny kontakt   ||||||||||||||||");
                Console.WriteLine("|||||||||  3. Avsluta            ||||||||||||||||");
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        contactService.ListContacts();
                        break;
                    case "2":
                        contactService.CreateContact();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}