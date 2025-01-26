using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Tests
{
    public class ContactRepositoryTests
    {
        [Fact]
        public void SaveContacts_ShouldCreateFile()
        {
            // Arrange
            var repository = new ContactRepository();
            var contacts = new List<Contact>
            {
                new Contact
                {
                    FirstName = "Test Förnamn",
                    LastName = "Test Efternamn",
                    Email = "test@mail.com",
                    PhoneNumber = "07007011",
                    StreetAddress = "Testgatan 1",
                    PostalCode = "12345",
                    City = "Teststad"
                }
            };

            // Act
            repository.SaveContacts(contacts);

            // Assert
            Assert.True(File.Exists("contacts.json"));

            // Clean up
            File.Delete("contacts.json");
        }
    }
}
