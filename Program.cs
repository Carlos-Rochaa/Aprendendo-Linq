using Demo_Linq_com_lambda.Entities;
using System.ComponentModel.DataAnnotations;

static void Print<T>(string message, IEnumerable<T> collection)
{
    Console.WriteLine(message);
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
}

Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

List<Product> products = new List<Product>()
{
    new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
    new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
    new Product() { Id = 3, Name = "Tv", Price = 1700.0, Category = c3 },
    new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
    new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
    new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
    new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
    new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
    new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
    new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
    new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
    };

var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);


Print("TIER 1 AND PRICE < 900", r1);


var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);

Print("NAME OF PRODUCT TOOLS", r2);

var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });

Print("NAME STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);

Print("TIER 1 ORDERED BY PRICE THEN BY NAME", r4);

var r5 = r4.Skip(2).Take(4);

Print("TIER 1 ORDERED BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

var r6 = products.FirstOrDefault();

Console.WriteLine("FIRST TEST1: " + r6);

var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();

Console.WriteLine("FIRST OR DEFAULT TEST2: " + r7);
Console.WriteLine();

var r8 = products.Where(p => p.Id == 3).SingleOrDefault();

Console.WriteLine("SINGLE OR DEFAULT TEST1: " + r8);

var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
Console.WriteLine("SINGLE OR DEFAULT TEST2: " + r9);
Console.WriteLine();

var r10 = products.Max(p => p.Price);

Console.WriteLine("MAX PRICE: " + r10);

var r11 = products.Min(p => p.Price);
Console.WriteLine("MIN PRICE: " + r11);

var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);

Console.WriteLine("CATEGORY 1 PRICES SUM: " + r12);

var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
Console.WriteLine("CATEGORY 1 AVERAGE PRICE: " + r13);

var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
Console.WriteLine("CATEGORY 5 AVERAGE PRICE: " + r14);

var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (a, b) => a + b);
Console.WriteLine("CATEGORY 1 AGREGATE SUM: " + r15);
Console.WriteLine();
var r16 = products.GroupBy(p => p.Category);
foreach (var r in r16)
{
    Console.WriteLine("Category " + r.Key.Name + ": ");
    foreach (var p in r)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
}



