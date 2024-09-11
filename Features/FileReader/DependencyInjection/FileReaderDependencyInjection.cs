using Core.Features.FileReader.InterfaceAdapters;
using Core.Features.FileReader.Repositories;

namespace Core.Features.FileReader.DependencyInjection;

public class FileReaderDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<FileReaderRepositoryInterface, CsvReaderRepository>();
    }
}