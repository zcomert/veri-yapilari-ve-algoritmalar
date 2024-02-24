using Applications.Repositories;
using DataStructures.Array;
using Libs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Applications.Web.Controllers;

public class StaticArrayController : Controller
{
    private readonly RepositoryContext _context;
    private StaticArray<Car> _array;

    public StaticArrayController(RepositoryContext context)
    {
        _context = context;

    }

    public IActionResult Index()
    {
        _array = new StaticArray<Car>(_context.Cars.ToList());
        return View(_array);
    }
}