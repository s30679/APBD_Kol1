using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class VisitService
{
    private readonly IVisitRepository _repositoryRepository;
    private readonly string _connectionString;

    public VisitService(IVisitRepository repositoryRepository, IConfiguration configuration)
    {
        _repositoryRepository = repositoryRepository;
        _connectionString = configuration.GetConnectionString("db-mssql");
    }
    //
}