using MyLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DataAccess.Concrete.EntityFramework
{
    public class MyLibraryContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
