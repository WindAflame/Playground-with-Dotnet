// See https://aka.ms/new-console-template for more information
using CrudExample.AppDataContext;
using CrudExample.Models;
using Microsoft.EntityFrameworkCore;

using var db = new CrudDbContext();

Console.WriteLine($"Database path: {db.DbPath}");

// Create
Console.WriteLine("Inserting a new book");
db.Add(new Book { Name = "ASP .NET pour les nuls", Price = 0 });
db.SaveChanges();

// Read
Console.WriteLine("Querying for books");
// SQL
// var results =
//     from book in db.Book
//     where book.Id == 1
//     select book;
var results = db.Book
    .OrderBy(b => b.Id);

foreach (var s in results.AsEnumerable())
{
    Console.WriteLine($"Book [ id: {s.Id}; name: {s.Name}; price: {s.Price} ]");
}
var book = results.First();

// Update
Console.WriteLine("Updating the price of a book");
book.Price = 99;
db.SaveChanges();

foreach (var s in results.AsEnumerable())
{
    Console.WriteLine($"Book [ id: {s.Id}; name: {s.Name}; price: {s.Price} ]");
}

// Delete
Console.WriteLine("Remove book");
db.Remove(book);
db.SaveChanges();

