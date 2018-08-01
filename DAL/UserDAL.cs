using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GenerateUserApi.Models
{
    public class UserDAL
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<User> col;

        public UserDAL()
        {
            this.client = new MongoClient("mongodb://champ6803:www12345@clusteratsdev-shard-00-00-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-01-lxs0q.mongodb.net:27017,clusteratsdev-shard-00-02-lxs0q.mongodb.net:27017/admin?ssl=true");
            this.db = client.GetDatabase("ats");
            this.col = this.db.GetCollection<User>("user");
        }

        public async Task<IEnumerable<User>> All()
        {
            var list = await this.col.Find(new BsonDocument()).ToListAsync();
            return list;
        }

        public async Task InsertUser(User user)
        {
            await this.col.InsertOneAsync(user);
        }

        public async Task<User> GetUser(string email)
        {
            var user = await this.col.Find(x => x.email.Equals(email)).FirstAsync();
            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}