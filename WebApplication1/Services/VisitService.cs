using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _VisitRepository;
    private readonly string _connectionString;

    public VisitService(IVisitRepository VisitRepository, IConfiguration configuration)
    {
        _VisitRepository = VisitRepository;
        _connectionString = configuration.GetConnectionString("db-mssql");
    }

    public async Task<VisitDTO> GetVisitsAsync(int id, CancellationToken cancellationToken)
    {
        var visit =await _VisitRepository.GetVisitAsync(id, cancellationToken);
        if(visit == null)
        {
            throw new InvalidOperationException("Nie ma wizyty o podanym id");
        }
        var client = await _VisitRepository.GetVisitClientAsync(id, cancellationToken);
        var mechanic = await _VisitRepository.GetVisitMechanicAsync(id, cancellationToken);
        var service = await _VisitRepository.GetVisitServiceAsync(id, cancellationToken);
        return new VisitDTO
        {
            VisiDate = DateTime.UtcNow,
            Client = client,
            Mechanic = mechanic,
            Service = service
        };
    }
}