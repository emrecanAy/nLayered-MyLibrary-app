using MyLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        List<Book> GetBooksByBookName(string bookName);
    }
}
