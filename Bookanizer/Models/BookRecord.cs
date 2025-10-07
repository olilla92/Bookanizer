using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookanizer.Repos;

namespace Bookanizer.Models
{
    public class BookRecord
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public decimal PublishDate { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int Price { get; set; } = 0;

        public static BookRecord FromLine(string line, char[]? separator)
        {
            string[] t = line.Split(separator);
            BookRecord bookRecord = new BookRecord();

            bookRecord.Title = t[0];
            bookRecord.Author = t[1];
            bookRecord.Publisher = t[2];
            decimal publishDate = 0;
            bool success = decimal.TryParse(t[3], out publishDate);
            if(!success || publishDate < 0) 
                throw new ArgumentOutOfRangeException(nameof(publishDate));
            bookRecord.PublishDate = publishDate;
            int quantity = 0;
            bool success2 = int.TryParse(t[4], out quantity);
            if(!success || quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            bookRecord.Quantity = quantity;
            int price = 0;
            bool success3 = int.TryParse(t[5], out price);
            if (!success || price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            bookRecord.Price = price;

            return bookRecord;
        }

        public override string ToString()
        {
            return $"\t{Title} - {Author} - {Publisher} - {PublishDate} - {Quantity} db - {Price} Ft";
        }
    }
}
