namespace BugTrackerLibrary.Models;

public class BasicBugModel
{
     [BsonRepresentation(BsonType.ObjectId)]
     public string Id { get; set; }
     public string Bug { get; set; }

     public BasicBugModel()
     {

     }

     public BasicBugModel(BugModel bug)
     {
          Id = bug.Id;
          Bug = bug.Bug;
     }
}