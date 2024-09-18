using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

#region Document
/// <summary>
/// Tools > Nuget Package Manager > Package Manager Console > Default Project: Data
/// Add-Migration Example1
/// Update-Database
/// Remove-Migration
/// Script-Migration
/// Drop-Database
/// </summary>
#endregion

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) :base (dbContextOptions)
        {  
        }
    
    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Comment> Comments{get; set;}
    }
}