using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services.Interfaces;

public interface IHabitChatService
{
    public List<ChatMessageViewModel> GenerateChatMessages(List<HabitTrChatMessageData> messages, int userId);
}