using BookXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookXamarin.Service;
using System.Windows.Input;
using Xamarin.Forms;
using BookXamarin.Utils;

namespace BookXamarin.ViewModel
{
    public class BookStoreViewModel : INotifyPropertyChanged
    {
        private List<Book> _books;
        private string _myTitle;
        protected readonly IBookService _bookService;
        protected readonly INavigationService _navigationService;

        public BookStoreViewModel(IBookService bookService, INavigationService navigationService)
        {
            _bookService = bookService;
            _navigationService = navigationService;
            Books = _bookService.GetAllBook();
        }

        public List<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public string MyTitle
        {
            get => _myTitle;
            set
            {
                _myTitle = value;
                OnPropertyChanged();
            }
        }

        public ICommand BookTappedCommand => new Command<Book>(OnBookClicked);

        private void OnBookClicked(Book selectedBook)
        {
            _navigationService.NavigateToAsync(typeof(BookDetailViewModel), selectedBook);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
