using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Game2048.Model.Services
{
    public class ValueToColorConverter : IValueConverter
    {
        #region Colors
        private static readonly SolidColorBrush tile2Brush = GetSolidColorBrush(192, 192, 192, 255);
        private static readonly SolidColorBrush tile4Brush = GetSolidColorBrush(169, 169, 169, 255);
        private static readonly SolidColorBrush tile8Brush = GetSolidColorBrush(100, 149, 237, 255);
        private static readonly SolidColorBrush tile16Brush = GetSolidColorBrush(65, 105, 225, 255);
        private static readonly SolidColorBrush tile32Brush = GetSolidColorBrush(0, 0, 255, 255);
        private static readonly SolidColorBrush tile64Brush = GetSolidColorBrush(0, 255, 0, 255);
        private static readonly SolidColorBrush tile128Brush = GetSolidColorBrush(50, 205, 50, 255);
        private static readonly SolidColorBrush tile256Brush = GetSolidColorBrush(0, 128, 0, 255);
        private static readonly SolidColorBrush tile512Brush = GetSolidColorBrush(255, 165, 0, 255);
        private static readonly SolidColorBrush tile1024Brush = GetSolidColorBrush(255, 140, 0, 255);
        private static readonly SolidColorBrush tile2048Brush = GetSolidColorBrush(255, 69, 0, 255);
        private static readonly SolidColorBrush tileEmptyBrush = GetSolidColorBrush(18, 18, 18, 255);
        #endregion

        private static readonly Dictionary<string, Brush> tileBrushes = new()
        {
            { "2", tile2Brush },
            { "4", tile4Brush },
            { "8", tile8Brush },
            { "16", tile16Brush },
            { "32", tile32Brush },
            { "64", tile64Brush },
            { "128", tile128Brush },
            { "256", tile256Brush },
            { "512", tile512Brush },
            { "1024", tile1024Brush },
            { "2048", tile2048Brush },
        };

        /// <summary>
        /// Метод, представляющий собой конвертер, который преобразует 
        /// числовое значение в цвет.
        /// </summary>
        /// <param name="value">Входящее числовое значение.</param>
        /// <param name="targetType">Тип, в который будет преобразовано значение.</param>
        /// <param name="parameter">Необязательный параметр, используемый при преобразовании.</param>
        /// <param name="cultureInfo">Язык, который будет использоваться в конвертере.</param>
        /// <returns>Цвет, если число является степенью двойки от 1 до 11, иначе false.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            if (tileBrushes.TryGetValue(value as string, out Brush brush))
            {
                return brush;
            }
            
            else
            {
                return tileEmptyBrush;
            }
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

        /// <summary>
        /// Метод, получающий цвет для сплошного закрашивания ячейки.
        /// </summary>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        /// <returns>Цвет.</returns>
        private static SolidColorBrush GetSolidColorBrush(byte r, byte g, byte b, byte a)
        {
            return new SolidColorBrush(GetColor(r, g, b, a));
        }

        /// <summary>
        /// Метод, получающий цвет.
        /// </summary>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        /// <returns>Цвет.</returns>
        private static Color GetColor(byte r, byte g, byte b, byte a)
        {
            return new Color { R = r, G = g, B = b, A = a };
        }
    }
}