using Microsoft.AspNetCore.SignalR;

namespace WebNet23Online.Hubs;

public class HabitChatHub : Hub<IHabitChatHub>
{
    
}

public interface IHabitChatHub
{
    Task NewMassageInChat(string name, string message);
}