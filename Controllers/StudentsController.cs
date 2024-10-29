using Microsoft.AspNetCore.Mvc;

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
}