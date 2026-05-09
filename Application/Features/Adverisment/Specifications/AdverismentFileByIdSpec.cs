using Ardalis.Specification;

namespace Application.Features.Adverisment.Specifications;

public class AdverismentFileByIdSpec : Specification<Domain.Models.Adverisment.Adverisment>
{
    public AdverismentFileByIdSpec(Ulid fileId)
    {
        Query
            .Include(x => x.Files)
            .Where(x => x.Files.Any(f => f.Id == fileId));
    }
}