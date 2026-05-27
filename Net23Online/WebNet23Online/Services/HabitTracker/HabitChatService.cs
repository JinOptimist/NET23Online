using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services;

public class HabitChatService: IHabitChatService
{
    public List<ChatMessageViewModel> GenerateChatMessages(List<HabitTrChatMessageData> messages, int userId)
    {
        var model = new List<ChatMessageViewModel>();
        foreach (var message in messages)
        {
            var chatMessage = new ChatMessageViewModel()
            {
                AuthorName = message.User.Name,
                SendingTime = message.Date,
                MessageContent = message.Content,
                IsMine = message.User.Id == userId,
            };
            model.Add(chatMessage);
        }
        
        return model;
    }
}