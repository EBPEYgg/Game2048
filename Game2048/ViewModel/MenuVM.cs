using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows;

namespace Game2048.ViewModel
{
    public partial class MenuVM : MainVM
    {
        /// <summary>
        /// Команда, которая меняет текущую страницу на страницу с игрой.
        /// </summary>
        public NavigationCommand NavigateToGamePage
        { 
            get => new(NavigateToPage, 
                       new Uri("View/Pages/GamePage.xaml", 
                       UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Команда, которая меняет текущую страницу на страницу со статистикой.
        /// </summary>
        public NavigationCommand NavigateToStatisticsPage
        {
            get => new(NavigateToPage,
                       new Uri("View/Pages/StatisticsPage.xaml",
                       UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// <inheritdoc cref="Application.Shutdown()"/>
        /// </summary>
        [RelayCommand]
        public void Quit() => Application.Current.Shutdown();
    }
}