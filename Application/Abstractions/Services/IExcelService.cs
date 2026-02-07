

namespace Application.Abstractions.Services;

public interface IExcelService
{
    Task<byte[]> ExportToExcelAsync<T>(List<T> data, string worksheetName, Dictionary<string, Func<T, object?>> columnMappings);
    
}