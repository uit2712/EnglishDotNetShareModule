using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;

namespace Core.Features.Topic.UseCases;

public class GetTopicsFromFileUseCase
{
    private TopicFileImporterRepositoryInterface db;

    public GetTopicsFromFileUseCase(TopicFileImporterRepositoryInterface db)
    {
        this.db = db;
    }

    public GetListTopicsResult Invoke()
    {
        return db.GetAll();
    }
}