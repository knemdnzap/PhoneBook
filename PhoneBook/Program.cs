namespace PhoneBook
{
    class Program
    {
        enum words
        {
            add_contact = 1,
            list_contact,
            find_contact,
            exist_contact,
            delete_contact,
            available_contact,
            full_contact,
            exit
        }
        static void Main(string[] args)
        {
            #region PhoneBookSize
            // Variable con la que se guardara tamaño de agenda según el usuario
            int size;
            bool finish = false;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("=============== Agenda Telefónica ===============");
                Console.WriteLine("*                                               *");
                Console.WriteLine("*  Ingrese el tamaño que desee para su agenda:  *");
                Console.WriteLine("*                                               *");
                Console.WriteLine("=================================================");
                size = int.Parse(Console.ReadLine());

                if (size <= 10)
                    finish = true;
                else
                    Console.WriteLine("El tamaño de la agenda debe ser menos de 10 contactos");
            } while (finish == false);

            #endregion

            #region Menú

            bool exit = false;
            // Variable con la que se guardara la opcion del usuario
            int Option;

            Book book = new Book(size);
            string Name;
            string Phone, CellPhone;
            Contact contact;

            while(!exit)
            {
                Console.WriteLine("================= Agenda Telefónica =================");
                Console.WriteLine("*                                                   *");
                Console.WriteLine("*  1 Adicionar contacto                             *");
                Console.WriteLine("*  2 Listar contactos                               *");
                Console.WriteLine("*  3 Buscar contactos                               *");
                Console.WriteLine("*  4 Contacto existente                             *");
                Console.WriteLine("*  5 Eliminar contacto                              *");
                Console.WriteLine("*  6 Contactos disponibles                          *");
                Console.WriteLine("*  7 Agenda Llena                                   *");
                Console.WriteLine("*  8 Salir                                          *");
                Console.WriteLine("*                                                   *");
                Console.WriteLine("=====================================================");
                try
                {
                    Console.WriteLine("Ingrese el numero de la operación: ");
                    Option = int.Parse(Console.ReadLine());

                    switch (Option)
                    {
                        case (int) words.add_contact:
                            book.AddContactInfo();
                            break;

                        case (int) words.list_contact:
                            Console.Clear();
                            book.ListContact();
                            break;

                        case (int) words.find_contact:
                            Console.Clear();
                            book.FindContactInfo();
                            break;

                        case (int) words.exist_contact:
                            // Solicito el nombre
                            Console.Clear();
                            Console.WriteLine("Escribe un nombre: ");
                            Name = Console.ReadLine();

                            // Se crea contacto auxiliar
                            contact = new Contact(Name);
                            if (book.existContact(contact))
                                Console.WriteLine("Existe contacto");
                            else
                                Console.WriteLine("No existe contacto");
                            break;

                        case (int) words.delete_contact:
                            Console.Clear();
                            book.DeleteContactInfo();
                            break;

                        case (int) words.available_contact:
                            Console.Clear();
                            Console.WriteLine($"Hay {book.AvailableContact()} espacio(s) para añadir contactos");
                            break;

                        case (int) words.full_contact:
                            Console.Clear();
                            book.FullContactInfo();
                            break;

                        case (int) words.exit:
                            exit = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Solo números entre 1 y 8");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Se debe insertar un número");
                }
            }
            #endregion
        }
    }
}