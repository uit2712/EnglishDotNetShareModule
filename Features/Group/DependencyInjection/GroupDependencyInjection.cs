using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Repositories;
using Core.Features.Group.UseCases;

namespace Core.Features.Group.DependencyInjection;

public class GroupDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<GroupRepositoryInterface, GroupRepository>();
        services.AddScoped<CachedGroupRepositoryInterface, CachedGroupRepository>();

        services.AddScoped<GetAllGroupsUseCase, GetAllGroupsUseCase>();
        services.AddScoped<GetGroupByIdUseCase, GetGroupByIdUseCase>();
        services.AddScoped<GetListTopicsByGroupIdUseCase, GetListTopicsByGroupIdUseCase>();
    }
}