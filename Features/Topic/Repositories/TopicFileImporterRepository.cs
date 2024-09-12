using Core.Common.InterfaceAdapters;
using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.Topic.Entities;
using Core.Features.Topic.Models;
using Core.Models;

namespace Core.Features.Topic.Repositories;

public class TopicFileImporterRepository : DataFileImporterRepositoryInterface<Result<IEnumerable<TopicEntity>>>
{
    private FileReaderRepositoryInterface _fileReader;

    public TopicFileImporterRepository(FileReaderRepositoryInterface fileReader)
    {
        _fileReader = fileReader;
    }

    public Result<IEnumerable<TopicEntity>> GetAll()
    {
        var result = new GetListTopicsResult();
        string path = @"/app/docker/export-db/Topics.csv";
        var getFileContentResult = _fileReader.ReadAsArray<TopicEntity>(path);

        result.Success = getFileContentResult.Success;
        result.Message = getFileContentResult.Message;
        result.Data = getFileContentResult.Data;

        return result;
    }
}