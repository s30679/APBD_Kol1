using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Models;

public class Client
{
    public int client_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public DateTime date_of_birth { get; set; }
}