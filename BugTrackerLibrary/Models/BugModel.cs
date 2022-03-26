﻿namespace BugTrackerLibrary.Models;

public class BugModel
{
     [BsonId]
     [BsonRepresentation(BsonType.ObjectId)]
     public string Id { get; set; }
     public string Bug { get; set; }
     public string Description { get; set; }
     public DateTime DateReported { get; set; } = DateTime.UtcNow;
     public CategoryModel Category { get; set; }
     public BasicUserModel Author { get; set; }
     public HashSet<string> UserVotes { get; set; } = new();
     public StatusModel BugStatus { get; set; }
     public string OwnerNotes { get; set; }
     public bool AcceptedForRelease { get; set; } = false;
     public bool Archived { get; set; } = false;
     public bool Rejected { get; set; } = false;
}