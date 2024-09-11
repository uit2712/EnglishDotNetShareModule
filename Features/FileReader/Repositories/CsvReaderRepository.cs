
using System.Globalization;
using Core.Features.FileReader.InterfaceAdapters;
using CsvHelper;

namespace Core.Features.FileReader.Repositories;

public class CsvReaderRepository : FileReaderRepositoryInterface
{
    public IEnumerable<dynamic> ReadAsArray(string path)
    {
        var result = new List<dynamic>();
        if (File.Exists(path) == false)
        {
            return result;
        }

        using (var reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    if (null != record)
                    {
                        result.Add(record);
                    }
                }
            }
        }

        return result;
    }
}