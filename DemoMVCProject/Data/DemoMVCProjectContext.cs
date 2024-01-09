using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoMVCProject.Models;

namespace DemoMVCProject.Data
{
    public class DemoMVCProjectContext : DbContext
    {
        public DemoMVCProjectContext (DbContextOptions<DemoMVCProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DemoMVCProject.Models.EmployeeViewModel> EmployeeViewModel { get; set; } = default!;
    }
}
