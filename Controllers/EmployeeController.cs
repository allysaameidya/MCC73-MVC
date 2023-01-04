using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers;

public class EmployeeController : Controller
{
    private EmployeeRepositories _repo;
    private DepartmentRepositories _drepo;

    public EmployeeController(EmployeeRepositories repo, DepartmentRepositories drepo)
    {
        _repo = repo;
        _drepo = drepo;
    }

    public IActionResult Index()
    {
        var result = _repo.GetAll();
        var dept = _drepo.GetAll();
        ViewBag.Model = dept;
        return View(result);
    }

    // GET - CREATE
    public IActionResult Create() //yang diset di Razor harus yang GET
    {
        var result = _drepo.GetAll();
        ViewBag.Model = result;
        return View();
    }

    // POST - CREATE
    [HttpPost]
    public IActionResult Create(Employee emp)
    {
        var result = _repo.Insert(emp);
        if (result > 0)
        {
            return RedirectToAction("Index", "Employee"); //kalau data 0, maka otomatis redirect ke Index yg di Division
        }
        return View();
    }

    // GET - DETAILS (By ID)
    public IActionResult Details(string nik)
    {
        var result = _repo.Get(nik);
        var dept = _drepo.GetAll();
        ViewBag.Model = dept;
        return View(result);
    }

    // GET - EDIT
    public IActionResult Edit(string nik)
    {
        var result = _repo.Get(nik);
        var dept = _drepo.GetAll();
        ViewBag.Model = dept;
        return View(result);
    }

    // POST - EDIT
    [HttpPost]
    public IActionResult Edit(Employee emp)
    {
        var result = _repo.Update(emp);
        if (result > 0)
        {
            return RedirectToAction("Index", "Employee");
        }
        return View();
    }

    // GET - Delete
    public IActionResult Delete(string nik)
    {
        var result = _repo.Get(nik);
        return View();
    }

    // POST - Delete
    [HttpPost]
    public IActionResult DeleteFor(string nik)
    {
        var result = _repo.Delete(nik);
        if (result > 0)
        {
            return RedirectToAction("Index", "Employee");
        }
        return View();
    }
}
