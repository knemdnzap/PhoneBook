using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    class Book
    {
        // Atributos
        public Contact[] contacts;
        string Name;
        string Phone, CellPhone;

        // Constructor
        public Book()
        {
            this.contacts = new Contact[10];
        }

        public Book(int size)
        {
            // Tamaño que queramos
            this.contacts = new Contact[size];
        }

        #region AddContact

            // Añade los contactos a la agenda
            public int AddContact(Contact contact)
            {
                if (existContact(contact))
                    Console.WriteLine("El contacto con ese nombre ya existe");
                else
                    if (FullContact())
                    {
                        Console.WriteLine("La agenda esta llena, no se pueden añadir más contactos");
                        return 0;
                    }else
                    {
                        // Si ya se hacen las validaciones hasta aquí ya puede empezar a añadir
                        bool find = false;
                        for (int increase = 0; increase < contacts.Length && !find; increase++)
                        {
                            // Control de nulos
                            if (contacts[increase] == null)
                            {
                                // Se inserta el contacto
                                contacts[increase] = contact;

                                // Indico que se encontro
                                find = true;
                            }
                        }

                        if (find)
                        {
                            Console.WriteLine("Se añadio el contacto correctamente");
                            return 1;
                        } else
                            Console.WriteLine("No se ha podido añadir el contacto");
                    }
                return 0;
            }

            // Metodo que Añade y guarda la información del nuevo contacto
            public void AddContactInfo()
            {
                AddContact(RequestInfo());
            }
        #endregion

        #region ExistContact
            // Indica si un contacto existe
            public bool existContact(Contact contact)
            {
                for (int increase = 0; increase < contacts.Length; increase++)
                {
                    // Control de nulos y se indica si el contacto es el mismo
                    // También es una forma de hacer un if dentro de otro sin el uso del otro if
                    if (contacts[increase] != null && contact.equals(contacts[increase]))
                    return true;
                }
                return false;
            }
        #endregion

        #region ListContact
            // Lista los contactos de la agenda
            public int ListContact()
            {
                if (AvailableContact() == contacts.Length)
                {
                    Console.WriteLine("No hay contactos que mostrar");
                    return 0;
                } else {
                    for (int increase = 0; increase < contacts.Length; increase++)
                    {
                        if (contacts[increase] != null)
                            Console.WriteLine(contacts[increase]);
                    }
                    return 1;
                }
            }
        #endregion

        #region FindContact
            // Busqueda por nombre
            public Contact FindContact(string Name)
            {
                if (contacts.Length > 0)
                {
                    for (int increase = 0; increase < contacts.Length; increase++)
                    {
                        if (contacts[increase] != null && contacts[increase].getName().Trim().Equals(Name.Trim()))
                        {
                            return contacts.ElementAt(increase);
                        }
                    }
                    return null;
                }
                return null;
            }

            // Metodo que solicita el nombre a buscar
            public string RequestInfoName()
            {
                Console.WriteLine("Escribe el nombre del contacto: ");
                return Console.ReadLine();
            }

            // Metodo que valida si el contacto que busca existe
            public void InfoContactFound(Contact contact)
            {
                if (contact != null)
                    Console.WriteLine(contact.toString());
                else
                    Console.WriteLine("No se ha encontrado el contacto");
            }

            // Metodo que busca el contacto
            public void FindContactInfo()
            {
                Contact contact = FindContact(RequestInfoName());
                InfoContactFound(contact);
            }
        #endregion

        #region FullContact
            // Indica si la agenda esta llena o no
            public bool FullContact()
            {
                for (int increase = 0; increase < contacts.Length; increase++)
                {
                    if (contacts[increase] == null)
                        // Se indica que la agenda no esta llena, ya que encuentra un nulo
                        return false;
                }
                // Se indica que la agenda esta llena
                return true;
            }

            // Metodo que verifica si la agenda esta llena o no
            public void ShowPhoneBookFull(bool full)
            {
                if (full)
                    Console.WriteLine("La agenda esta llena");
                else
                    Console.WriteLine("Aún puedes añadir más contactos");
            }

            // Metodo que muestra si la agenda esta llena
            public void FullContactInfo()
            {
                ShowPhoneBookFull(FullContact());
            }
        #endregion

        #region DeleteContact
            // Elimina contactos de la agenda
            public int DeleteContact(Contact contact)
            {
                bool find = false;
                for (int increase = 0; increase < contacts.Length && !find; increase++)
                {
                    if (contacts[increase] != null && contacts[increase].equals(contact))
                    {
                        // Control de nulos / Lo borramos
                        contacts[increase] = null;
                        // Indica que lo ha encontrado, para que una vez que lo encuentre salga de aquí
                        find = true;
                    }
                }
                if (find)
                {
                    Console.WriteLine("Se ha eliminado el contacto");
                    return 1;
                } else
                    Console.WriteLine("No se ha eliminado el contacto");
                    return 0;
            }

            // Metodo que Elimina por nombre
            public void DeleteContactInfo()
            {
                DeleteContact(FindContact(RequestInfoName()));
            }
        #endregion

        #region AvailableContact
            // Indica cuantos contactos más podemos añadir
            public int AvailableContact()
            {
                int counterFree = 0;
                for (int increase = 0; increase < contacts.Length; increase++)
                {
                    // Control de nulos, cuendo encuentre un nulo que se sume uno
                    if (contacts[increase] == null)
                        counterFree++; // Acomula
                }
                return counterFree;
            }
        #endregion

        #region RequestInfo
             // Metodo que solicita información al usuario para añadir contacto
            public Contact RequestInfo()
            {
                do
                {
                    Console.WriteLine("Escriba un nombre: ");
                    Name = Console.ReadLine();
                    if (Name == "")
                        Console.WriteLine("El nombre es obligatorio");
                } while(Name == "");

                Console.WriteLine("Escriba un telefono: ");
                Phone = Console.ReadLine();

                Console.WriteLine("Digite número de celular: ");
                CellPhone = Console.ReadLine();

                return new Contact (Name, Phone, CellPhone);
            }
        #endregion
    }
}