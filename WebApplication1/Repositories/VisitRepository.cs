using System.Data;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly string _connectionString;

    public VisitRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }

    public async Task<Visit> GetVisitAsync(int visitId, CancellationToken cancellationToken)
    {
        await using var con=new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        await using var com = new SqlCommand(@"SELECT * FROM Visits
            FROM [Visit]
            WHERE VisitId = @VisitId", con);
        com.Parameters.AddWithValue("@VisitId", visitId);
        await using var reader = await com.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Visit
            {
                visit_id = reader.GetInt32(reader.GetOrdinal("visit_id")),
                client_id = reader.GetInt32(reader.GetOrdinal("client_id")),
                mechanic_id = reader.GetInt32(reader.GetOrdinal("mechanic_id")),
                date = reader.GetDateTime(reader.GetOrdinal("date")),
            };
        }
        return null;
    }

    public async Task<Client> GetVisitClientAsync(int visitId, CancellationToken cancellationToken)
    {
        await using var con=new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        await using var com = new SqlCommand(@"SELECT client_id FROM Visits
            FROM [Visit]
            WHERE visit_id = @VisitId", con);
        com.Parameters.AddWithValue("@VisitId", visitId);
        await using var reader2 = await com.ExecuteReaderAsync(cancellationToken);
        var id_client = reader2.GetInt32(reader2.GetOrdinal("client_id"));
        await using var com2 = new SqlCommand(@"SELECT * FROM Clients
            FROM [Client]
            WHERE client_id = @id_client", con);
        com2.Parameters.AddWithValue("@id_client", id_client);
        await using var reader = await com2.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Client
            {
                client_id = reader.GetInt32(reader.GetOrdinal("client_id")),
                first_name = reader.GetString(reader.GetOrdinal("first_name")),
                last_name = reader.GetString(reader.GetOrdinal("last_name")),
                date_of_birth = reader.GetDateTime(reader.GetOrdinal("date_of_birth")),
            };
        }
        return null;
    }

    public async Task<Mechanic> GetVisitMechanicAsync(int visitId, CancellationToken cancellationToken)
    {
        await using var con=new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        await using var com = new SqlCommand(@"SELECT mechanic_id FROM Visits
            FROM [Visit]
            WHERE visit_id = @VisitId", con);
        com.Parameters.AddWithValue("@VisitId", visitId);
        await using var reader2 = await com.ExecuteReaderAsync(cancellationToken);
        var id_mechanic = reader2.GetInt32(reader2.GetOrdinal("mechanic_id"));
        await using var com2 = new SqlCommand(@"SELECT * FROM Clients
            FROM [Client]
            WHERE mechanic_id = @id_mechanic", con);
        com2.Parameters.AddWithValue("@id_mechanic", id_mechanic);
        await using var reader = await com2.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Mechanic
            {
                mechanic_id = reader.GetInt32(reader.GetOrdinal("mechanic_id")),
                first_name = reader.GetString(reader.GetOrdinal("first_name")),
                last_name = reader.GetString(reader.GetOrdinal("last_name")),
                licence_number = reader.GetString(reader.GetOrdinal("licence_number")),
            };
        }
        return null;
    }

    public async Task<Service> GetVisitServiceAsync(int visitId, CancellationToken cancellationToken)
    {
        await using var con=new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        await using var com = new SqlCommand(@"SELECT service_id FROM Visit_Service
            FROM [Visit_Service]
            WHERE visit_id = @VisitId", con);
        com.Parameters.AddWithValue("@VisitId", visitId);
        await using var reader2 = await com.ExecuteReaderAsync(cancellationToken);
        var id_service = reader2.GetInt32(reader2.GetOrdinal("service_id"));
        await using var com2 = new SqlCommand(@"SELECT * FROM Service
            FROM [Service]
            WHERE service_id = @id_service", con);
        com2.Parameters.AddWithValue("@id_service", id_service);
        await using var reader = await com2.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Service
            {
                service_id = reader.GetInt32(reader.GetOrdinal("service_id")),
                name = reader.GetString(reader.GetOrdinal("name")),
                base_fee = reader.GetDecimal(reader.GetOrdinal("base_fee"))
            };
        }
        return null;
    }
}