using DataAccess.Interfaces;
using DataAccess.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class CustomerManager : IRepository<Customer>
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerManager()
        {
            var hostName = "localhost";
            var databaseName = "Labb3MongoDbFinal";
            var connectionString = $"mongodb://{hostName}:27017";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _customerCollection = database.GetCollection<Customer>("Customers", new MongoCollectionSettings());
        }

        public void add(Customer entity)
        {
            _customerCollection.InsertOne(entity);
        }

        public void delete(Customer entity)
        {
            _customerCollection.DeleteOne(c => c.Id == entity.Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerCollection.Find(_ => true).ToEnumerable();
        }

        public Customer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByUsernameAndPassword(string username, string password)
        {
            return _customerCollection.Find(c => c.Password == password && c.Username.Equals(username)).FirstOrDefault();
        }

        public void update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
