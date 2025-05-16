using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IVisitRepository
{
    Task<Visit> GetVisitAsync(int visitId, CancellationToken cancellationToken);
    Task<Client>GetVisitClientAsync(int visitId, CancellationToken cancellationToken);
    Task<Mechanic>GetVisitMechanicAsync(int visitId, CancellationToken cancellationToken);
    Task<Service>GetVisitServiceAsync(int visitId, CancellationToken cancellationToken);
}