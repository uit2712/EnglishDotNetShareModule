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

    public async Task<GetGroupResult> Invoke(int id)
    {
        return await _group.Get(id);
    }
}