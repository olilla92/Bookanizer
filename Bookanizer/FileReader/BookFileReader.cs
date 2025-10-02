using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookanizer.Models;
using Bookanizer.Repos;

namespace Bookanizer.FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BookRecord> books = new List<BookRecord>();
            BookRepo bookRepo = new BookRepo();

            try
            {
                foreach (var rec in File.ReadAllLines("bookanizer.csv").Skip(1))
                {
                    books.Add(new BookRecord(rec));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                foreach (BookRecord record in books)
                {
                    bookRepo.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\tCím - Szerző - Kiadó - Kiadási év - Mennyiség (db) - Ár (Ft)\n");
            try
            {
                foreach (BookRecord record in bookRepo.AllBooks())
                {
                    Console.WriteLine($"{record.Title} - {record.Author} - {record.Publisher} - {record.PublishDate} - {record.Quantity} db - {record.Price} Ft");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"\nA könyvek száma: {bookRepo.BookCount()} db");

            Console.WriteLine("\nKeresés kiadási év alapján: ");
            foreach (var record in bookRepo.PulishedIn2000(1869))
                Console.WriteLine($"\t{record.Title} - {record.Quantity} db - {record.Price} Ft");

            Console.WriteLine("\nKeresés cím alapján: ");
            foreach (var record in bookRepo.SearchedByTitle("A kőszívű ember fiai"))
                Console.WriteLine($"\t{record.Title} - {record.Author} - {record.Publisher} - {record.PublishDate} - {record.Quantity} db - {record.Price} Ft");

            Console.WriteLine("\nKönyv vásárlás:");
            int amount = 23;
            foreach (var record in bookRepo.Purchase("A kőszívű ember fiai", amount)) 
                Console.WriteLine($"\t{record.Title} - {record.Quantity - amount} db - {record.Price} Ft");

        }
    } 
}
