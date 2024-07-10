using System;
using System.Collections.ObjectModel;
using Game2048.Model;
using Game2048.Model.Services;

namespace Game2048.ViewModel
{
    public class StatisticsVM : MainVM
    {
        public NavigationCommand NavigateToMenuPage
        {
            get => new(NavigateToPage, new Uri("View/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public ObservableCollection<Player> StatisticsCollection
        {
            get => StatisticsSerializer.LoadPlayer();
        }
    }
}