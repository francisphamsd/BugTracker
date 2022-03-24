
namespace BugTrackerLibrary.DataAccess;

public interface IBugData
{
     Task CreateBug(BugModel bug);
     Task<List<BugModel>> GetAllApprovedBugs();
     Task<List<BugModel>> GetAllBugs();
     Task<List<BugModel>> GetAllBugsWaitingForApproval();
     Task<BugModel> GetBug(string id);
     Task UpdateBug(BugModel bug);
     Task UpvoteBug(string bugId, string userId);
}