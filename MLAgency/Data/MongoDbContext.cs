// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
//
// public class MongoDbContext
// {
//     private readonly IMongoDatabase _database;
//
//     public MongoDbContext(IConfiguration config)
//     {
//         var client = new MongoClient(config["MongoDb:ConnectionString"]);
//         _database = client.GetDatabase(config["MongoDb:DatabaseName"]);
//     }
//
//     public IMongoCollection<Statistic> Statistics => _database.GetCollection<Statistic>("Statistics");
// }
//
// public class Statistic
// {
//     public string EventName { get; set; }
//     public int ParticipantCount { get; set; }
// }