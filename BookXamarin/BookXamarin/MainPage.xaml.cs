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
        public BookStoreViewModel books;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
