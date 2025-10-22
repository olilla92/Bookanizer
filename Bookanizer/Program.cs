using Bookanizer.Models;
using Bookanizer.Repos;

BookRepo repo = new BookRepo();
repo.ReadDataFrom("bookanizer.csv");

Console.WriteLine($"\nA könyvek száma: {repo.NumberOfBooks} db\n");

var addBook = new BookRecord(); addBook.Title = "Űrodisszeia"; addBook.Author = "Arthur C. Clarke";addBook.Publisher = "metropolis media group kft"; addBook.PublishDate = 2001; addBook.Quantity = 40; addBook.Price = 3500;
repo.Add(addBook);
Console.WriteLine($"A hozzáadott könyv címe: {addBook.Title}");


Console.WriteLine($"\nA könyvcímek listája: ");
foreach(string title in repo.AllBooks())
    Console.WriteLine($"\t{title}");

int year = 2000;
Console.WriteLine($"\nKönyvek {year}-ből: ");
foreach(BookRecord record in  repo.PulishedIn2000(year))
    Console.WriteLine($"\t{record.Title} - {record.Author} - {record.Publisher} adta ki");

string searched = "1984";
Console.WriteLine($"\nCím alapú keresés: {searched}");
foreach(BookRecord record in repo.SearchedByTitle(searched))
    Console.WriteLine($"\t{record}");

string which = "A mémgépezet";
int amount = 1;
Console.WriteLine($"\nVásárlás: ");
foreach (BookRecord purchased in repo.Purchase(which, amount))
    if(amount > purchased.Quantity)
        Console.WriteLine("Nem lehet nagyobb a megvásárolandó mennyiség a valós értéknél.");
    else
        Console.WriteLine($"\t{which}: {purchased.Quantity - amount} darab maradt.");

Console.WriteLine($"\nA raktáron levő legtöbb könyv: ");
foreach(BookRecord most in repo.MostAmountBook())
    Console.WriteLine($"\t{most.Title} - {most.Quantity} db");

Console.WriteLine($"\nRendezés kiadás időrendje szerint: ");
foreach (BookRecord ordered in repo.OrderedByDate())
    Console.WriteLine($"\t{ordered.Title} - {ordered.PublishDate}");

Console.WriteLine("Könyv törlése: ");
bool removed1 = repo.Remove("A titánok bukása", "Ken Follett", "Pac Macmilan", 2010, 22, 7899);
Console.WriteLine($"A titánok bukása törölve lett-e? {removed1}");
Console.WriteLine($"Könyvek száma törlés után: {repo.NumberOfBooks}");