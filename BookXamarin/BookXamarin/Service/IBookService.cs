using BookXamarin.Model;
using BookXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookXamarin.Service
{
    public interface IBookService
    {
        List<Book> GetAllBook();
    }
}
