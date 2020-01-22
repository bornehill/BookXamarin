using BookXamarin.Service;
using BookXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookStoreView : ContentPage
    {
        public BookViewModel books;

        public BookStoreView()
        {
            InitializeComponent();
            var ser = new BookService();
            books = new BookViewModel();
            books.Books = ser.GetAllBook();
            BindingContext = books;
        }
    }
}