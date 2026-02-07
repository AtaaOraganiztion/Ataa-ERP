using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Converters;

public class IdConverter() : ValueConverter<Ulid, string>(v => v.ToString(), str => Ulid.Parse(str));
