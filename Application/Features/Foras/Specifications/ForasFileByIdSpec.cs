using Ardalis.Specification;

namespace Application.Features.Foras.Specifications;

public class ForasFileByIdSpec : Specification<Domain.Models.Foras.Foras>
{
    public ForasFileByIdSpec(Ulid fileId)
    {
        Query
            .Include(x => x.Files)
            .Where(x => x.Files.Any(f => f.Id == fileId));
    }
}
