using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Topic.Entities;
using Core.Models;

namespace Core.Features.Topic.UseCases;

public class SeedTopicsFromFileUseCase : SeedDataFromFileUseCase<TopicEntity>
{
    public SeedTopicsFromFileUseCase(SeedDataFromFileRepositoryInterface<TopicEntity> seeder, DataFileImporterRepositoryInterface<Result<IEnumerable<TopicEntity>>> fileImporter) : base(seeder, fileImporter)
    {
    }
}