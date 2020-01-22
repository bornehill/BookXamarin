using System.Windows.Input;
using Xamarin.Forms;
using BookXamarin.Utils;
using BookXamarin.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookXamarin.ViewModel
{
    public class BookDetailViewModel : INotifyPropertyChanged
    {
        public Book _showBook;
        protected readonly INavigationService _navigationService;

        public BookDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Initialize(Book book)
        {
            ShowBook = book;
        }

        public Book ShowBook
        {
            get => _showBook;
            set
            {
                _showBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackCommand => new Command(OnBackBottom);

        private void OnBackBottom()
        {
            _navigationService.NavigateBackAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
