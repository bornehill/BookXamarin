using BookXamarin.Service;
using BookXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookXamarin
{
    public partial class MainPage : ContentPage
    {
        public BookViewModel books;

        public MainPage()
        {
            InitializeComponent();
            var ser = new BookService();
            books = new BookViewModel();
            books.Books = ser.GetAllBook();
            BindingContext = books;                
        }
    }
}
