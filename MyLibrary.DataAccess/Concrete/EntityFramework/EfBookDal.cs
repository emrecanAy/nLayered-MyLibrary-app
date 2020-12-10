using MyLibrary.DataAccess.Abstract;
using MyLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book,MyLibraryContext>,IBookDal
    {
        
    }
}
