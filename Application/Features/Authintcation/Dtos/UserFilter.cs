using SharedKernel;

namespace Application.Features.Identities.Dtos;

public sealed record UserFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
