using PhoneBook;

namespace Test
{
    public class TestBook
    {
        Book book;
        Contact contact;

        public TestBook()
        {
            book = new Book(3);
        }

        #region TestAddContact
            public int AddContact_Test(string name, string phone, string cellPhone)
            {
                return book.AddContact(new Contact(name, phone, cellPhone));
            }

            public int TryToAddSameContact(string name, string phone, string cellPhone)
            {
                book.AddContact(new Contact("Nicolas", "300779", "300779"));
                return book.AddContact(new Contact(name, phone, cellPhone));
            }

            public int FullAddContact_Test(string name, string phone, string cellPhone)
            {
                book.AddContact(new Contact("Nicolas", "300779", "300779"));
                book.AddContact(new Contact("Liliana", "300779", "300779"));
                book.AddContact(new Contact("Fabian", "300779", "300779"));
                return book.AddContact(new Contact(name, phone, cellPhone));
            }
        #endregion

        #region TestExistContact
            public int ExistContact_Test(string name)
            {
                book.AddContact(new Contact(name, "300779", "300779"));
                bool value = book.existContact(contact);
                if (value) return 1;
                return 0;
            }

            public int NotExistContact_Test(string name)
            {
                bool value = book.existContact(contact);
                if (value) return 1;
                return 0;
            }
        #endregion

        #region TestFindContact
            public Contact FindContact_Test(string name)
            {
                book.AddContact(new Contact(name, "300779", "300779"));
                return book.FindContact(name);
            }

            public Contact NotFindContact_Test(string name)
            {
                return book.FindContact(name);
            }
        #endregion

        #region TestListContact
            public int ListContact_Test()
            {
                book.AddContact(new Contact("name", "1234", "1234"));
                return book.ListContact();
            }
        #endregion

        #region TestDeleteContact
            public int DeleteContact_Test(string name)
            {
                Contact contact = new Contact(name, "300779", "300779");
                book.AddContact(contact);
                return book.DeleteContact(contact);
            }

            public int DeleteContactNotExist_Test(string name)
            {
                Contact contact = new Contact(name, "300779", "300779");
                return book.DeleteContact(contact);
            }
        #endregion

        #region TestFullContact
            public bool FullContact_Test()
            {
                book.AddContact(new Contact("Nicolas", "300779", "300779"));
                book.AddContact(new Contact("Liliana", "300779", "300779"));
                book.AddContact(new Contact("Fabian", "300779", "300779"));
                return book.FullContact();
            }

            public bool NotFullContact_Test()
            {
                return book.FullContact();
            }
        #endregion

        #region TestAvailableContact
            public int AvailableContact_Test()
            {
                return book.AvailableContact();
            }

            public int NotAvailableContact_Test()
            {
                book.AddContact(new Contact("Nicolas", "300779", "300779"));
                book.AddContact(new Contact("Liliana", "300779", "300779"));
                book.AddContact(new Contact("Fabian", "300779", "300779"));
                return book.AvailableContact();
            }
        #endregion
    }
}