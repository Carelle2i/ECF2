// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
//
// public class EventStatisticsService
// {
//     private readonly EventService _eventService;
//     private readonly MongoDbService _mongoDbService;
//
//     public EventStatisticsService(EventService eventService, MongoDbService mongoDbService)
//     {
//         _eventService = eventService;
//         _mongoDbService = mongoDbService;
//     }
//
//     public async Task<EventStatisticsDto> GetEventStatistics(int eventId)
//     {
//         var eventDetails = _eventService.GetEventById(eventId);
//         var eventStatistics = await _mongoDbService.GetStatisticsAsync();
//
//         // Traiter les données combinées
//         return new EventStatisticsDto
//         {
//             EventName = eventDetails?.Name,
//             ParticipantCount = eventDetails?.ParticipantEvents.Count ?? 0,
//             Statistics = eventStatistics
//         };
//     }
// }
//
// public class EventStatisticsDto
// {
//     public string EventName { get; set; }
//     public int ParticipantCount { get; set; }
//     public List<Statistic> Statistics { get; set; }
// }