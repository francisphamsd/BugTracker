using Microsoft.Extensions.Caching.Memory;

namespace BugTrackerLibrary.DataAccess;

public class MongoBugData : IBugData
{
     private readonly IDbConnection _db;
     private readonly IUserData _userData;
     private readonly IMemoryCache _cache;
     private readonly IMongoCollection<BugModel> _bugs;
     private const string CacheName = "BugData";

     public MongoBugData(IDbConnection db, IUserData userData, IMemoryCache cache)
     {
          _db = db;
          _userData = userData;
          _cache = cache;
          _bugs = db.BugCollection;
     }

     public async Task<List<BugModel>> GetAllBugs()
     {
          var output = _cache.Get<List<BugModel>>(CacheName);
          if (output is null)
          {
               var results = await _bugs.FindAsync(b => b.Archived == false);
               output = results.ToList();

               _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
          }

          return output;
     }

     public async Task<List<BugModel>> GetAllApprovedBugs()
     {
          var output = await GetAllBugs();
          return output.Where(x => x.ApprovedForRelease).ToList();
     }

     public async Task<BugModel> GetBug(string id)
     {
          var results = await _bugs.FindAsync(b => b.Id == id);
          return results.FirstOrDefault();
     }

     public async Task<List<BugModel>> GetAllBugsWaitingForApproval()
     {
          var output = await GetAllBugs();
          return output.Where(x =>
               x.ApprovedForRelease == false
               && x.Rejected == false).ToList();
     }

     public async Task UpdateBug(BugModel bug)
     {
          await _bugs.ReplaceOneAsync(b => b.Id == bug.Id, bug);
          _cache.Remove(CacheName);
     }

     public async Task UpvoteBug(string bugId, string userId)
     {
          var client = _db.Client;

          using var session = await client.StartSessionAsync();

          session.StartTransaction();

          try
          {
               var db = client.GetDatabase(_db.DbName);
               var bugsInTransaction = db.GetCollection<BugModel>(_db.BugCollectionName);
               var bug = (await bugsInTransaction.FindAsync(b => b.Id == bugId)).First();

               bool isUpvote = bug.UserVotes.Add(userId);
               if (isUpvote == false)
               {
                    bug.UserVotes.Remove(userId);
               }

               await bugsInTransaction.ReplaceOneAsync(b => b.Id == bugId, bug);

               var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
               var user = await _userData.GetUser(bug.Author.Id);

               if (isUpvote)
               {
                    user.VotedOnBugs.Add(new BasicBugModel(bug));
               }
               else
               {
                    var bugToRemove = user.VotedOnBugs.Where(b => b.Id == bugId).First();
                    user.VotedOnBugs.Remove(bugToRemove);
               }
               await usersInTransaction.ReplaceOneAsync(u => u.Id == userId, user);

               await session.CommitTransactionAsync();

               _cache.Remove(CacheName);
          }
          catch (Exception ex)
          {
               await session.AbortTransactionAsync();
               throw;
          }
     }

     public async Task ReportBug(BugModel bug)
     {
          var client = _db.Client;

          using var session = await client.StartSessionAsync();

          session.StartTransaction();

          try
          {
               var db = client.GetDatabase(_db.DbName);
               var bugsInTransaction = db.GetCollection<BugModel>(_db.BugCollectionName);
               await bugsInTransaction.InsertOneAsync(bug);

               var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
               var user = await _userData.GetUser(bug.Author.Id);
               user.AuthoredBugs.Add(new BasicBugModel(bug));
               await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

               await session.CommitTransactionAsync();
          }
          catch (Exception ex)
          {
               await session.AbortTransactionAsync();
               throw;
          }
     }
}