using AnhPhatMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnhPhatMVC.Context
{
    public class AnhPhatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}