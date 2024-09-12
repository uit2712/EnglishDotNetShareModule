using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Vocabulary.Entities;
using Core.Models;

namespace Core.Features.Vocabulary.UseCases;

public class SeedListVocabulariesFromFileUseCase : SeedDataFromFileUseCase<VocabularyEntity>
{
    public SeedListVocabulariesFromFileUseCase(SeedDataFromFileRepositoryInterface<VocabularyEntity> seeder, DataFileImporterRepositoryInterface<Result<IEnumerable<VocabularyEntity>>> fileImporter) : base(seeder, fileImporter)
    {
    }
}