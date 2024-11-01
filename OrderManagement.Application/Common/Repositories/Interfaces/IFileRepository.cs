namespace OrderManagement.Application.Common.Repositories.Interfaces;

public interface IFileRepository
{
    Task WriteAsync(string order, CancellationToken cancellationToken = default);
}