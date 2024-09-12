using Core.Features.Topic.InterfaceAdapters;
using Core.Models;

namespace Core.Features.Topic.UseCases;

public class SeedTopicsFromFileUseCase
{
    private SeedTopicFromFileRepositoryInterface seeder;

    public SeedTopicsFromFileUseCase(SeedTopicFromFileRepositoryInterface seeder)
    {
        this.seeder = seeder;
    }

    public Result<bool> Invoke()
    {
        return seeder.Seed();
    }
}