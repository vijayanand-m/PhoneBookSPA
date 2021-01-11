using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBookSPA.Entities;

namespace PhoneBookSPA.Interface
{
    public interface IPhoneBookServices
    {
        Task<PhoneBook> GetPhoneBookDetails();
    }
}
