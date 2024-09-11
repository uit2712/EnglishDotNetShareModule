using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;

namespace Core.Features.Group.UseCases;

public class GetAllGroupsFromFileUseCase
{
    private GroupFileImporterRepositoryInterface _group;

    public GetAllGroupsFromFileUseCase(GroupFileImporterRepositoryInterface group)
    {
        _group = group;
    }

    public GetListGroupsResult Invoke()
    {
        return _group.GetAll();
    }
}