using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEMOCRUD.Models.db;
public class SettingController : Controller
{
    private readonly NorthwindContext _context;
       public SettingController(NorthwindContext context)
        {
            _context = context;
        }
   public async Task<IActionResult> Index()
    {
         var northwindContext = _context.Categories;
            return View(await northwindContext.ToListAsync());
    }
    public IActionResult CategoriesSetting()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }         
}