using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Movia.Models;

namespace Movia.Data;

[Keyless]
public class TrafficContext : DbContext
{
     public TrafficContext () { }
    public TrafficContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TrafficData> Traffic { get; set; }
}