using Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Conventions;

public static class UlidConvention
{
    public static void AddUlidConvention(this ModelConfigurationBuilder builder)
    {
        builder
            .Properties<Ulid>()
            .HaveConversion<IdConverter>()
            .HaveMaxLength(BaseConstraints.IdMaxLength);
    }

}
