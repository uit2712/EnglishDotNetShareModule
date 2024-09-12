using Core.Common.InterfaceAdapters;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Repositories;
using Core.Models;

namespace Core.Features.Vocabulary.DependencyInjection;

public class VocabularyDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<VocabularyRepositoryInterface, VocabularyRepository>();
        services.AddScoped<CachedVocabularyRepositoryInterface, CachedVocabularyRepository>();
        services.AddScoped<DataFileImporterRepositoryInterface<Result<IEnumerable<VocabularyEntity>>>, VocabularyFileImporterRepository>();
    }
}