using Application.Abstractions.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Infrastructure.Services;

public class ExcelService : IExcelService
{
    public ExcelService()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public async Task<byte[]> ExportToExcelAsync<T>(List<T> data, string worksheetName, Dictionary<string, Func<T, object?>> columnMappings)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add(worksheetName);

        var headers = columnMappings.Keys.ToArray();
        for (int i = 0; i < headers.Length; i++)
        {
            worksheet.Cells[1, i + 1].Value = headers[i];
            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
        }

        for (int i = 0; i < data.Count; i++)
        {
            var item = data[i];
            var row = i + 2;
            
            for (int j = 0; j < headers.Length; j++)
            {
                var header = headers[j];
                var valueFunc = columnMappings[header];
                var value = valueFunc(item);
                
                worksheet.Cells[row, j + 1].Value = value switch
                {
                    DateTime dateTime => dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    DateOnly dateOnly => dateOnly.ToString("yyyy-MM-dd"),
                    decimal or double or float or int or long => value,
                    bool boolean => boolean ? "Yes" : "No",
                    null => "",
                    _ => value.ToString()
                };
            }
        }

        worksheet.Cells.AutoFitColumns();
        return await Task.FromResult(await package.GetAsByteArrayAsync());
    }

    }
