using System;
using System.IO;
using System.Reflection;
using Configurations;
using Models;
using Mongo2Go;
using Services;

namespace hello_mongo_inmemory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mongo In-Memory World!");

            var mongo = MongoDbRunner.Start(Path.Combine("mongo", Guid.NewGuid().ToString()));
            var service = new BookService(new BookstoreDatabaseSettings{
                BookstoreCollectionName = "BookstoreCollection",
                ConnectionString = mongo.ConnectionString,
                DatabaseName = "BookstoreDatabase"
            });

            service.Create(new Book{
                Id = "5bfd996f7b8e48dc15ff215d",
                BookName = "Design Patterns",
                Author = "Ralph Johnson",
                Category = "Computers",
                Price = 54.93M
            });

            Console.WriteLine("Wrote a book in the store");

            var book = service.Get("5bfd996f7b8e48dc15ff215d");

            Console.WriteLine($"Book readed from store is '{book.BookName}'");


        }
    }
}
