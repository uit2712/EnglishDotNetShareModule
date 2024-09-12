using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Group.Entities;
using Core.Models;

namespace Core.Features.Group.UseCases;

public class GetListGroupsFromFileUseCase : GetDataFromFileUseCase<GroupEntity>
{
    public GetListGroupsFromFileUseCase(DataFileImporterRepositoryInterface<Result<IEnumerable<GroupEntity>>> db) : base(db)
    {
    }
}