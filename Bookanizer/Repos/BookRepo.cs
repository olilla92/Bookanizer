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
        private List<BookRecord> _books = new List<BookRecord>();
        public void ReadDataFrom(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                Console.WriteLine($"{lines.Length} sor van a fájlban.");
                foreach (string line in lines.Skip(1))
                {
                    BookRecord book = BookRecord.FromLine(line, new char[] { ';' });
                    _books.Add(book);
                    Console.WriteLine(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int NumberOfBooks => _books.Count;

        public BookRecord? Find(string title, string author, string publisher, decimal publishdate, int quantity, int price) => _books.FirstOrDefault(b => b.Title == title && b.Author == author && b.Publisher == publisher && b.PublishDate == publishdate && b.Quantity == quantity && b.Price == price);
        
        public bool Add(BookRecord book)
        {
            if(book == null)
                throw new ArgumentNullException(nameof(book));
            BookRecord? foundItem = Find(book.Title, book.Author, book.Publisher, book.PublishDate, book.Quantity, book.Price);
            if (foundItem != null)
                return false;
            _books.Add(book);
            return true;
        }

        public bool Remove(string title, string author, string publisher, decimal publishdate, int quantity, int price)
        {
            BookRecord? foundItem = Find(title, author, publisher, publishdate, quantity, price);
            if (foundItem == null)
                return false;
            _books.Remove(foundItem);
            return true;
        }

        public List<string> AllBooks()
        {
            return _books.Select(b => b.Title).ToList();
        }
        public IReadOnlyList<BookRecord> PulishedIn2000(int pubyear)
        {
            return _books.Where(b => b.PublishDate ==  pubyear).ToList();
        }
        public IReadOnlyList<BookRecord> SearchedByTitle(string searched)
        {
            return _books.Where(b => b.Title == searched).ToList();
        }
        public IReadOnlyList<BookRecord> Purchase(string which, int amount)
        {
            return _books.Where(b => b.Title == which).Select(b => b).ToList();
        }
        public IReadOnlyList<BookRecord> MostAmountBook()
        {
            var most = _books.Max(b => b.Quantity);
            return _books.Where(b => b.Quantity == most).ToList();
        }
        public IReadOnlyList<BookRecord> OrderedByDate()
        {
            return _books.OrderBy(b => b.PublishDate).ThenBy(b => b.Title).ToList();
        }
    }
}
