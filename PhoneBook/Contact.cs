using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    public class Contact
    {
        public string Name, Phone, CellPhone;

        public Contact(string Name, string Phone, string CellPhone)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.CellPhone = CellPhone;
        }

        public Contact(string Name)
        {
            this.Name = Name;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string Name)
        {
            this.Name = Name;
        }

        public string getPhone()
        {
            return Phone;
        }

        public void setPhone(string Phone)
        {
            this.Phone = Phone;
        }

        public string getCellPhone()
        {
            return CellPhone;
        }

        public void setCellPhone(string CellPhone)
        {
            this.CellPhone = CellPhone;
        }

        public bool equals(Contact contact)
        {
            if (this.Name.Trim().Equals(contact.getName().Trim())){
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Nombre: {Name}, Telefóno: {Phone}, Celular: {CellPhone}";
        }

        public string toString()
        {
            return $"Telefóno: {Phone}";
        }
    }
}
