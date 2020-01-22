using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookXamarin.ViewModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BookXamarin.Model;

namespace BookXamarin.Service
{
    public class BookService : IBookService
    {
        public List<Book> GetAllBook()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.GetAsync("http://my-json-server.typicode.com/jcgaribayr/fake-rest/books").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var books = JsonConvert.DeserializeObject<List<Book>>(jsonResult);
                return books;
            }

            return new List<Book>();
        }
    }
}
