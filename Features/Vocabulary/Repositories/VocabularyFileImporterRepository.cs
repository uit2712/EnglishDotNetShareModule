using Core.Common.InterfaceAdapters;
using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.Models;
using Core.Models;

namespace Core.Features.Vocabulary.Repositories;

public class VocabularyFileImporterRepository : DataFileImporterRepositoryInterface<Result<IEnumerable<VocabularyEntity>>>
{
    private FileReaderRepositoryInterface _fileReader;

    public VocabularyFileImporterRepository(FileReaderRepositoryInterface fileReader)
    {
        _fileReader = fileReader;
    }

    public Result<IEnumerable<VocabularyEntity>> GetAll()
    {
        var result = new GetListVocabulariesResult();
        string path = @"/app/docker/export-db/Vocabularies.csv";
        var getFileContentResult = _fileReader.ReadAsArray<VocabularyEntity>(path);

        if (null != getFileContentResult.Data)
        {
            foreach (var item in getFileContentResult.Data)
            {
                item.Topic = null;
            }
        }

        result.Success = getFileContentResult.Success;
        result.Message = getFileContentResult.Message;
        result.Data = getFileContentResult.Data;

        return result;
    }
}