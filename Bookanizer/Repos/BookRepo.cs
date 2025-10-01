using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookanizer.Models;

namespace Bookanizer.Repos
{
    public class BookRepo
    {
        private List<BookRecord> _books;
        public BookRepo()
        {
            _books = new List<BookRecord>();
        }

        public BookRecord? Find(string Title, string Author, string Publisher, DateTime PublisherDate, decimal Quantity, int Price) => _books.FirstOrDefault(b => b.Title == Title && b.Author == Author && b.Publisher == Publisher && b.PublishDate == PublisherDate && b.Quantity == Quantity && b.Price == Price);
    
        public bool Add(BookRecord book)
        {
            if(book == null) 
                throw new ArgumentNullException(nameof(book));
            BookRecord? FoundItem = Find(string Title, )
        }
    }
}
