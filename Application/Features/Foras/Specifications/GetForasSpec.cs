using Ardalis.Specification;
using Application.Features.Foras.Dtos;

namespace Application.Features.Foras.Specifications;

public class GetForasSpec : Specification<Domain.Models.Foras.Foras>
{
    public GetForasSpec(ForasFilter filter)
    {
        Query.AsSplitQuery()
             .AsNoTracking()
             .Include(x => x.Files)
             .Where(x => !x.IsDeleted);

        if (!string.IsNullOrWhiteSpace(filter.Title))
            Query.Where(x => x.Title != null && x.Title.Contains(filter.Title));

        if (filter.startdate.HasValue)
            Query.Where(x => x.StartDate >= filter.startdate.Value);

        if (filter.enddate.HasValue)
            Query.Where(x => x.EndDate <= filter.enddate.Value);

        if (!string.IsNullOrWhiteSpace(filter.Description))
            Query.Where(x => x.Description != null &&
                                        x.Description.Contains(filter.Description));

        if (filter.CreatedByUserId.HasValue)
            Query.Where(x => x.CreatedByUserId == filter.CreatedByUserId.Value);
    }
}
