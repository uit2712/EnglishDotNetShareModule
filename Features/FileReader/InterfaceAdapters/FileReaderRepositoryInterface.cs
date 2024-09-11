
namespace Core.Features.FileReader.InterfaceAdapters;

public interface FileReaderRepositoryInterface
{
    public IEnumerable<dynamic> ReadAsArray(string path);
}