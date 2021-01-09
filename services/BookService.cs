using System.Collections.Generic;
using Configurations;
using Models;
using MongoDB.Driver;

namespace Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _collection;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Book>(settings.BookstoreCollectionName);
        }

        public List<Book> Get() => _collection.Find(item => true).ToList();

        public Book Get(string id) => _collection.Find(item => item.Id == id).FirstOrDefault();

        public void Create(Book item) => _collection.InsertOne(item);

        public ReplaceOneResult Update(string id, Book item) => _collection.ReplaceOne(item => item.Id == id, item);

        public DeleteResult Delete(Book item) => _collection.DeleteOne(i => i.Id == item.Id);

        public DeleteResult Delete(string id) => _collection.DeleteOne(item => item.Id == id);
    }
}