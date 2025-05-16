using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IVisitService
{
    Task<VisitDTO>GetVisitsAsync(int id,CancellationToken cancellationToken);
}