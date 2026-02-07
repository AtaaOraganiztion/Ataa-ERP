using System.ComponentModel;
using System.Globalization;

namespace Infrastructure.Converters;

public class UlidTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
                return Ulid.Empty;

            // ULID must be 26 chars and valid base32
            if (stringValue.Length != 26)
                throw new FormatException($"ULID must be a 26-character string. Got '{stringValue}'");

            try
            {
                return Ulid.Parse(stringValue);
            }
            catch (Exception ex)
            {
                throw new FormatException($"Invalid ULID string: {stringValue}", ex);
            }
        }
        
        return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is Ulid ulid)
        {
            return ulid.ToString();
        }
        
        return base.ConvertTo(context, culture, value, destinationType);
    }
} 