using System.Data;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using StudentPortal.Models.StudentAccountEntity;

public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
    {
        
    }
    public DbSet<Student>? Students { get; set; }
    //Accounts

    public DbSet<StudentUser>? StudentUserAccounts { get; set; }


    public DbSet<UserAccount>? UserAccount { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}