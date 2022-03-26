
namespace BugTrackerLibrary.DataAccess;

public interface IBugData
{
     Task<List<BugModel>> GetAllAcceptedBugs();
     Task<List<BugModel>> GetAllBugs();
     Task<List<BugModel>> GetAllBugsWaitingForAcceptance();
     Task<BugModel> GetBug(string id);
     Task<List<BugModel>> GetUsersBugs(string userId);
     Task ReportBug(BugModel bug);
     Task UpdateBug(BugModel bug);
     Task UpvoteBug(string bugId, string userId);
}