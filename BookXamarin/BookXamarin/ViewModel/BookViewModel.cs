using BookXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookXamarin.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private List<Book> _books;
        private string _myTitle;

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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
