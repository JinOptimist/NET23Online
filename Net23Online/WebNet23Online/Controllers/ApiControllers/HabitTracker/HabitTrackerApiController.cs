using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.HabitTracker;
using WebNet23Online.Hubs;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers.ApiControllers.HabitTracker;

[Route("api/[controller]/[action]")]
[ApiController]
public class HabitTrackerApiController : ControllerBase
{
    private IHabitChatRepository _habitChatRepository;
    private IHubContext<HabitChatHub, IHabitChatHub> _habitChatHub;


    public HabitTrackerApiController(IHabitChatRepository habitChatRepository,
        IHubContext<HabitChatHub, IHabitChatHub> habitChatHub)
    {
        _habitChatRepository = habitChatRepository;
        _habitChatHub = habitChatHub;
    }

    public void SendMessage(string username, string message, int userId)
    {
        var newMessage = new HabitTrChatMessageData()
        {
            Date = DateTime.Now,
            Content = message,
            UserId = userId,
        };
        _habitChatRepository.Add(newMessage);
        _habitChatHub.Clients.All.NewMassageInChat(username,  message);
    }
}