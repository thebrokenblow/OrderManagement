namespace OrderManagement.Application.Interfaces;

public interface IFileRepository
{
    Task WriteAsync(string order, CancellationToken cancellationToken);
}