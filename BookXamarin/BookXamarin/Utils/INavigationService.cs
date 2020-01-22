using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookXamarin.Utils
{
    public interface INavigationService
    {
        Task NavigateToAsync(Type viewModelType, object parameter);
        Task NavigateBackAsync();
    }
}
