using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhoneBookSPA.Entities;
using PhoneBookSPA.Interface;
namespace PhoneBookSPA.Services
{
    public class PhoneBookServices: IPhoneBookServices
    {
        private readonly IConfiguration _config;
        public PhoneBookServices(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Get all the phone book details
        /// </summary>
        /// <returns></returns>
        public async Task<PhoneBook> GetPhoneBookDetails()
        {
            var mockDataURL = _config["MockData"];
            PhoneBook contactsList=new PhoneBook();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(mockDataURL))
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
