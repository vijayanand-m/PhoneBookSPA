using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneBookSPA.Entities;
using PhoneBookSPA.Interface;
namespace PhoneBookSPA.Services
{
    public class PhoneBookService: IPhoneBookService
    {

        public PhoneBookService()
        {
        }

        public async Task<PhoneBook> GetPhoneBookDetails()
        {
            PhoneBook contactsList=new PhoneBook();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://www.mocky.io/v2/581335f71000004204abaf83"))
                    {
                       string apiResponse = await response.Content.ReadAsStringAsync();
                        contactsList = JsonConvert.DeserializeObject<PhoneBook>(apiResponse);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
            }
            return contactsList;
        }
    }
}
