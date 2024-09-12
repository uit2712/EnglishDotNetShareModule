using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Vocabulary.Entities;
using Core.Models;

namespace Core.Features.Vocabulary.UseCases;

public class GetListVocabulariesFromFileUseCase : GetDataFromFileUseCase<VocabularyEntity>
{
    public GetListVocabulariesFromFileUseCase(DataFileImporterRepositoryInterface<Result<IEnumerable<VocabularyEntity>>> db) : base(db)
    {
    }
}