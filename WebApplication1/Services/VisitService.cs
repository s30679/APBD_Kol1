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
        if (client == null)
        {
            
        }
        var mechanic = await _VisitRepository.GetVisitMechanicAsync(id, cancellationToken);
        if (mechanic == null)
        {
            
        }
        var service = await _VisitRepository.GetVisitServiceAsync(id, cancellationToken);
        if (service == null)
        {
            
        }
        return new VisitDTO();
    }
}