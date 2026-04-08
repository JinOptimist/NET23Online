using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    public IActionResult Index()
    {
        return View();
    } 
    
    public IActionResult Statistics()
    {
        return View();
    } 
    
    public IActionResult Diary()
    {
        return View();
    } 
}