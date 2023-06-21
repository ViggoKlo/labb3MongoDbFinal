using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class CartManager : IRepository<Cart>
    {
        private readonly IMongoCollection<Cart> _cartCollection;

        public CartManager()
        {
            var hostName = "localhost";
            var databaseName = "Labb3MongoDbFinal";
            var connectionString = $"mongodb://{hostName}:27017";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _cartCollection = database.GetCollection<Cart>("Carts", new MongoCollectionSettings());
        }

        public void add(Cart entity)
        {
            _cartCollection.InsertOne(entity);
        }

        public void delete(Cart entity)
        {
            _cartCollection.DeleteOne(c => c.Id == entity.Id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartCollection.Find(_ => true).ToEnumerable();
        }

        public Cart GetById(Guid id)
        {
            return _cartCollection.Find(c => c.CustomerId == id).FirstOrDefault();
        }

        public Cart GetByUsernameAndPassword(string password, string username)
        {
            throw new NotImplementedException();
        }

        public void update(Cart entity)
        {
            delete(entity);
            add(entity);
        }
    }
}
