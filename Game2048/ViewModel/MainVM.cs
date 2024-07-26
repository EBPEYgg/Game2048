using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Game2048.ViewModel
{
    public class MainVM : ObservableObject
    {
        /// <summary>
        /// Конструктор класса <see cref="MainVM"/>.
        /// </summary>
        public MainVM()
        {

        }

        protected void NavigateToPage(Page page, Uri uri)
        {
            NavigationService.GetNavigationService(page).Navigate(uri);
        }
    }
}