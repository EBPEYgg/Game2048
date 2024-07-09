using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Game2048.Model.Services
{
    public class ValueToColorConverter : IValueConverter
    {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }

        private static SolidColorBrush GetSolidColorBrush(byte r, byte g, byte b, byte a)
        {
            return new SolidColorBrush(GetColor(r, g, b, a));
        }

        private static Color GetColor(byte r, byte g, byte b, byte a)
        {
            return new Color { R = r, G = g, B = b, A = a };
        }
    }
}