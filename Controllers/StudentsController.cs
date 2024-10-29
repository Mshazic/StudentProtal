using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

public class StudentsController : Controller
{
    private readonly AppDbcontext dbContext;
    public StudentsController(AppDbcontext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddStudentViewModel viewModel)
    {
        var student = new Student
        {
            Name = viewModel.Name,
            Email = viewModel.Email
        };
        await dbContext.Students.AddAsync(student);
        await dbContext.SaveChangesAsync();

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var students = await dbContext.Students.ToListAsync();
        return View(students);
    }
  
   [HttpGet]
   public async Task<IActionResult> Edit(Guid id)
    {
     var student = await dbContext.Students.FirstOrDefaultAsync();
     return View(student);

   }
  [HttpPost]
public async Task<IActionResult> Edit(Student viewModel)
{
var student = await dbContext.Students.FindAsync(viewModel.Id);
 if(student is not null)
 {
    student.Name = viewModel.Name;
    student.Email = viewModel.Email;

    await dbContext.SaveChangesAsync();
 }
 return RedirectToAction("List","Students");
}

 [HttpPost]
 public async Task<IActionResult> Delete(Student viewModel)
 {
   var student = await dbContext.Students.AsNoTracking()
   .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
   if (student is not null)
   {
    dbContext.Students.Remove(viewModel);
    await dbContext.SaveChangesAsync();
   }
   return RedirectToAction("List","Students");
 }


}