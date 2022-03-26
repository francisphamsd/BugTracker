
namespace BugTrackerLibrary.DataAccess;

public interface IBugData
{
     Task<List<BugModel>> GetAllApprovedBugs();
     Task<List<BugModel>> GetAllBugs();
     Task<List<BugModel>> GetAllBugsWaitingForApproval();
     Task<BugModel> GetBug(string id);
     Task<List<BugModel>> GetUsersBugs(string userId);
     Task ReportBug(BugModel bug);
     Task UpdateBug(BugModel bug);
     Task UpvoteBug(string bugId, string userId);
}