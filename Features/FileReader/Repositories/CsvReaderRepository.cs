
using System.Globalization;
using Core.Features.FileReader.InterfaceAdapters;
using Core.Models;
using CsvHelper;

namespace Core.Features.FileReader.Repositories;

public class CsvReaderRepository : FileReaderRepositoryInterface
{
    public Result<IEnumerable<T>> ReadAsArray<T>(string path)
    {
        var result = new Result<IEnumerable<T>>();
        var Data = new List<T>();

        if (File.Exists(path) == false)
        {
            result.Message = "File not exists";
            return result;
        }

        using (var reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();
                foreach (var record in records)
                {
                    if (null != record)
                    {
                        Data.Add(record);
                    }
                }
            }
        }

        result.Success = true;
        result.Message = "Get data success";
        result.Data = Data;
        return result;
    }
}