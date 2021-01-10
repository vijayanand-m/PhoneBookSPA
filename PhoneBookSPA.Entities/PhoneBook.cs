using System;
using System.Collections.Generic;

namespace PhoneBookSPA.Entities
{
    public class PhoneBook
    {

        public IList<Contacts> Contacts { get; set; }
        
    }

    public class Contacts
    {
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }
}
