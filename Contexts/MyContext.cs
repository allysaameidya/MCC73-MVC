﻿using MCC73MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Contexts;

public class MyContext : DbContext
{
	public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

	}

	public DbSet<Division> Divisions { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Account> Accounts { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<AccountRole> AccountRoles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

        // Configure Unique Constraint
        modelBuilder.Entity<Employee>().HasAlternateKey(e => e.Email);

        // One Employee to One Account
        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Account)
            .WithOne(e => e.Employee)
            .HasForeignKey<Account>(a => a.NIK);
    }
}
