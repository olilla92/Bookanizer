using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookanizer.Models
{
    public class BookRecord
    {
        public string Title { get; set; }   
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Quantity { get; set; }
        public int Price { get; set; }

        public BookRecord(string sor)
        {
            string[] t = sor.Split(";");
            Title = t[0];
            Author = t[1];
            Publisher = t[2];
            PublishDate = DateTime.Parse(t[3]);
            Quantity = Convert.ToDecimal(t[4]);
            Price = Convert.ToInt32(t[5]);
        }

        public override string ToString()
        {
            return $"{Title} - {Author} - {Publisher} - {PublishDate} - {Quantity} - {Price}";
        }
    }
}
