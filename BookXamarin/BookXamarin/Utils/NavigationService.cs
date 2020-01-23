using BookXamarin.ViewModel;
using BookXamarin.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BookXamarin.Model;

namespace BookXamarin.Utils
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;
        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public Task NavigateBackAsync()
        {
            CurrentApplication.MainPage = new BookStoreView();
            return Task.FromResult(false);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        protected virtual Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is BookDetailView)
            {
                (page.BindingContext as BookDetailViewModel).Initialize(parameter as Book);
            }

            CurrentApplication.MainPage = page;

            return Task.FromResult(false);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(BookStoreViewModel), typeof(BookStoreView));
            _mappings.Add(typeof(BookDetailViewModel), typeof(BookDetailView));
            _mappings.Add(typeof(AddBookViewModel), typeof(AddBookView));
        }
    }
}
