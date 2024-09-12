using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;

namespace Core.Features.Group.UseCases;

public class GetGroupByIdUseCase
{
    private CachedGroupRepositoryInterface _group;

    public GetGroupByIdUseCase(CachedGroupRepositoryInterface group)
    {
        _group = group;
    }

    public async Task<GetGroupResult> Invoke(int? id)
    {
        var validId = id.HasValue ? id.Value : 0;

        return await _group.Get(validId);
    }
}