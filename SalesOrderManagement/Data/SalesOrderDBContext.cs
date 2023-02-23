using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Entities;

namespace SalesOrderManagement.Api.Data
{
    public class SalesOrderDBContext : DbContext
    {
        public SalesOrderDBContext(DbContextOptions<SalesOrderDBContext> options): base(options)
        {
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
    }
}
