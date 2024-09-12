using Core.Features.Group.InterfaceAdapters;
using Core.Models;

namespace Core.Features.Group.UseCases;

public class SeedGroupsFromFileUseCase
{
    private GroupFileImporterRepositoryInterface fileImporter;
    private SeedGroupFromFileRepositoryInterface seeder;

    public SeedGroupsFromFileUseCase(SeedGroupFromFileRepositoryInterface seeder, GroupFileImporterRepositoryInterface fileImporter)
    {
        this.seeder = seeder;
        this.fileImporter = fileImporter;
    }

    public Result<bool> Invoke()
    {
        var getDataResult = fileImporter.GetAll();
        var list = null != getDataResult.Data ? getDataResult.Data : [];

        return seeder.Seed(list);
    }
}