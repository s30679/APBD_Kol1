namespace WebApplication1.Repositories;

public class VisitRepository
{
    private readonly string _connectionString;

    public VisitRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }
    //
}