using Microsoft.AspNetCore.Mvc;

public class StudentsController : Controller
{
    [HttpGet]
    public IActionResult Add(){
        return View();
    }
}