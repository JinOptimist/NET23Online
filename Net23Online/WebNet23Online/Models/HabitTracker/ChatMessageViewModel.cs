namespace WebNet23Online.Models.HabitTracker;

public class ChatMessageViewModel
{
    public string AuthorName { get; set; }
    public DateTime SendingTime { get; set; }
    public string MessageContent { get; set; }
    public bool IsMine  { get; set; }
}