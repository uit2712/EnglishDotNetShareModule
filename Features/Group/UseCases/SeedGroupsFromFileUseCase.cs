using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Group.Entities;
using Core.Models;

namespace Core.Features.Group.UseCases;

public class SeedGroupsFromFileUseCase : SeedDataFromFileUseCase<GroupEntity>
{
    public SeedGroupsFromFileUseCase(SeedDataFromFileRepositoryInterface<GroupEntity> seeder, DataFileImporterRepositoryInterface<Result<IEnumerable<GroupEntity>>> fileImporter) : base(seeder, fileImporter)
    {
    }
}