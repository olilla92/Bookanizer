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

        public BookRecord? Find(string Title, string Author, string Publisher, int PublisherDate, decimal Quantity, int Price) => _books.FirstOrDefault(b => b.Title == Title && b.Author == Author && b.Publisher == Publisher && b.PublishDate == PublisherDate && b.Quantity == Quantity && b.Price == Price);
        public int BookCount() => _books.Count;
        //public decimal Purchase(string which, decimal amount) => _books.Where(b => b.Title == which && b.Quantity == amount).Select(b => b).ToList();
        public bool Add(BookRecord book)
        {
            if(book == null) 
                throw new ArgumentNullException(nameof(book));
            BookRecord? FoundItem = Find(book.Title, book.Author, book.Publisher, book.PublishDate, book.Quantity, book.Price);
            if (FoundItem != null)
                return false;
            _books.Add(book);
            return true;
        }

        public IReadOnlyList<BookRecord> AllBooks()
        {
            return _books.Select(b => b).ToList();
        }
        public IReadOnlyList<BookRecord> PulishedIn2000(int pubyear)
        {
            return _books.Where(b => b.PublishDate ==  pubyear).ToList();
        }
        public IReadOnlyList<BookRecord> SearchedByTitle(string searched)
        {
            return _books.Where(b => b.Title == searched).ToList();
        }
        public IReadOnlyList<BookRecord> Purchase(string which, decimal amount)
        {
            return _books.Where(b => b.Title == which && b.Quantity >= amount).Select(b => b).ToList();
        }
    }
}
