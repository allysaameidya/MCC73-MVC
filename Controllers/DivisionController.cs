﻿using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers;

public class DivisionController : Controller
{
    private DivisionRepositories _repo;

    public DivisionController(DivisionRepositories repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var result = _repo.GetAll();
        return View(result);
    }

    // GET - CREATE
    public IActionResult Create() //yang diset di Razor Create yg ini
    {
        return View();
    }

    // POST - CREATE
    [HttpPost]
    public IActionResult Create(Division division)
    {
        var result = _repo.Insert(division);
        if (result > 0)
        {
            return RedirectToAction("Index", "Division"); //kalau data 0, maka otomatis redirect ke Index yg di Division
        }
        return View();
    }

    // GET - DETAILS (By ID)
    public IActionResult Details(int id)
    {
        var result = _repo.Get(id);
        return View(result);
    }

    // GET - EDIT
    public IActionResult Edit(int id)
    {
        var result = _repo.Get(id);
        return View(result);
    }

    // POST - EDIT
    [HttpPost]
    public IActionResult Edit(Division division)
    {
        var result = _repo.Update(division);
        if (result > 0)
        {
            return RedirectToAction("Index", "Division");
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
            return RedirectToAction("Index", "Division");
        }
        return View();
    }
}
