using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace MCC73MVC.Controllers;

public class DepartmentController : Controller
{
    private DepartmentRepositories _repo;
    private DivisionRepositories _divrepo;

    public DepartmentController(DepartmentRepositories repo, DivisionRepositories divrepo)
    {
        _repo= repo;
        _divrepo = divrepo;
    }

    public IActionResult Index()
    {
        var result = _repo.GetAll();
        var div = _divrepo.GetAll();
        ViewBag.Model = div;
        return View(result);
    }

    // GET - CREATE
    public IActionResult Create() //yang diset di Razor Create yg ini
    {
        var result = _divrepo.GetAll();
        ViewBag.Model = result;
        return View();
    }

    // POST - CREATE
    [HttpPost]
    public IActionResult Create(Department department)
    {
        var result = _repo.Insert(department);
        if (result > 0)
        {
            return RedirectToAction("Index", "Department"); //kalau data 0, maka otomatis redirect ke Index yg di Division
        }
        return View();
    }

    // GET - DETAILS (By ID)
    public IActionResult Details(int id)
    {
        var result = _repo.Get(id);
        var div = _divrepo.GetAll();
        ViewBag.Model = div;
        return View(result);
    }

    // GET - EDIT
    public IActionResult Edit(int id)
    {
        var result = _repo.Get(id);
        var div = _divrepo.GetAll();
        ViewBag.Model = div;
        return View(result);
    }

    // POST - EDIT
    [HttpPost]
    public IActionResult Edit(Department department)
    {
        var result = _repo.Update(department);
        if (result > 0)
        {
            return RedirectToAction("Index", "Department");
        }
        return View();
    }

    // GET - Delete
    public IActionResult Delete(int id)
    {
        var result = _repo.Get(id);
        return View();
    }

    // POST - Delete
    [HttpPost]
    public IActionResult DeleteFor(int id)
    {
        var result = _repo.Delete(id);
        if (result > 0)
        {
            return RedirectToAction("Index", "Department");
        }
        return View();
    }
}
