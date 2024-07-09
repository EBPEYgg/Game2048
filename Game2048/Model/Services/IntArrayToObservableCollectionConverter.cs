using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace Game2048.Model.Services
{
    public class IntArrayToObservableCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            if (value is not int[,] intArray)
            {
                return null;
            }

            ObservableCollection<ObservableCollection<string>> observableCollection = new();

            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                ObservableCollection<string> innerCollection = new();
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    innerCollection.Add(intArray[i, j] != 0 ? intArray[i, j].ToString() : "");
                }
                observableCollection.Add(innerCollection);
            }

            return observableCollection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}