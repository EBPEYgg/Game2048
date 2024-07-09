using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace Game2048.Model.Services
{
    public class IntArrayToObservableCollectionConverter : IValueConverter
    {
        /// <summary>
        /// Метод, представляющий собой конвертер, который преобразует 
        /// массив чисел в <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <param name="value">Массив чисел.</param>
        /// <param name="targetType">Тип, в который будет преобразовано значение.</param>
        /// <param name="parameter">Необязательный параметр, используемый при преобразовании.</param>
        /// <param name="cultureInfo">Язык, который будет использоваться в конвертере.</param>
        /// <returns>ObservableCollection если true, иначе false.</returns>
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

        /// <summary>
        /// ConverterBack не поддерживается.
        /// </summary>
        /// <param name="value">Значение для обратного преобразования.</param>
        /// <param name="targetType">Тип, к которому значение будет преобразовано обратно.</param>
        /// <param name="parameter">Необязательный параметр, используемый при преобразовании.</param>
        /// <param name="culture">Язык, который будет использоваться в конвертере.</param>
        /// <returns>Вызывает исключение NotSupportedException.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotSupportedException();
        }
    }
}