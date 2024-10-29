using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
  

}