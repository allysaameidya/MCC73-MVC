using MCC73MVC.Contexts;
using MCC73MVC.Handlers;
using MCC73MVC.Models;
using MCC73MVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories.Data;

public class AccountRepositories : GeneralRepository<Account, string>
{
    private MyContext _context;
    private DbSet<Account> _account;
    public AccountRepositories(MyContext context) : base(context)
    {
        _context = context;
        _account = context.Set<Account>();
    }

    public int Register(RegisterVM reg)
    {
        var cekEmail = _context.Employees.Where(e => e.Email == reg.Email);
        if (cekEmail.Count() == 1)
        {
            return 0;
        }

        var emp = new Employee()
        {
            NIK = reg.NIK,
            FirstName = reg.FirstName,
            LastName = reg.LastName,
            Gender = (Jk)reg.Gender,
            Email = reg.Email,
            Account = new Account()
            {
                NIK = reg.NIK,
                Password = Hashing.HashPassword(reg.Password),
            }
        };
        _context.Employees.Add(emp);
        _context.SaveChanges();

        var division = new Division()
        {
            Name = reg.DivisionName
        };
        _context.Divisions.Add(division);
        _context.SaveChanges();

        var department = new Department()
        {
            Name = reg.DepartmentName
            //DivisionId = division.Id
        };
        _context.Departments.Add(department);
        _context.SaveChanges();

        //AccountRole accountRole = new AccountRole()
        //{
        //    AccountNIK = reg.NIK
        //    RoleId = 1;
        //};
        //_context.AccountRoles.Add(accountRole);
        //_context.SaveChanges();

        return 1;
    }

    public int Login(LoginVM login)
    {
        var result = _account.Join(_context.Employees, a => a.NIK, e => e.NIK, (a, e) => new LoginVM
        {
            Email = e.Email,
            Password = a.Password
        }).SingleOrDefault(c => c.Email == login.Email);

        if (result == null)
        {
            return 0; //Email Tidak Terdaftar
        }
        if (!Hashing.ValidatePassword(login.Password, result.Password))
        {
            return 1; //Password Salah
        }
        return 2; //Email dan Password Benar
    }

    public List<string> UserRoles(string email)
    {
        var result = (from e in _context.Employees
                      join acc in _account on e.NIK equals acc.NIK
                      join a in _context.AccountRoles on acc.NIK equals a.AccountNIK
                      join r in _context.Roles on a.RoleId equals r.Id
                      where e.Email == email
                      select r.Name.ToString())
                      .ToList();

        return result;
    }   

}
