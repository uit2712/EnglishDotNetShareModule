using Core.Features.Topic.InterfaceAdapters;
using Core.Models;

namespace Core.Features.Topic.UseCases;

public class SeedTopicsFromFileUseCase
{
    private SeedTopicFromFileRepositoryInterface seeder;
    private TopicFileImporterRepositoryInterface fileImporter;

    public SeedTopicsFromFileUseCase(SeedTopicFromFileRepositoryInterface seeder, TopicFileImporterRepositoryInterface fileImporter)
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