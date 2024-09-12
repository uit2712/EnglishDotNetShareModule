using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Repositories;
using Core.Features.Group.UseCases;

namespace Core.Features.Group.DependencyInjection;

public class GroupDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<GroupFileImporterRepositoryInterface, GroupFileImporterRepository>();
        services.AddScoped<GroupRepositoryInterface, GroupRepository>();
        services.AddScoped<CachedGroupRepositoryInterface, CachedGroupRepository>();
        services.AddScoped<SeedGroupFromFileRepositoryInterface, SeedGroupFromFileRepository>();

        services.AddScoped<GetAllGroupsUseCase, GetAllGroupsUseCase>();
        services.AddScoped<GetGroupByIdUseCase, GetGroupByIdUseCase>();
        services.AddScoped<GetListTopicsByGroupIdUseCase, GetListTopicsByGroupIdUseCase>();
        services.AddScoped<SeedGroupsFromFileUseCase, SeedGroupsFromFileUseCase>();
    }
}