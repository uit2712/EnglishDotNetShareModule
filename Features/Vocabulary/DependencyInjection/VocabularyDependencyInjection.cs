using Core.Common.InterfaceAdapters;
using Core.Common.UseCases;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Core.Features.Vocabulary.Repositories;
using Core.Features.Vocabulary.UseCases;
using Core.Models;

namespace Core.Features.Vocabulary.DependencyInjection;

public class VocabularyDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<Result<IEnumerable<VocabularyEntity>>, GetListVocabulariesResult>();
        services.AddScoped<VocabularyRepositoryInterface, VocabularyRepository>();
        services.AddScoped<CachedVocabularyRepositoryInterface, CachedVocabularyRepository>();
        services.AddScoped<DataFileImporterRepositoryInterface<Result<IEnumerable<VocabularyEntity>>>, VocabularyFileImporterRepository>();
        services.AddScoped<SeedDataFromFileRepositoryInterface<VocabularyEntity>, SeedVocabularyFromFileRepository>();

        services.AddScoped<GetDataFromFileUseCase<VocabularyEntity>, GetListVocabulariesFromFileUseCase>();
        services.AddScoped<SeedDataFromFileUseCase<VocabularyEntity>, SeedListVocabulariesFromFileUseCase>();
    }
}