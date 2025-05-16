using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class VisitDTO
{
    public DateTime VisiDate { get; set; }
    public Client Client { get; set; }
    public Mechanic Mechanic { get; set; }
    public Service Service { get; set; }
}