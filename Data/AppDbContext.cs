using System.Data;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
    {
        
    }
    public DbSet<Student>? Students { get; set; }
}