using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace NP.Demos.Primitives
{
    public class EnumTypeToCollectionConverter : IValueConverter
    {
        public static EnumTypeToCollectionConverter Instance { get; } =
            new EnumTypeToCollectionConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type enumType = (value as Type) ?? targetType;

            return Enum.GetValues(enumType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
