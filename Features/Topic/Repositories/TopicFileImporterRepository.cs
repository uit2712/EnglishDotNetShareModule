using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;

namespace Core.Features.Topic.Repositories;

public class TopicFileImporterRepository : TopicFileImporterRepositoryInterface
{
    private FileReaderRepositoryInterface _fileReader;

    public TopicFileImporterRepository(FileReaderRepositoryInterface fileReader)
    {
        _fileReader = fileReader;
    }

    public GetListTopicsResult GetAll()
    {
        var result = new GetListTopicsResult();
        string path = @"/app/Core/Features/Topic/Data/Topics.csv";
        var getFileContentResult = _fileReader.ReadAsArray<TopicEntity>(path);

        result.Success = getFileContentResult.Success;
        result.Message = getFileContentResult.Message;
        result.Data = getFileContentResult.Data;

        return result;
    }
}