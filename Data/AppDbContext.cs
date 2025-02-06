using System.Data;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using StudentPortal.Models.StudentAccountEntity;

public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
    {
        
    }
    //this is when I create the user when I have logged in as admin
    // Admin functionality still coming
    public DbSet<Student>? Students { get; set; }

    //Accounts
    //This is when i register a user
    public DbSet<StudentUser>? StudentUserAccounts { get; set; }


    public DbSet<UserAccount>? UserAccount { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}