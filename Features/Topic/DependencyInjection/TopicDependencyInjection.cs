using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.UseCases;

namespace Core.Features.Topic.DependencyInjection;

public class TopicDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<TopicRepositoryInterface, TopicRepository>();
        services.AddScoped<CachedTopicRepositoryInterface, CachedTopicRepository>();
        services.AddScoped<TopicFileImporterRepositoryInterface, TopicFileImporterRepository>();
        services.AddScoped<SeedTopicFromFileRepositoryInterface, SeedTopicFromFileRepository>();

        services.AddScoped<GetListVocabulariesByTopicIdUseCase, GetListVocabulariesByTopicIdUseCase>();
        services.AddScoped<UpdateTopicUseCase, UpdateTopicUseCase>();
        services.AddScoped<GetTopicByIdUseCase, GetTopicByIdUseCase>();
        services.AddScoped<SeedTopicsFromFileUseCase, SeedTopicsFromFileUseCase>();
        services.AddScoped<GetTopicsFromFileUseCase, GetTopicsFromFileUseCase>();
    }
}