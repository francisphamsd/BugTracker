﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BugTrackerLibrary.DataAccess;

public class DbConnection : IDbConnection
{
     private readonly IConfiguration _config;
     private readonly IMongoDatabase _db;
     private string _connectionId = "MongoDB";
     public string DbName { get; private set; }
     public string CategoryCollectionName { get; private set; } = "categories";
     public string StatusCollectionName { get; private set; } = "statuses";
     public string UserCollectionName { get; private set; } = "users";
     public string BugCollectionName { get; private set; } = "bugs";
     public MongoClient Client { get; private set; }
     public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
     public IMongoCollection<StatusModel> StatusCollection { get; private set; }
     public IMongoCollection<UserModel> UserCollection { get; private set; }
     public IMongoCollection<BugModel> BugCollection { get; private set; }

     public DbConnection(IConfiguration config)
     {
          _config = config;
          Client = new MongoClient(_config.GetConnectionString(_connectionId));
          DbName = _config["DatabaseName"];
          _db = Client.GetDatabase(DbName);

          CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
          StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionName);
          UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
          BugCollection = _db.GetCollection<BugModel>(BugCollectionName);
     }
}

