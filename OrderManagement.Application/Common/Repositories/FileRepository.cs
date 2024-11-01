using OrderManagement.Application.Common.Repositories.Interfaces;

namespace OrderManagement.Application.Common.Repositories;

public class FileRepository : IFileRepository
{
    private const string Path = @"C:\Users\Artem\Documents\result.txt";
    
    public async Task WriteAsync(string order, CancellationToken cancellationToken)
    {
        if (File.Exists(Path))
        {
            await using var file = File.AppendText(Path);
            await file.WriteLineAsync(order);
        }
        else
        {
            await using var file = File.CreateText(Path);
            await file.WriteLineAsync(order);
        }
    }
}