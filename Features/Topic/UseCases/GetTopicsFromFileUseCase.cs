using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Topic.Entities;
using Core.Models;

namespace Core.Features.Topic.UseCases;

public class GetTopicsFromFileUseCase : GetDataFromFileUseCase<TopicEntity>
{
    public GetTopicsFromFileUseCase(DataFileImporterRepositoryInterface<Result<IEnumerable<TopicEntity>>> db) : base(db)
    {
    }
}