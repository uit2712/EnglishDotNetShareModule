using Core.Common.InterfaceAdapters;
using Core.Models;

namespace Core.Common.UseCases;

public class SeedDataFromFileUseCase<TItem>
{
    private DataFileImporterRepositoryInterface<Result<IEnumerable<TItem>>> fileImporter;
    private SeedDataFromFileRepositoryInterface<TItem> seeder;

    public SeedDataFromFileUseCase(SeedDataFromFileRepositoryInterface<TItem> seeder, DataFileImporterRepositoryInterface<Result<IEnumerable<TItem>>> fileImporter)
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