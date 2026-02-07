using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Converters;

public class EnumConverter<TEnum>() : ValueConverter<TEnum, string>(v => v.ToString(), str => Enum.Parse<TEnum>(str))
    where TEnum : struct;
