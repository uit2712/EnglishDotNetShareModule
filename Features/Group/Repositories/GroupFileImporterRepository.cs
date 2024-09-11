using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;

namespace Core.Features.Group.Repositories;

public class GroupFileImporterRepository : GroupFileImporterRepositoryInterface
{
    private FileReaderRepositoryInterface _fileReader;

    public GroupFileImporterRepository(FileReaderRepositoryInterface fileReader)
    {
        _fileReader = fileReader;
    }

    public GetListGroupsResult GetAll()
    {
        var result = new GetListGroupsResult();
        string path = @"/app/Core/Features/Group/Data/Groups.csv";
        var getFileContentResult = _fileReader.ReadAsArray<GroupEntity>(path);

        result.Success = getFileContentResult.Success;
        result.Message = getFileContentResult.Message + ": " + path;
        result.Data = getFileContentResult.Data;

        return result;
    }
}