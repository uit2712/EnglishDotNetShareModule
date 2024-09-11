using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;

namespace Core.Features.Group.UseCases;

public class GetAllGroupsUseCase
{
    private CachedGroupRepositoryInterface _group;

    public GetAllGroupsUseCase(CachedGroupRepositoryInterface group)
    {
        _group = group;
    }

    public async Task<GetListGroupsResult> Invoke()
    {
        return await _group.GetAll();
    }
}