using UserCRUD.Data;
using UserCRUD.Models;

using var db = new AppDbContext();
db.Database.EnsureCreated();

Console.WriteLine("=== User CRUD App ===\n");

Console.WriteLine("--- CREATE ---");
var user1 = new User { Name = "Ahmad",  Price = 1500 };
var user2 = new User { Name = "Sara",   Price = 2200 };
var user3 = new User { Name = "Khalid", Price = 800  };
var user4 = new User { Name = "Lina",   Price = 3000 };
db.Users.AddRange(user1, user2, user3, user4);
db.SaveChanges();
Console.WriteLine("4 users added successfully.\n");

Console.WriteLine("--- READ ---");
var allUsers = db.Users.ToList();
foreach (var u in allUsers)
    Console.WriteLine($"Id: {u.Id} | Name: {u.Name} | Price: {u.Price}");

Console.WriteLine("\n--- UPDATE ---");
var userToUpdate = db.Users.FirstOrDefault(u => u.Name == "Ahmad");
if (userToUpdate != null)
{
    userToUpdate.Price = 2000;
    db.SaveChanges();
    Console.WriteLine($"Ahmad updated -> New Price: {userToUpdate.Price}");
}

Console.WriteLine("\n--- DELETE ---");
var userToDelete = db.Users.FirstOrDefault(u => u.Name == "Khalid");
if (userToDelete != null)
{
    db.Users.Remove(userToDelete);
    db.SaveChanges();
    Console.WriteLine("Khalid deleted successfully.");
}

Console.WriteLine("\n--- LINQ QUERIES ---");

Console.WriteLine("\n1. Users with Price > 1000:");
var highPrice = db.Users.Where(u => u.Price > 1000).ToList();
foreach (var u in highPrice)
    Console.WriteLine($"   {u.Name} - {u.Price}");

Console.WriteLine("\n2. Ordered by Price:");
var ordered = db.Users.OrderBy(u => u.Price).ToList();
foreach (var u in ordered)
    Console.WriteLine($"   {u.Name} - {u.Price}");

var total = db.Users.Sum(u => u.Price);
Console.WriteLine($"\n3. Total Price: {total}");

var avg = db.Users.Average(u => u.Price);
Console.WriteLine($"4. Average Price: {avg:F2}");

var maxPrice = db.Users.Max(u => u.Price);
Console.WriteLine($"5. Max Price: {maxPrice}");

Console.WriteLine("\n6. Search for Sara:");
var found = db.Users.FirstOrDefault(u => u.Name == "Sara");
if (found != null)
    Console.WriteLine($"   Found: {found.Name} - {found.Price}");

var count = db.Users.Count();
Console.WriteLine($"\n7. Total Users: {count}");

Console.WriteLine("\n8. Names only:");
var names = db.Users.Select(u => u.Name).ToList();
names.ForEach(n => Console.WriteLine($"   {n}"));

Console.WriteLine("\n=== Program Finished ===");
