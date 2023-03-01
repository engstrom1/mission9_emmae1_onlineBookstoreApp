using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstoreApp.Models
{
    public class EFOnlineBookstoreRepository : IOnlineBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFOnlineBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
