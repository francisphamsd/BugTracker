using MongoDB.Driver;

namespace BugTrackerLibrary.DataAccess;

public interface IDbConnection
{
     string DbName { get; }
     string CategoryCollectionName { get; }
     string StatusCollectionName { get; }
     string UserCollectionName { get; }
     string BugCollectionName { get; }
     MongoClient Client { get; }
     IMongoCollection<CategoryModel> CategoryCollection { get; }
     IMongoCollection<StatusModel> StatusCollection { get; }
     IMongoCollection<UserModel> UserCollection { get; }
     IMongoCollection<BugModel> BugCollection { get; }
}