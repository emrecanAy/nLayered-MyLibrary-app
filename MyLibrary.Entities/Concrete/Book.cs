using MyLibrary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Entities.Concrete
{
    public class Book:IEntity
    {
        public int BookId { get; set; }      
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public string Status { get; set; }


    }
}
