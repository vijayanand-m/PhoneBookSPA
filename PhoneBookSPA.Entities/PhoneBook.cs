using System;
using System.Collections.Generic;

namespace PhoneBookSPA.Entities
{
    public class PhoneBook
    {

        public List<Contacts> Contacts { get; set; }
        public PhoneBook()
        {
            Contacts = new List<Contacts>();
        }
        
    }

    public class Contacts
    {
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }
}
