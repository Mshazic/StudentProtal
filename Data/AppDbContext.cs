using System;
using Microsoft.EntityFrameworkCore;
using Student.Models;

public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
    {
        
    }
    public Dbset<Student> Students { get; set; }
}