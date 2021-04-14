using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicStoredProcedure
{
  public  class SampleDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=...;Initial Catalog=...;Persist Security Info=True;User ID=...;Password=..");
        }
    }
}
