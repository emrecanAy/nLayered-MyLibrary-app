using MyLibrary.Business.Abstract;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.Concrete;
using MyLibrary.DataAccess.Concrete.EntityFramework;
using MyLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Business.Concrete
{
    public class BookManager:IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Add(Book book)
        {
            _bookDal.Add(book);
        }

        public void Delete(Book book)
        {
            try
            {
                _bookDal.Delete(book);
            }
            catch
            {

                throw new Exception("Silme gerçekleşemedi!");
            }
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public List<Book> GetBooksByBookName(string bookName)
        {
            return _bookDal.GetAll(p => p.BookName.ToLower().Contains(bookName.ToLower()));
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }
    }
}
