using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using GenerateUserApi.Models;

namespace GenerateUserApi.DAL
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

        public async Task<string> InsertUser(User user)
        {
            try
            {
                if (user != null)
                {
                    await this.col.InsertOneAsync(user);
                    return user.id;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await this.col.Find(x => x.email.Equals(email)).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                var user = await this.col.Find(x => x.id.Equals(id)).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}