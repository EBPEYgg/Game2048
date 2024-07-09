using System;
using Game2048.ViewModel;

namespace Game2048.ViewModel
{
    public class MenuVM : MainVM
    {
        public NavigationCommand NavigateToGamePage
        { 
            get => new(NavigateToPage, 
                       new Uri("View/Pages/GamePage.xaml", 
                       UriKind.RelativeOrAbsolute));
        }

        public NavigationCommand NavigateToStatisticsPage
        {
            get => new(NavigateToPage,
                       new Uri("View/Pages/StatisticsPage.xaml",
                       UriKind.RelativeOrAbsolute));
        }

        public RelayCommand QuitCommand
        {
            get => new(Quit);
        }
    }
}