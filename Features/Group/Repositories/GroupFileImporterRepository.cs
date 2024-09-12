using Core.Common.InterfaceAdapters;
using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.Group.Entities;
using Core.Features.Group.Models;
using Core.Models;

namespace Core.Features.Group.Repositories;

public class GroupFileImporterRepository : DataFileImporterRepositoryInterface<Result<IEnumerable<GroupEntity>>>
{
    private FileReaderRepositoryInterface _fileReader;

    public GroupFileImporterRepository(FileReaderRepositoryInterface fileReader)
    {
        _fileReader = fileReader;
    }

    public Result<IEnumerable<GroupEntity>> GetAll()
    {
        var result = new GetListGroupsResult();
        string path = @"/app/docker/export-db/Groups.csv";
        var getFileContentResult = _fileReader.ReadAsArray<GroupEntity>(path);

        result.Success = getFileContentResult.Success;
        result.Message = getFileContentResult.Message;
        result.Data = getFileContentResult.Data;

        return result;
    }
}